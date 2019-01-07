/*******************************************************************
 * FileName: UIRolePanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Tools;
using Solider.Manager;
using Solider.UI.Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UICreateRolePanel : IFSMState {
                public string id { get { return "create_role_panel_ui"; } }

                private string roleType;
                private UIDisplayRaw display;
                private InputField nameInputField;
                private Transform transform;
                private GameObject gameObject;

                public UICreateRolePanel() {
                } // end UICreateRolePanel 

                private void OnSwitchRole(string roleType) {
                    if (this.roleType == roleType) return;
                    // end if
                    this.roleType = roleType;
                    display.SetDisplayGo(new DisplayRole(roleType));
                } // end OnSwitchRole

                private void OnClickCreateBtn() {
                    if (nameInputField.text == "" || nameInputField.text == null) {
                        ObjectTool.InstantiateGo("MessageBoxUI", ResourcesTool.LoadPrefabUI("message_box_ui"),
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("请输入角色名");
                        return;
                    } // end if
                    SqliteManager.CreateRole(GameManager.playerInfo.username, UISelectRolePanel.createIndex, nameInputField.text, roleType);
                    OnClickBackBtn();
                } // end OnClickCreateBtn

                private void OnClickBackBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UISelectRolePanel());
                } // end OnClickBackBtn

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("CreateRolePanelUI", ResourcesTool.LoadPrefabUI(id),
                        SceneManager.mainCanvas.rectTransform);
                    transform = gameObject.transform;
                    roleType = "";
                    nameInputField = transform.Find("NameInputField").GetComponent<InputField>();
                    nameInputField.characterLimit = 5;
                    display = transform.Find("DisplayRaw").gameObject.AddComponent<UIDisplayRaw>();
                    transform.Find("RoleList/Role_0").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnSwitchRole(ConstConfig.SWORDMAN); });
                    transform.Find("RoleList/Role_1").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnSwitchRole(ConstConfig.ARCHER); });
                    transform.Find("RoleList/Role_2").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnSwitchRole(ConstConfig.MAGICIAN); });
                    transform.Find("CreateBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickCreateBtn);
                    transform.Find("BackBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickBackBtn);
                    OnSwitchRole(ConstConfig.SWORDMAN);
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                    gameObject = null;
                    transform = null;
                } // end DoBeforeLeaving

                public void Reason() {
                } // end Reason

                public void Act() {
                } // end Act
            } // end class UICreateRolePanel
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider 

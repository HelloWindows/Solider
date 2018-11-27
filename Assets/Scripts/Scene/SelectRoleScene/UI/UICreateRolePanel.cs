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
                public string id { get { return "UICreateRolePanel"; } }

                private string roleType;
                private UIDisplayRaw display;
                private InputField nameInputField;
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;

                public UICreateRolePanel() {
                    parent = SceneManager.mainCanvas.rectTransform;
                } // end UICreateRolePanel 

                public UICreateRolePanel(RectTransform parent) {
                    this.parent = parent;
                } // end UICreateRolePanel 

                private void OnSwitchRole(string roleType) {
                    if (this.roleType == roleType) return;
                    // end if
                    this.roleType = roleType;
                    display.SetDisplayGo(new DisplayRole(roleType));
                } // end OnSwitchRole

                private void OnClickCreateBtn() {
                    if (nameInputField.text == "" || nameInputField.text == null) {
                        ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI", SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("请输入角色名");
                        return;
                    } // end if
                    SqliteManager.CreateRole(GameManager.playerInfo.username, UISelectRolePanel.createIndex, nameInputField.text, roleType);
                    OnClickBackBtn();
                } // end OnClickCreateBtn

                private void OnClickBackBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UISelectRolePanel());
                } // end OnClickBackBtn

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("CreateRolePanelUI", "Scene/SelectRoleScene/CreateRolePanelUI", parent);
                    transform = gameObject.transform;
                    roleType = "";
                    nameInputField = transform.Find("NameInputField").GetComponent<InputField>();
                    nameInputField.characterLimit = 5;
                    display = transform.Find("DisplayRaw").gameObject.AddComponent<UIDisplayRaw>();
                    transform.Find("RoleList/Role_0").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnSwitchRole(ConstConfig.SWORDMAN); });
                    transform.Find("RoleList/Role_1").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnSwitchRole(ConstConfig.ARCHER); });
                    transform.Find("RoleList/Role_2").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnSwitchRole(ConstConfig.MAGICIAN); });
                    transform.Find("CreateBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickCreateBtn);
                    transform.Find("BackBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickBackBtn);
                    OnSwitchRole(ConstConfig.SWORDMAN);
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                    gameObject = null;
                    transform = null;
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act
            } // end class UICreateRolePanel
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider 

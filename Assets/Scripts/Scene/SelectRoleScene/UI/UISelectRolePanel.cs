/*******************************************************************
 * FileName: UISelectRolePanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Middleware;
using Framework.Tools;
using Solider.Manager;
using Solider.UI.Custom;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UISelectRolePanel : IFSMState {
                private int roleindex;
                private int selectedindex;
                private Text t_roleName;
                private UIDisplayRaw display;
                private Dictionary<int, string[]> roleDict;
                private IFSM fsm;
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;
                public static int createIndex { get; private set; }

                public string name { get; private set; }

                public UISelectRolePanel(string name, IFSM fsm, RectTransform parent) {
                    this.fsm = fsm;
                    this.name = name;
                    this.parent = parent;
                } // end UISelectRolePanel 

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("SelectRolePanelUI", "Scene/SelectRoleScene/SelectRolePanelUI", parent);
                    transform = gameObject.transform;
                    roleindex = 0;
                    createIndex = -1;
                    selectedindex = -1;
                    roleDict = new Dictionary<int, string[]>();
                    t_roleName = transform.Find("RoleName").GetComponent<Text>();
                    t_roleName.text = "";
                    display = transform.Find("DisplayRaw").gameObject.AddComponent<UIDisplayRaw>();
                    string prefix = "RoleList/Role_";
                    for (int i = 0; i < 3; i++) {
                        int index = i;
                        roleDict.Add(index, SqliteManager.GetRoleWithID(PlayerManager.username, index));
                        transform.Find(prefix + i).gameObject.AddComponent<UIButton>().AddAction(delegate () { OnSwitchRole(index); });
                        if (null != roleDict[index]) transform.Find(prefix + i + "/Text").GetComponent<Text>().text = roleDict[index][0];
                        // end if
                    } // end for
                    transform.Find("DeleteRoleBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickDeleteRoleBtn);
                    transform.Find("StartGameBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickStartGameBtn);
                    InitialSwitchRole();
                } // end DoBeforeEntering

                private void InitialSwitchRole() {
                    if (ChechExitID(roleindex)) {
                        OnSwitchRole(roleindex);
                        return;
                    } // end if
                    for (int i = 0; i < roleDict.Count; i++) {
                        if (ChechExitID(i)) {
                            OnSwitchRole(i);
                            break;
                        } // end if         
                    } // end for
                } // end InitialSwitchRole

                private void OnSwitchRole(int index) {
                    if (!ChechExitID(index)) {
                        createIndex = index;
                        fsm.PerformTransition("UICreateRole");
                        return;
                    } // end if
                    if (selectedindex == index) return;
                    // end if
                    roleindex = index;
                    selectedindex = index;
                    t_roleName.text = roleDict[index][0];
                    display.SetDisplayGo(new DisplayGo(roleDict[index][1]));
                } // end OnSwitchRole

                private void OnClickDeleteRoleBtn() {
                    if (!ChechExitID(roleindex)) return;
                    // end if          
                    UIDialogBox dialog = ObjectTool.InstantiateGo("DialogBoxUI", "UI/Custom/DialogBoxUI", 
                        SceneManager.mainCanvas.rectTransform).AddComponent<UIDialogBox>();
                    dialog.SetMessage("确定删除角色!");
                    dialog.AddAction(DeleteRole);
                } // end OnClickDeleteRole

                private void DeleteRole() {
                    if (!ChechExitID(roleindex)) return;
                    // end if     
                    SqliteManager.DeleteRoleWithID(PlayerManager.username, roleindex);
                    if (roleDict.ContainsKey(roleindex)) roleDict[roleindex] = null;
                    // end if
                    t_roleName.text = "";
                    transform.Find("RoleList/Role_" + roleindex + "/Text").GetComponent<Text>().text = "创建角色";
                    display.ClearDiplay();
                    InitialSwitchRole();
                } // end DeleteRole

                private void OnClickStartGameBtn() {
                    if (!ChechExitID(roleindex)) {
                        ObjectTool.InstantiateGo("MessageBoxUI", "UI/Custom/MessageBoxUI",
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("请选择角色");
                        return;
                    } // end if
                    PlayerManager.SelectedRole(roleindex, roleDict[roleindex][0], roleDict[roleindex][1]);
                    SceneLoader.LoadNextLevel(new NoviceVillage());
                } // end OnClickStartGameBtn

                /// <summary>
                /// 检测id是否存在
                /// </summary>
                /// <param name="id"> id </param>
                /// <returns> 存在返回 ture </returns>
                private bool ChechExitID(int index) {
                    if (roleDict == null || !roleDict.ContainsKey(index) || null == roleDict[index]) return false;
                    // end if
                    return true;
                } // end ChechExitID

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                } // end DoBeforeLeaving

                public void DoRemove() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                } // end DoRemove

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act
            } // end class UISelectRolePanel
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider 

﻿/*******************************************************************
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
                public string id { get { return "select_role_panel_ui"; } }

                private int roleindex;
                private int selectedindex;
                private Text t_roleName;
                private UIDisplayRaw display;
                private Dictionary<int, string[]> roleDict;
                private RectTransform rectTransform;
                private GameObject gameObject;
                public static int createIndex { get; private set; }

                public UISelectRolePanel() {
                } // end UISelectRolePanel 

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("SelectRolePanelUI", ResourcesTool.LoadPrefabUI(id), 
                        SceneManager.mainCanvas.rectTransform);
                    rectTransform = gameObject.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = SceneManager.mainCanvas.sizeDelta;
                    roleindex = 0;
                    createIndex = -1;
                    selectedindex = -1;
                    roleDict = new Dictionary<int, string[]>();
                    t_roleName = rectTransform.Find("RoleName").GetComponent<Text>();
                    t_roleName.text = "";
                    display = rectTransform.Find("DisplayRaw").gameObject.AddComponent<UIDisplayRaw>();
                    string prefix = "RoleList/Role_";
                    for (int i = 0; i < 3; i++) {
                        int index = i;
                        roleDict.Add(index, SqliteManager.GetRoleInfoWithID(GameManager.playerInfo.username, index));
                        rectTransform.Find(prefix + i).gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnSwitchRole(index); });
                        if (null != roleDict[index]) rectTransform.Find(prefix + i + "/Text").GetComponent<Text>().text = roleDict[index][0];
                        // end if
                    } // end for
                    rectTransform.Find("DeleteRoleBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickDeleteRoleBtn);
                    rectTransform.Find("StartGameBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickStartGameBtn);
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
                        SceneManager.uiPanelFMS.PerformTransition(new UICreateRolePanel());
                        return;
                    } // end if
                    if (selectedindex == index) return;
                    // end if
                    roleindex = index;
                    selectedindex = index;
                    t_roleName.text = roleDict[index][0];
                    Dictionary<string, string> wearDict;
                    SqliteManager.GetWearInfoWithID(GameManager.playerInfo.username, roleindex, out wearDict);
                    display.SetDisplayGo(new DisplayRole(roleDict[index][1], wearDict));
                } // end OnSwitchRole

                private void OnClickDeleteRoleBtn() {
                    if (!ChechExitID(roleindex)) return;
                    // end if          
                    UIDialogBox dialog = ObjectTool.InstantiateGo("DialogBoxUI", ResourcesTool.LoadPrefabUI("dialog_box_ui"), 
                        SceneManager.mainCanvas.rectTransform).AddComponent<UIDialogBox>();
                    dialog.SetMessage("确定删除角色!");
                    dialog.AddAction(DeleteRole);
                } // end OnClickDeleteRole

                private void DeleteRole() {
                    if (!ChechExitID(roleindex)) return;
                    // end if     
                    SqliteManager.DeleteRoleWithID(GameManager.playerInfo.username, roleindex);
                    if (roleDict.ContainsKey(roleindex)) roleDict[roleindex] = null;
                    // end if
                    t_roleName.text = "";
                    rectTransform.Find("RoleList/Role_" + roleindex + "/Text").GetComponent<Text>().text = "创建角色";
                    display.ClearDiplay();
                    InitialSwitchRole();
                } // end DeleteRole

                private void OnClickStartGameBtn() {
                    if (!ChechExitID(roleindex)) {
                        ObjectTool.InstantiateGo("MessageBoxUI", ResourcesTool.LoadPrefabUI("message_box_ui"),
                            SceneManager.mainCanvas.rectTransform).AddComponent<UIMessageBox>().SetMessage("请选择角色");
                        return;
                    } // end if
                    GameManager.playerInfo.SelectedRole(roleindex, roleDict[roleindex][0], roleDict[roleindex][1]);
                    LoaderScene.LoadNextLevel(new NoviceVillage());
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
                    gameObject = null;
                    rectTransform = null;
                } // end DoBeforeLeaving

                public void Reason() {
                } // end Reason

                public void Act() {
                } // end Act
            } // end class UISelectRolePanel
        } // end namespace UI
    } // end namespace Scene
} // end namespace Solider 

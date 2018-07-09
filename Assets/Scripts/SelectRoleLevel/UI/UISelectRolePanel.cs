/*******************************************************************
 * FileName: UISelectRolePanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Middleware;
using Framework.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    public class UISelectRolePanel : MonoBehaviour {
        private int currentID;
        private Text t_roleName;
        private DisplayRaw display;
        private Dictionary<int, string[]> roleDict;

        // Use this for initialization
        private void Start () {
            currentID = -1;
            roleDict = new Dictionary<int, string[]>();
            t_roleName = transform.Find("RoleName").GetComponent<Text>();
            t_roleName.text = "";
            display = transform.Find("DisplayRaw").gameObject.AddComponent<DisplayRaw>();
            string prefix = "RoleList/Role_";

            for (int i = 0; i < 3; i++) {
                int id = i;
                roleDict.Add(id, SqliteManager.GetRoleWithID(id.ToString()));
                transform.Find(prefix + i).gameObject.AddComponent<UIButton>().AddAction(delegate () { OnSwitchRole(id); });
                if (null != roleDict[id]) transform.Find(prefix + i + "/Text").GetComponent<Text>().text = roleDict[id][0];
                // end if
            } // end for
            transform.Find("DeleteRoleBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickDeleteRoleBtn);
            transform.Find("StartGameBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickStartGameBtn);
            InitialSwitchRole();
        } // end Start     

        private void InitialSwitchRole() {
            if (ChechExitID(InstanceMgr.CurrentID)) {
                OnSwitchRole(InstanceMgr.CurrentID);
                return;
            } // end if

            for (int i = 0; i < roleDict.Count; i++) {
                if (ChechExitID(i)) {
                    OnSwitchRole(i);
                    break;
                } // end if         
            } // end for
        } // end InitialSwitchRole

        private void OnSwitchRole(int id) {

            if (!ChechExitID(id)) {
                InstanceMgr.SetCurrentID(id);
                ObjectTool.InstantiateGo("CreateRolePanelUI", "SelectRoleLevel/UI/CreateRolePanelUI", CanvasManager.MainCanvasTrans).AddComponent<UICreateRolePanel>();
                if (null != gameObject) Destroy(gameObject);
                // end if
                return;
            } // end if
            if (currentID == id) return;
            // end if
            currentID = id;
            InstanceMgr.SetCurrentID(id);
            t_roleName.text = roleDict[id][0];
            display.ReplaceDisplayCurrentRole(roleDict[id][1]);
        } // end OnSwitchRole

        private void OnClickDeleteRoleBtn() {
            if (!ChechExitID(InstanceMgr.CurrentID)) return;
            // end if          
            UIDialogBox dialog = ObjectTool.InstantiateGo("DialogBoxUI", "UI/DialogBoxUI", CanvasManager.MainCanvasTrans).AddComponent<UIDialogBox>();
            dialog.SetMessage("确定删除角色!");
            dialog.AddAction(DeleteRole);
        } // end OnClickDeleteRole

        private void DeleteRole() {
            int id = InstanceMgr.CurrentID;
            SqliteManager.DeleteRole(id.ToString());
            if (roleDict.ContainsKey(id)) roleDict[id] = null;
            // end if
            t_roleName.text = "";
            transform.Find("RoleList/Role_" + id + "/Text").GetComponent<Text>().text = "创建角色";
            display.ClearDiplay();
            InitialSwitchRole();
        } // end DeleteRole

        private void OnClickStartGameBtn() {
            if (!ChechExitID(InstanceMgr.CurrentID)) {
                ObjectTool.InstantiateGo("MessageBoxUI", "UI/MessageBoxUI", CanvasManager.MainCanvasTrans).AddComponent<UIMessageBox>().SetMessage("请选择角色");
                return;
            } // end if
            SceneLoader.LoadNextLevel("MainGameLevel");
        } // end OnClickStartGameBtn

        /// <summary>
        /// 检测id是否存在
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns> 存在返回 ture </returns>
        private bool ChechExitID(int id) {
            if (roleDict == null || !roleDict.ContainsKey(id) || null == roleDict[id]) return false;
            // end if
            return true;
        } // end ChechExitID
    } // end class UISelectRolePanel
} // end namespace Solider 

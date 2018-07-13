/*******************************************************************
 * FileName: UISelectRolePanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Middleware;
using Framework.Tools;
using Solider.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    public class UISelectRolePanel : MonoBehaviour {
        private string currentID;
        private Text t_roleName;
        private DisplayRaw display;
        private Dictionary<string, string[]> roleDict;

        // Use this for initialization
        private void Start () {
            currentID = "miss";
            PlayerManager.SetPlayerID("0");
            roleDict = new Dictionary<string, string[]>();
            t_roleName = transform.Find("RoleName").GetComponent<Text>();
            t_roleName.text = "";
            display = transform.Find("DisplayRaw").gameObject.AddComponent<DisplayRaw>();
            string prefix = "RoleList/Role_";

            for (int i = 0; i < 3; i++) {
                string id = i.ToString();
                roleDict.Add(id, SqliteManager.GetRoleWithID(id));
                transform.Find(prefix + i).gameObject.AddComponent<UIButton>().AddAction(delegate () { OnSwitchRole(id); });
                if (null != roleDict[id]) transform.Find(prefix + i + "/Text").GetComponent<Text>().text = roleDict[id][0];
                // end if
            } // end for
            transform.Find("DeleteRoleBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickDeleteRoleBtn);
            transform.Find("StartGameBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickStartGameBtn);
            InitialSwitchRole();
        } // end Start     

        private void InitialSwitchRole() {
            if (ChechExitID(PlayerManager.playerID)) {
                OnSwitchRole(PlayerManager.playerID);
                return;
            } // end if

            for (int i = 0; i < roleDict.Count; i++) {
                if (ChechExitID(i.ToString())) {
                    OnSwitchRole(i.ToString());
                    break;
                } // end if         
            } // end for
        } // end InitialSwitchRole

        private void OnSwitchRole(string id) {

            if (!ChechExitID(id)) {
                PlayerManager.SetPlayerID(id);
                ObjectTool.InstantiateGo("CreateRolePanelUI", "SelectRoleLevel/UI/CreateRolePanelUI", CanvasManager.MainCanvasTrans).AddComponent<UICreateRolePanel>();
                if (null != gameObject) Destroy(gameObject);
                // end if
                return;
            } // end if
            if (currentID == id) return;
            // end if
            currentID = id;
            PlayerManager.SetPlayerID(id);
            t_roleName.text = roleDict[id][0];
            display.ReplaceDisplayCurrentRole(roleDict[id][1]);
        } // end OnSwitchRole

        private void OnClickDeleteRoleBtn() {
            if (!ChechExitID(PlayerManager.playerID)) return;
            // end if          
            UIDialogBox dialog = ObjectTool.InstantiateGo("DialogBoxUI", "UI/DialogBoxUI", CanvasManager.MainCanvasTrans).AddComponent<UIDialogBox>();
            dialog.SetMessage("确定删除角色!");
            dialog.AddAction(DeleteRole);
        } // end OnClickDeleteRole

        private void DeleteRole() {
            string id = PlayerManager.playerID;
            SqliteManager.DeleteRole(id.ToString());
            if (roleDict.ContainsKey(id)) roleDict[id] = null;
            // end if
            t_roleName.text = "";
            transform.Find("RoleList/Role_" + id + "/Text").GetComponent<Text>().text = "创建角色";
            display.ClearDiplay();
            InitialSwitchRole();
        } // end DeleteRole

        private void OnClickStartGameBtn() {
            if (!ChechExitID(PlayerManager.playerID)) {
                ObjectTool.InstantiateGo("MessageBoxUI", "UI/MessageBoxUI", CanvasManager.MainCanvasTrans).AddComponent<UIMessageBox>().SetMessage("请选择角色");
                return;
            } // end if
            PlayerManager.InitPlayerManager(PlayerManager.playerID, roleDict[PlayerManager.playerID][0], roleDict[PlayerManager.playerID][1]);
            SceneLoader.LoadNextLevel("MainGameLevel");
        } // end OnClickStartGameBtn

        /// <summary>
        /// 检测id是否存在
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns> 存在返回 ture </returns>
        private bool ChechExitID(string id) {
            if (roleDict == null || !roleDict.ContainsKey(id) || null == roleDict[id]) return false;
            // end if
            return true;
        } // end ChechExitID
    } // end class UISelectRolePanel
} // end namespace Solider 

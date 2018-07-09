﻿/*******************************************************************
 * FileName: UIRolePanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UICreateRolePanel : MonoBehaviour {

        private string roleType;
        private DisplayRaw display;
        private InputField nameInputField;

        private void Start () {
            roleType = "";
            nameInputField = transform.Find("NameInputField").GetComponent<InputField>();
            nameInputField.characterLimit = 5;
            display = transform.Find("DisplayRaw").gameObject.AddComponent<DisplayRaw>();
            transform.Find("RoleList/Role_0").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnSwitchRole("Shooter"); });
            transform.Find("RoleList/Role_1").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnSwitchRole("Solider"); });
            transform.Find("CreateBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickCreateBtn);
            transform.Find("BackBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickBackBtn);
            OnSwitchRole("Shooter");
        } // end Start

        private void OnSwitchRole(string roleType) {
            if (this.roleType == roleType) return;
            // end if
            this.roleType = roleType;
            display.ReplaceDisplayInitialRole(roleType);
        } // end OnSwitchRole

        private void OnClickCreateBtn() {
            if (nameInputField.text == "" || nameInputField.text == null) {
                ObjectTool.InstantiateGo("MessageBoxUI", "UI/MessageBoxUI", CanvasManager.MainCanvasTrans).AddComponent<UIMessageBox>().SetMessage("请输入角色名");
                return;
            } // end if
            SqliteManager.CreateRole(InstanceMgr.CurrentID.ToString(), nameInputField.text, roleType);
            if (null == gameObject) return;
            // end if
            OnClickBackBtn();
        } // end OnClickCreateBtn

        private void OnClickBackBtn() {
            ObjectTool.InstantiateGo("SelectRolePanelUI", "SelectRoleLevel/UI/SelectRolePanelUI", CanvasManager.MainCanvasTrans).AddComponent<UISelectRolePanel>();
            if (null == gameObject) return;
            // end if
            Destroy(gameObject);
        } // end OnClickBackBtn
    } // end class UICreateRolePanel
} // end namespace Solider 

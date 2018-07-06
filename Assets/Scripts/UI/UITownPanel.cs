/*******************************************************************
 * FileName: TownPanelUI.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
	public class UITownPanel : MonoBehaviour {

		// Use this for initialization
		void Start () {
            transform.Find("InfoBtn").gameObject.AddComponent<UIButton>().AddAction(delegate() { OnClickInfoBtn(); });
            transform.Find("PackBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickPackBtn(); });
            transform.Find("SettingBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickSettingBtn(); });
        } // end Start

        private void OnClickInfoBtn() {
            ObjectTool.InstantiateGo("InfoPanelUI", "UI/InfoPanelUI", CanvasManager.MainCanvasTrans).AddComponent<UIInfoPanel>();
        } // end OnClickInfoBtn

        private void OnClickPackBtn() {
            ObjectTool.InstantiateGo("PackPanelUI", "UI/PackPanelUI", CanvasManager.MainCanvasTrans).AddComponent<UIPackPanel>();
        } // end OnClickInfoBtn

        private void OnClickSettingBtn() {
            ObjectTool.InstantiateGo("SettingPanelUI", "UI/SettingPanelUI", CanvasManager.MainCanvasTrans).AddComponent<UISettingPanel>();
        } // end OnClickSettingBtn
    } // end class UITownPanel 
} // end namespace Solider
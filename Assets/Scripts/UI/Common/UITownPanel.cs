/*******************************************************************
 * FileName: TownPanelUI.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using Solider.UI.Custom;
using UnityEngine;

namespace Solider {
    namespace UI {
        namespace Common {
            public class UITownPanel : MonoBehaviour {

                // Use this for initialization
                void Start() {
                    transform.Find("InfoBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickInfoBtn(); });
                    transform.Find("PackBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickPackBtn(); });
                    transform.Find("SettingBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickSettingBtn(); });
                } // end Start

                private void OnClickInfoBtn() {
                    ObjectTool.InstantiateGo("InfoPanelUI", "UI/Common/InfoPanelUI", 
                        SceneManager.mainCanvas.rectTransform).AddComponent<UIInfoPanel>();
                } // end OnClickInfoBtn

                private void OnClickPackBtn() {
                    ObjectTool.InstantiateGo("PackPanelUI", "UI/Common/PackPanelUI", 
                        SceneManager.mainCanvas.rectTransform).AddComponent<UIPackPanel>();
                } // end OnClickInfoBtn

                private void OnClickSettingBtn() {
                    ObjectTool.InstantiateGo("SettingPanelUI", "UI/Common/SettingPanelUI",
                        SceneManager.mainCanvas.rectTransform).AddComponent<UISettingPanel>();
                } // end OnClickSettingBtn
            } // end class UITownPanel 
        } // end namespace Common
    } // end namespace UI 
} // end namespace Solider
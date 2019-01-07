/*******************************************************************
 * FileName: TownPanelUI.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Tools;
using Solider.UI.Custom;
using UnityEngine;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UITownPanel : IFSMState {
                public string id { get { return "town_panel_ui"; } }

                private Transform transform;
                private GameObject gameObject;

                public UITownPanel() {
                } // end UITownPanel

                private void OnClickInfoBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UIInfoPanel());
                } // end OnClickInfoBtn

                private void OnClickPackBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UIPackPanel());
                } // end OnClickInfoBtn

                private void OnClickSettingBtn() {
                    SceneManager.uiPanelFMS.PerformTransition(new UISettingPanel());
                } // end OnClickSettingBtn

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("TownPanelUI", ResourcesTool.LoadPrefabUI(id),
                        SceneManager.mainCanvas.rectTransform);
                    transform = gameObject.transform;
                    transform.Find("InfoBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickInfoBtn(); });
                    transform.Find("PackBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickPackBtn(); });
                    transform.Find("SettingBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickSettingBtn(); });
                    GameObject ioystickUI = ObjectTool.InstantiateGo("MainPanelUI", ResourcesTool.LoadPrefabUI("joystick_ui"), transform);
                    ioystickUI.transform.Find("JoystickUI").gameObject.AddComponent<UIJoystick>();
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
            } // end class UITownPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
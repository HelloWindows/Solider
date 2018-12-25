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
                public string id { get { return "UITownPanel"; } }

                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;

                public UITownPanel() {
                    parent = SceneManager.uiCanvas.rectTransform;
                } // end UITownPanel

                public UITownPanel(RectTransform parent) {
                    this.parent = parent;
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
                    gameObject = ObjectTool.InstantiateGo("TownPanelUI", "UI/Common/TownPanelUI", parent);
                    transform = gameObject.transform;
                    transform.Find("InfoBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickInfoBtn(); });
                    transform.Find("PackBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickPackBtn(); });
                    transform.Find("SettingBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickSettingBtn(); });
                    GameObject ioystickUI = ObjectTool.InstantiateGo("MainPanelUI", "UI/Common/JoystickUI", transform);
                    ioystickUI.transform.Find("JoystickUI").gameObject.AddComponent<UIJoystick>();
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
            } // end class UITownPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
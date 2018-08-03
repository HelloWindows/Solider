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
                public string name { get; private set; }
                private IFSM fsm;
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;

                public UITownPanel(string name, IFSM fsm, RectTransform parent) {
                    this.fsm = fsm;
                    this.name = name;
                    this.parent = parent;
                } // end UITownPanel

                private void OnClickInfoBtn() {
                    fsm.PerformTransition("UIInfoPanel");
                } // end OnClickInfoBtn

                private void OnClickPackBtn() {
                    fsm.PerformTransition("UIPackPanel");
                } // end OnClickInfoBtn

                private void OnClickSettingBtn() {
                    fsm.PerformTransition("UISettingPanel");
                } // end OnClickSettingBtn

                public void DoRemove() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                    gameObject = null;
                    transform = null;
                } // end DoRemove

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("TownPanelUI", "UI/Common/TownPanelUI", parent);
                    transform = gameObject.transform;
                    transform.Find("InfoBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickInfoBtn(); });
                    transform.Find("PackBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickPackBtn(); });
                    transform.Find("SettingBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickSettingBtn(); });
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    DoRemove();
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act
            } // end class UITownPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
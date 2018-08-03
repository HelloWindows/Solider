/*******************************************************************
 * FileName: MainPanelUI.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.UI.Custom;
using UnityEngine;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIMainPanel : IFSMState {
                public string name{ get; private set; }
                private Transform transform;
                private GameObject gameObject;

                public UIMainPanel(string name, RectTransform parent) {
                    this.name = name;
                    gameObject = ObjectTool.InstantiateGo("MainPanelUI", "UI/Common/MainPanelUI", parent);
                    transform = gameObject.transform;
                    transform.Find("JoystickUI").gameObject.AddComponent<UIJoystick>();
                } // end UIMainPanel

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeEntering() {
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                public void DoRemove() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                } // end DoRemove

                public void Reason(float deltaTime) {
                } // end Reason
            } // end class UIMainPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
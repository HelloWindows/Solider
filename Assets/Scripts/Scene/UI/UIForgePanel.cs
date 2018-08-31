/*******************************************************************
 * FileName: UIForgePanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Manager;
using Solider.UI.Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIForgePanel : IFSMState {
                public string name { get; private set; }
                private IFSM fsm;
                private RectTransform parent;
                private GameObject gameObject;
                private Transform transform { get { return gameObject.transform; } }

                public UIForgePanel(string name, IFSM fsm, RectTransform parent) {
                    this.fsm = fsm;
                    this.name = name;
                    this.parent = parent;
                } // end UISettingPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("ForgePanelUI", "UI/Common/ForgePanelUI", parent);
                    transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
                } // end DoBeforeEntering

                private void OnClickCloseBtn() {
                    fsm.PerformTransition("UITownPanel");
                } // end OnClickInfoBtn

                public void DoRemove() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoRemove

                public void DoBeforeLeaving() {
                    DoRemove();
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason 

                public void Act(float deltaTime) {
                } // end Act
            } // end class UIForgePanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
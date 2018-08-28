/*******************************************************************
 * FileName: UIGroceryPanel.cs
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
            public class UIGroceryPanel : IFSMState {
                public string name { get; private set; }
                private IFSM fsm;
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;

                public UIGroceryPanel(string name, IFSM fsm, RectTransform parent) {
                    this.fsm = fsm;
                    this.name = name;
                    this.parent = parent;
                } // end UISettingPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("GroceryPanelUI", "UI/Common/GroceryPanelUI", parent);
                    transform = gameObject.transform;
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
            } // end class UIGroceryPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
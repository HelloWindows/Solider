/*******************************************************************
 * FileName: UIGroceryPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Tools;
using Solider.UI.Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIGroceryPanel : IFSMState {
                public string id { get { return "UIGroceryPanel"; } }

                private RectTransform parent;
                private GameObject gameObject;
                private Transform transform { get { return gameObject.transform; } }

                public UIGroceryPanel() {
                    parent = SceneManager.uiCanvas.rectTransform;
                } // end UIGroceryPanel

                public UIGroceryPanel(RectTransform parent) {
                    this.parent = parent;
                } // end UISettingPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("GroceryPanelUI", "UI/Common/GroceryPanelUI", parent);
                    new UIScrollView(gameObject.transform.Find("Scroll View").GetComponent<ScrollRect>());
                    transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
                } // end DoBeforeEntering

                private void OnClickCloseBtn() {
                    SceneManager.uiPanelFMS.TransitionPrev();
                } // end OnClickInfoBtn

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason 

                public void Act(float deltaTime) {
                } // end Act
            } // end class UIGroceryPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
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
                public string id { get { return "grocery_panel_ui"; } }

                private GameObject gameObject;
                private RectTransform rectTransform;

                public UIGroceryPanel() {
                } // end UIGroceryPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("GroceryPanelUI", ResourcesTool.LoadPrefabUI(id),
                        SceneManager.mainCanvas.rectTransform);
                    rectTransform = gameObject.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = SceneManager.mainCanvas.sizeDelta;
                    new UIScrollView(gameObject.transform.Find("Scroll View").GetComponent<ScrollRect>());
                    rectTransform.Find("CloseBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickCloseBtn(); }, "ui_close");
                } // end DoBeforeEntering

                private void OnClickCloseBtn() {
                    SceneManager.uiPanelFMS.TransitionPrev();
                } // end OnClickInfoBtn

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoBeforeLeaving

                public void Reason() {
                } // end Reason 

                public void Act() {
                } // end Act
            } // end class UIGroceryPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
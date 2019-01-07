/*******************************************************************
 * FileName: UITransmitterPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom.UI;
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Middleware;
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UITransmitterPanel : IFSMState {
                public string id { get { return "UITransmitterPanel"; } }
                private Transform transform { get { return gameObject.transform; } }
                private RectTransform parent;
                private GameObject gameObject;

                public UITransmitterPanel() {
                    parent = SceneManager.mainCanvas.rectTransform;
                } // end UITownPanel

                public UITransmitterPanel(RectTransform parent) {
                    this.parent = parent;
                } // end UITownPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("TransmitterPanelUI", "Scene/NoviceVillage/UI/TransmitterPanelUI", parent);
                    LinkImageText linkText = transform.Find("LinkImageText").GetComponent<LinkImageText>();
                    linkText.text = "<size=20>  你想传送到哪里？\n\n  <a href=fightscene>[战争学院]</a></size><size=10>\n\n</size><size=20>  <a href=null>[算了..]</a></size>";
                    linkText.onHrefClick.AddListener(OnHrefClick);
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    // end if
                    Object.Destroy(gameObject);
                    gameObject = null;
                } // end DoBeforeLeaving

                public void Reason() {
                } // end Reason

                public void Act() {
                } // end Act

                public void OnHrefClick(string name) {
                    switch (name) {
                        case "fightscene":
                            LoaderScene.LoadNextLevel(new FightScene());
                            break;
                        default:
                            SceneManager.uiPanelFMS.TransitionPrev();
                            break;
                    } // end switch
                } // end OnHrefClick
            } // end class UITownPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
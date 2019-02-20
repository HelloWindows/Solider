/*******************************************************************
 * FileName: UITransmitterPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Custom.UI;
using Framework.FSM.Interface;
using Framework.Manager;
using Framework.Middleware;
using Framework.Tools;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UITransmitterPanel : IFSMState {
                public string id { get { return "transmitter_panel_ui"; } }
                private RectTransform rectTransform;
                private GameObject gameObject;
                private Dictionary<string, string> mitterDict;

                public UITransmitterPanel(Dictionary<string, string> mitterDict) {
                    this.mitterDict = mitterDict;
                } // end UITransmitterPanel

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("TransmitterPanelUI", ResourcesTool.LoadPrefabUI(id),
                        SceneManager.mainCanvas.rectTransform);
                    rectTransform = gameObject.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = SceneManager.mainCanvas.sizeDelta;
                    LinkImageText linkText = rectTransform.Find("LinkImageText").GetComponent<LinkImageText>();
                    //linkText.text = "<size=20>  你想传送到哪里？\n\n  <a href=fightscene>[战争学院]</a></size><size=10>\n\n</size><size=20>  <a href=null>[算了..]</a></size>";
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<size=20>  你想传送到哪里？\n\n</size>");
                    foreach (KeyValuePair<string, string> pair in mitterDict) {
                        builder.AppendFormat("<size=20>  <a href={0}>[{1}]</a></size><size=10>\n\n</size>", pair.Key, pair.Value);
                    } // end foreach
                    builder.Append("<size=20>  <a href=null>[算了..]</a></size>");
                    linkText.text = builder.ToString();
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
                        case GameConfig.FIGHT_SCENE:
                            LoaderScene.LoadNextLevel(new FightScene());
                            break;
                        case GameConfig.NOVICE_VILLAGE:
                            LoaderScene.LoadNextLevel(new NoviceVillage());
                            break;
                        default:
                            SceneManager.uiPanelFMS.TransitionPrev();
                            break;
                    } // end switch
                } // end OnHrefClick
            } // end class UITransmitterPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
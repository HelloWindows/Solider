﻿/*******************************************************************
 * FileName: UIInfoPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Manager;
using Solider.UI.Custom;
using Framework.Config.Const;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework.FSM.Interface;
using Framework.Tools;
using Framework.Manager;
using Solider.Config.Interface;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIInfoPanel : IFSMState {
                public string id { get { return "info_panel_ui"; } }

                private Text cellText;
                private Text infoText;
                private string selected;
                private GameObject selector;
                private GameObject infoPanel;
                private Dictionary<string, UICell> cellDict;
                private RectTransform rectTransform;
                private GameObject gameObject;
                private UIDisplayRaw display;

                public UIInfoPanel() {
                } // end UIInfoPanel

                private void UpdateShowInfo() {
                    for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) {
                        string type = ConstConfig.EquipTypeList[i];
                        IEquipInfo info = SceneManager.mainCharacter.pack.GetWearInfo().GetEquipInfo(type);
                        if (null == info) {
                            cellDict[type].HideItem();
                            continue;
                        } // end if
                        cellDict[type].SetUIItem(ResourcesTool.LoadSprite(info.spritepath), 0);
                    } // end for
                } // end UpdateShowInfo

                private void OnSelectedCell(string type) {
                    selected = type;
                    if (true == infoPanel.activeSelf) {
                        infoPanel.SetActive(false);
                        return;
                    } // end if
                    IEquipInfo info = SceneManager.mainCharacter.pack.GetWearInfo().GetEquipInfo(type);
                    if (null == info) return;
                    // end if
                    selector.transform.position = cellDict[type].transform.position;
                    selector.SetActive(true);
                    infoPanel.SetActive(true);
                    cellText.text = info.ToString();
                } // end OnPointerDownCell

                private void OnClickTakeOffBtn() {
                    SceneManager.mainCharacter.pack.GetWearInfo().TakeOffEquip(selected);
                    selected = "";
                    UpdateShowInfo();
                    selector.SetActive(false);
                    if (null == display) return;
                    // end if
                    display.FreshenDisplay();
                } // end OnClickTakeOffBtn

                private void OnClickCloseBtn() {
                    SceneManager.uiPanelFMS.TransitionPrev();
                } // end OnClickInfoBtn

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("InfoPanelUI", ResourcesTool.LoadPrefabUI(id), 
                        SceneManager.mainCanvas.rectTransform);
                    rectTransform = gameObject.GetComponent<RectTransform>();
                    rectTransform.sizeDelta = SceneManager.mainCanvas.sizeDelta;
                    selected = "";
                    infoText = rectTransform.Find("InfoText").GetComponent<Text>();
                    infoText.fontSize = 10;
                    display = rectTransform.Find("DisplayRaw").gameObject.AddComponent<UIDisplayRaw>();
                    display.SetDisplayGo(new DisplayRole(GameManager.playerInfo.roletype, SceneManager.mainCharacter.pack.GetWearInfo()));
                    cellDict = new Dictionary<string, UICell>();
                    for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) {
                        string type = ConstConfig.EquipTypeList[i];
                        cellDict[type] = rectTransform.Find("Cells/Cell_" + i).gameObject.AddComponent<UICell>();
                        cellDict[type].AddAction(delegate () { OnSelectedCell(type); });
                    } // end for
                    selector = rectTransform.Find("Selector").gameObject;
                    selector.SetActive(false);
                    infoPanel = rectTransform.Find("InfoPanel").gameObject;
                    cellText = infoPanel.transform.Find("InfoText").GetComponent<Text>();
                    cellText.fontSize = 10;
                    infoPanel.SetActive(false);
                    rectTransform.Find("TakeOffBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickTakeOffBtn);
                    rectTransform.Find("CloseBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(delegate () { OnClickCloseBtn(); },  "ui_close");
                    UpdateShowInfo();
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoBeforeLeaving

                public void Reason() {
                } // end Reason

                public void Act() {
                    if (null != SceneManager.mainCharacter)
                        infoText.text = SceneManager.mainCharacter.info.characterData.ToString();
                    // end if
                } // end Act
            } // end class UIInfoPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
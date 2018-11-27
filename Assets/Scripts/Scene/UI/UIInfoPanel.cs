/*******************************************************************
 * FileName: UIInfoPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Solider.Interface;
using Solider.Manager;
using Solider.UI.Custom;
using Framework.Config.Const;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Framework.FSM.Interface;
using Framework.Tools;
using Framework.Manager;
using Framework.Broadcast;
using Solider.Config.Item;

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIInfoPanel : IFSMState {
                public string id { get { return "UIInfoPanel"; } }

                private Text cellText;
                private Text infoText;
                private string selected;
                private GameObject selector;
                private GameObject infoPanel;
                private Dictionary<string, UICell> cellDict;
                private Dictionary<string, string> dict;
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;
                private UIDisplayRaw display;

                public UIInfoPanel() {
                    parent = SceneManager.mainCanvas.rectTransform;
                } // end UIInfoPanel

                public UIInfoPanel(RectTransform parent) {
                    this.parent = parent;
                } // end UITownPanel

                private void UpdateShowInfo() {
                    IWearInfo wear = GameManager.playerInfo.pack.GetWearInfo();
                    dict = wear.GetWearEquip();
                    for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) {
                        string type = ConstConfig.EquipTypeList[i];
                        if (null == dict || !dict.ContainsKey(type)) {
                            cellDict[type].HideItem();
                            continue;
                        } // end if
                        ItemInfo info = Configs.itemConfig.GetItemInfo(dict[type]);
                        if (null == info) {
                            cellDict[type].HideItem();
                            continue;
                        } // end if
                        cellDict[type].SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
                    } // end for
                } // end UpdateShowInfo

                private void OnSelectedCell(string type) {
                    selected = type;
                    if (true == infoPanel.activeSelf) {
                        infoPanel.SetActive(false);
                        return;
                    } // end if
                    if (null == dict || !dict.ContainsKey(type)) return;
                    // end if
                    ItemInfo info = Configs.itemConfig.GetItemInfo(dict[type]);
                    if (null == info) return;
                    // end if
                    selector.transform.position = cellDict[type].transform.position;
                    selector.SetActive(true);
                    infoPanel.SetActive(true);
                    cellText.text = info.ToString();
                } // end OnPointerDownCell

                private void OnClickTakeOffBtn() {
                    if (null == dict || !dict.ContainsKey(selected)) return;
                    // end if
                    IWearInfo wear = GameManager.playerInfo.pack.GetWearInfo();
                    wear.TakeOffEquip(selected);
                    selected = "";
                    UpdateShowInfo();
                    selector.SetActive(false);
                    BroadcastCenter.Broadcast(BroadcastType.ReloadEquip);
                    if (null == display) return;
                    // end if
                    display.FreshenDisplay();
                } // end OnClickTakeOffBtn

                private void OnClickCloseBtn() {
                    SceneManager.uiPanelFMS.TransitionPrev();
                } // end OnClickInfoBtn

                public void DoBeforeEntering() {
                    gameObject = ObjectTool.InstantiateGo("InfoPanelUI", "UI/Common/InfoPanelUI", parent);
                    transform = gameObject.transform;
                    selected = "";
                    infoText = transform.Find("InfoText").GetComponent<Text>();
                    infoText.fontSize = 10;
                    display = transform.Find("DisplayRaw").gameObject.AddComponent<UIDisplayRaw>();
                    display.SetDisplayGo(new DisplayRole(GameManager.playerInfo.roleType,
                        GameManager.playerInfo.pack.GetWearInfo().GetWearEquip()));
                    cellDict = new Dictionary<string, UICell>();
                    for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) {
                        string type = ConstConfig.EquipTypeList[i];
                        cellDict[type] = transform.Find("Cells/Cell_" + i).gameObject.AddComponent<UICell>();
                        cellDict[type].AddAction(delegate () { OnSelectedCell(type); });
                    } // end for
                    selector = transform.Find("Selector").gameObject;
                    selector.SetActive(false);
                    infoPanel = transform.Find("InfoPanel").gameObject;
                    cellText = infoPanel.transform.Find("InfoText").GetComponent<Text>();
                    infoPanel.SetActive(false);
                    transform.Find("TakeOffBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickTakeOffBtn);
                    transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
                    UpdateShowInfo();
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                    if (null != SceneManager.mainCharacter)
                        infoText.text = SceneManager.mainCharacter.info.GetAttributeData().ToString();
                    // end if
                } // end Act
            } // end class UIInfoPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
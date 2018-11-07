/*******************************************************************
 * FileName: UIInfoPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Solider.Config;
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

namespace Solider {
    namespace Scene {
        namespace UI {
            public class UIInfoPanel : IFSMState {
                private Text cellText;
                private Text infoText;
                private string selected;
                private GameObject selector;
                private GameObject infoPanel;
                private Dictionary<string, UICell> cellDict;
                private readonly string[] equipTypeList = { ConstConfig.WEAPON, ConstConfig.NECKLACE,
                    ConstConfig.RING, ConstConfig.WING, ConstConfig.ARMOE, ConstConfig.PANTS, ConstConfig.SHOES };
                private Dictionary<string, string> dict;

                public string name { get; private set; }
                private IFSM fsm;
                private Transform transform;
                private RectTransform parent;
                private GameObject gameObject;
                private UIDisplayRaw display;

                public UIInfoPanel(string name, IFSM fsm, RectTransform parent) {
                    this.fsm = fsm;
                    this.name = name;
                    this.parent = parent;
                } // end UITownPanel

                private void UpdateShowInfo() {
                    if(null != SceneManager.mainCharacter)
                        infoText.text = SceneManager.mainCharacter.info.GetAttributeData().ToString();
                    // end if
                    IWearInfo wear = GameManager.playerInfo.pack.GetWearInfo();
                    dict = wear.GetWearEquip();
                    for (int i = 0; i < equipTypeList.Length; i++) {
                        string type = equipTypeList[i];
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
                    fsm.PerformTransition("UITownPanel");
                } // end OnClickInfoBtn

                public void DoRemove() {
                    if (null == gameObject) return;
                    //end if
                    Object.Destroy(gameObject);
                } // end DoRemove

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
                    for (int i = 0; i < equipTypeList.Length; i++) {
                        string type = equipTypeList[i];
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
                    DoRemove();
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act
            } // end class UIInfoPanel 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
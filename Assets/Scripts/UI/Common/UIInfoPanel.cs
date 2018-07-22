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

namespace Solider {
    namespace UI {
        namespace Common {
            public class UIInfoPanel : MonoBehaviour {
                private Text cellText;
                private Text infoText;
                private string selected;
                private GameObject infoPanel;
                private Dictionary<string, UICell> cellDict;
                private readonly string[] equipTypeList = { ConstConfig.WEAPON, ConstConfig.ARMOE, ConstConfig.SHOES };
                private Dictionary<string, string> dict;

                // Use this for initialization
                private void Start() {
                    selected = "";
                    infoText = transform.Find("InfoText").GetComponent<Text>();
                    infoText.fontSize = 10;
                    DisplayRaw display = transform.Find("DisplayRaw").gameObject.AddComponent<DisplayRaw>();
                    display.ReplaceDisplayCurrentRole(RoleManager.roleType);
                    cellDict = new Dictionary<string, UICell>();
                    for (int i = 0; i < equipTypeList.Length; i++) {
                        string type = equipTypeList[i];
                        cellDict[type] = transform.Find("Cells/Cell_" + i).gameObject.AddComponent<UICell>();
                        cellDict[type].AddAction(delegate () { OnSelectedCell(type); });
                    } // end for
                    infoPanel = transform.Find("InfoPanel").gameObject;
                    cellText = infoPanel.transform.Find("InfoText").GetComponent<Text>();
                    infoPanel.SetActive(false);
                    transform.Find("TakeOffBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickTakeOffBtn);
                    transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
                    UpdateShowInfo();
                } // end Start

                private void UpdateShowInfo() {
                    infoText.text = RoleManager.info.GetAttributeData().ToString();
                    IWearInfo wear = RoleManager.info.GetWearInfo();
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
                    infoPanel.SetActive(true);
                    cellText.text = info.ToString();
                } // end OnPointerDownCell

                private void OnClickTakeOffBtn() {
                    if (null == dict || !dict.ContainsKey(selected)) return;
                    // end if
                    IWearInfo wear = RoleManager.info.GetWearInfo();
                    wear.TakeOffEquip(selected);
                    selected = "";
                    UpdateShowInfo();
                } // end OnClickTakeOffBtn

                private void OnClickCloseBtn() {
                    if (null == gameObject) return;
                    //end if
                    Destroy(gameObject);
                } // end OnClickInfoBtn
            } // end class UIInfoPanel 
        } // end namespace Common
    } // end namespace UI 
} // end namespace Solider
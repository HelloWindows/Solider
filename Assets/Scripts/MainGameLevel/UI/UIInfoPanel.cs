/*******************************************************************
 * FileName: UIInfoPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Manager;
using Solider.Interface;
using Solider.Manager;
using Solider.Model;
using Solider.Model.Data;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UIInfoPanel : MonoBehaviour {
        private Text infoText;
        private string selected;
        private UICell[] cellArray;
        private readonly string[] equipTypeList = { ConstConfig.WEAPON, ConstConfig.ARMOE, ConstConfig.SHOES };
        private Dictionary<string, string> dict;

        // Use this for initialization
        private void Start () {
            selected = "";
            infoText = transform.Find("InfoText").GetComponent<Text>();
            infoText.fontSize = 10;
            DisplayRaw display = transform.Find("DisplayRaw").gameObject.AddComponent<DisplayRaw>();
            display.ReplaceDisplayCurrentRole(RoleManager.roleType);
            cellArray = new UICell[equipTypeList.Length];
            for (int i = 0; i < equipTypeList.Length; i++) {
                string type = equipTypeList[i];
                cellArray[i] = transform.Find("Cells/Cell_" + i).gameObject.AddComponent<UICell>();
                cellArray[i].AddAction(delegate () { OnSelectedCell(type); });
            } // end for
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
                    cellArray[i].HideItem();
                    continue;
                } // end if
                ItemInfo info = ConfigManager.itemConfig.GetItemInfo(dict[type]);
                if (null == info) {
                    cellArray[i].HideItem();
                    continue;
                } // end if
                cellArray[i].SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
            } // end for
        } // end UpdateShowInfo

        private void OnSelectedCell(string type) {
            selected = type;
            if (null == dict || !dict.ContainsKey(type)) return;
            // end if
            ItemInfo info = ConfigManager.itemConfig.GetItemInfo(dict[type]);
            if (null == info) return;
            // end if
            infoText.text = info.ToString();
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
} // end namespace Solider
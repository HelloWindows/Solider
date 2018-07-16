/*******************************************************************
 * FileName: UIInfoPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Solider.Interface;
using Solider.Manager;
using Solider.Model;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UIInfoPanel : MonoBehaviour {
        private Text infoText;
        private Dictionary<string, string> dict;

        // Use this for initialization
        private void Start () {
            infoText = transform.Find("InfoText").GetComponent<Text>();
            infoText.fontSize = 10;
            infoText.text = RoleManager.info.GetAttributeData().ToString();              
            DisplayRaw display = transform.Find("DisplayRaw").gameObject.AddComponent<DisplayRaw>();
            display.ReplaceDisplayCurrentRole("Shooter");
            transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
            IWearInfo wear = RoleManager.info.GetWearInfo();
            wear.GetWearEquip(out dict);
            if (null == dict) return;
            // end if
            for (int i = 0; i < ConfigManager.equipTypeList.Length; i++) {
                string type = ConfigManager.equipTypeList[i];
                if (!dict.ContainsKey(type)) continue;
                // end if
                ItemInfo info = ConfigManager.itemConfig.GetItemInfo(dict[type]);
                if (null == info) continue;
                // end if
                UICell cell = transform.Find("Cells/Cell_" + i).gameObject.AddComponent<UICell>();
                cell.SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
                cell.AddAction(delegate () { OnSelectedCell(type); });
            } // end for
        } // end Start

        private void OnSelectedCell(string type) {
            if (null == dict || !dict.ContainsKey(type)) return;
            // end if
            ItemInfo info = ConfigManager.itemConfig.GetItemInfo(dict[type]);
            if (null == info) return;
            // end if
            infoText.text = info.ToString();
        } // end OnPointerDownCell

        private void OnClickCloseBtn() {
            if (null == gameObject) return;
            //end if
            Destroy(gameObject);
        } // end OnClickInfoBtn
    } // end class UIInfoPanel 
} // end namespace Solider
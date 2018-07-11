﻿/*******************************************************************
 * FileName: UIPackPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Manager;
using Solider.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UIPackPanel : MonoBehaviour {
        private UIGrid[] gridArray;

		// Use this for initialization
		private void Start () {
            gridArray = new UIGrid[ConstConfig.GRID_COUNT];
            string prefix = "GridPanel/Grids/Grid_";

            for (int i = 0; i < gridArray.Length; i++) {
                gridArray[i] = transform.Find(prefix + i).gameObject.AddComponent<UIGrid>();
                gridArray[i].SetIndex(i);
            } // end for
            OnToggleEquipment(true);
            transform.Find("GridPanel/ToggleGroup/Equipment").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleEquipment);
            transform.Find("GridPanel/ToggleGroup/Consumable").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleConsumable);
            transform.Find("GridPanel/ToggleGroup/Stuff").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleStuff);
            transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
        } // end Start

        private void OnToggleEquipment(bool isOn) {
            if (!isOn) return;
            // end if
            Dictionary<int, string[]> idDict = new Dictionary<int, string[]>();
            SqliteManager.GetPackInfoWithID(InstanceMgr.CurrentID.ToString(), "equip", ref idDict);

            for (int i = 0; i < gridArray.Length; i++) {
                if (!idDict.ContainsKey(i)) {
                    gridArray[i].HideItem();
                    continue;
                } // end if
                EquipInfo info = InstanceMgr.GetConfigManager().GetEquipInfoWithID(idDict[i][0]);

                if (null == info) {
                    gridArray[i].HideItem();
                    continue;
                } // end 
                gridArray[i].SetUIItem(info.spritepath, 0);
            } // end for
        } // end OnToggleEquipment

        private void OnToggleConsumable(bool isOn) {
#if __MY_DEBUG__
            ConsoleTool.SetConsole("OnToggleConsumable Bool: " + isOn);
#endif
        } // end OnToggleEquipment

        private void OnToggleStuff(bool isOn) {
#if __MY_DEBUG__
            ConsoleTool.SetConsole("OnToggleStuff Bool: " + isOn);
#endif
        } // end OnToggleEquipment

        private void OnClickCloseBtn() {
            if (null == gameObject) return;
            //end if
            Destroy(gameObject);
        } // end OnClickInfoBtn
    } // end class UIPackPanel 
} // end namespace Solider
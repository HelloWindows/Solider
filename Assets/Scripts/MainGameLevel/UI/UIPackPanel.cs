/*******************************************************************
 * FileName: UIPackPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Manager;
using Solider.Config;
using Solider.Data;
using Solider.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UIPackPanel : MonoBehaviour {
        private Text infoText;
        private UIGrid[] gridArray;

		// Use this for initialization
		private void Start () {
            string prefix = "GridPanel/Grids/Grid_";
            gridArray = new UIGrid[ConstConfig.GRID_COUNT];
            infoText = transform.Find("InfoText").GetComponent<Text>();
            infoText.fontSize = 10;
            infoText.alignByGeometry = false;

            for (int i = 0; i < gridArray.Length; i++) {
                int id = i;
                gridArray[i] = transform.Find(prefix + i).gameObject.AddComponent<UIGrid>();
                gridArray[i].gameObject.AddComponent<UIButton>().AddAction(delegate() { OnClickGrid(id); });
                gridArray[i].SetID(i);
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

            for (int i = 0; i < gridArray.Length; i++) {
                EquipInfo info = PlayerManager.pack.GetEquipInfoWithGid(i);
                if (null == info) {
                    gridArray[i].HideItem();
                    continue;
                } // end 
                gridArray[i].SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
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

        private void OnClickGrid(int id) {
            EquipInfo info = PlayerManager.pack.GetEquipInfoWithGid(id);
            if (null == info) {
                infoText.text = "";
                return;
            } // end if
            infoText.text = info.ToString();
        } // end OnClickGrid

        private void OnClickCloseBtn() {
            if (null == gameObject) return;
            //end if
            Destroy(gameObject);
        } // end OnClickInfoBtn
    } // end class UIPackPanel 
} // end namespace Solider
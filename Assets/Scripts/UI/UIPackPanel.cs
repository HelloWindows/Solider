/*******************************************************************
 * FileName: UIPackPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UIPackPanel : MonoBehaviour {

        private const int GRID_COUNT = 25;
        private Text[] countTextArray;
        private Image[] gridImageArray;

		// Use this for initialization
		private void Start () {
            countTextArray = new Text[GRID_COUNT];
            gridImageArray = new Image[GRID_COUNT];
            string prefix = "GridPanel/Grids/Item_";

            for (int i = 0; i < GRID_COUNT; i++) {
                int temp = i;
                gridImageArray[i] = transform.Find(prefix + i).GetComponent<Image>();
                countTextArray[i] = transform.Find(prefix + i + "/Text").GetComponent<Text>();
                gridImageArray[i].gameObject.AddComponent<UIButton>().AddAction(delegate() { OnClickGridBtn(temp); });
            } // end for
            transform.Find("GridPanel/ToggleGroup/Equipment").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleEquipment);
            transform.Find("GridPanel/ToggleGroup/Consumable").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleConsumable);
            transform.Find("GridPanel/ToggleGroup/Stuff").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleStuff);
            transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
        } // end Start

        private void OnClickGridBtn(int index) {
#if __MY_DEBUG__
            ConsoleTool.SetConsole("OnClickGridBtn Index: " + index);
#endif
        } // end OnClickGridBtn

        private void OnToggleEquipment(bool isOn) {
#if __MY_DEBUG__
            ConsoleTool.SetConsole("OnToggleEquipment Bool: " + isOn);
#endif
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

        private void ClearPanel() {

            for (int i = 0; i < GRID_COUNT; i++) {
                gridImageArray[i].sprite = null;
                countTextArray[i].text = "";
            } // end for
        } // end ClearPanel

        private void OnClickCloseBtn() {

            if (null == gameObject) return;
            //end if
            Destroy(gameObject);
        } // end OnClickInfoBtn
    } // end class UIPackPanel 
} // end namespace Solider
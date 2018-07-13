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
        private string packName;

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
                gridArray[i].AddAction(delegate () { OnSelectedGrid(id); });
                gridArray[i].AddAction(OnExchangeGrid);
                gridArray[i].SetID(i);
            } // end for
            OnToggleEquipment(true);
            transform.Find("GridPanel/ToggleGroup/Equipment").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleEquipment);
            transform.Find("GridPanel/ToggleGroup/Consumable").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleConsumable);
            transform.Find("GridPanel/ToggleGroup/Stuff").GetComponent<Toggle>().onValueChanged.AddListener(OnToggleStuff);
            transform.Find("ArrangeBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnArrangeBtn(); });
            transform.Find("UseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
            transform.Find("DiscardBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
            transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
        } // end Start

        /// <summary>
        /// 切换装备背包
        /// </summary>
        /// <param name="isOn"></param>
        private void OnToggleEquipment(bool isOn) {
            if (!isOn) return;
            // end if
            infoText.text = "";
            packName = "equip";
            for (int i = 0; i < gridArray.Length; i++) {
                EquipInfo info = PlayerManager.pack.GetEquipInfoWithGid(i);
                if (null == info) {
                    gridArray[i].HideItem();
                    continue;
                } // end if
                gridArray[i].SetUIItem(Resources.Load<Sprite>(info.spritepath), 0);
            } // end for
        } // end OnToggleEquipment

        /// <summary>
        /// 切换消耗品背包
        /// </summary>
        /// <param name="isOn"></param>
        private void OnToggleConsumable(bool isOn) {
            if (!isOn) return;
            // end if
            infoText.text = "";
            packName = "consume";
            for (int i = 0; i < gridArray.Length; i++) {
                ConsumeInfo info = PlayerManager.pack.GetConsumeInfoWithGid(i);
                if (null == info) {
                    gridArray[i].HideItem();
                    continue;
                } // end 
                int count = PlayerManager.pack.GetConsumeCountWithGid(i);
                gridArray[i].SetUIItem(Resources.Load<Sprite>(info.spritepath), count);
            } // end for
        } // end OnToggleEquipment

        /// <summary>
        /// 切换材料背包
        /// </summary>
        /// <param name="isOn"></param>
        private void OnToggleStuff(bool isOn) {
            if (!isOn) return;
            // end if
            infoText.text = "";
            packName = "stuff";
            for (int i = 0; i < gridArray.Length; i++) {
                StuffInfo info = PlayerManager.pack.GetStuffInfoWithGid(i);
                if (null == info) {
                    gridArray[i].HideItem();
                    continue;
                } // end 
                int count = PlayerManager.pack.GetStuffCountWithGid(i);
                gridArray[i].SetUIItem(Resources.Load<Sprite>(info.spritepath), count);
            } // end for
        } // end OnToggleEquipment

        /// <summary>
        /// 置换格子信息
        /// </summary>
        /// <param name="gid"> 格子id </param>
        /// <param name="target"> 目标格子id </param>
        private void OnExchangeGrid(int gid, int target) {
            PlayerManager.pack.ExchangeGridInfoWithGid(packName, gid, target);
        } // end OnExchangeGrid

        /// <summary>
        /// 格子被选中
        /// </summary>
        /// <param name="id"> 格子id </param>
        private void OnSelectedGrid(int id) {
            switch (packName) {
                case "equip":
                    EquipInfo eInfo = PlayerManager.pack.GetEquipInfoWithGid(id);
                    if (null != eInfo){
                        infoText.text = eInfo.ToString();
                    } else {
                        infoText.text = "";
                    }// end if
                    break;

                case "consume":
                    ConsumeInfo cInfo = PlayerManager.pack.GetConsumeInfoWithGid(id);
                    if (null != cInfo) {
                        infoText.text = cInfo.ToString();
                    } else {
                        infoText.text = "";
                    }// end if
                    break;

                case "stuff":
                    StuffInfo sInfo = PlayerManager.pack.GetStuffInfoWithGid(id);
                    if (null != sInfo) {
                        infoText.text = sInfo.ToString();
                    } else {
                        infoText.text = "";
                    }// end if
                    break;
                default:
                    infoText.text = "";
                    break;
            } // end switch
        } // end OnClickGrid

        private void OnArrangeBtn() {
            PlayerManager.pack.ArrangePackWithName(packName);
            switch (packName) {
                case "equip":
                    OnToggleEquipment(true);
                    break;

                case "consume":
                    OnToggleConsumable(true);
                    break;

                case "stuff":
                    OnToggleStuff(true);
                    break;
                default:
                    infoText.text = "";
                    break;
            } // end switch
        } // end OnArrangeBtn

        private void OnClickCloseBtn() {
            if (null == gameObject) return;
            //end if
            Destroy(gameObject);
        } // end OnClickInfoBtn
    } // end class UIPackPanel 
} // end namespace Solider
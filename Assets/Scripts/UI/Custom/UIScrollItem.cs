/*******************************************************************
 * FileName: UIScrollItem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIScrollItem {
                private GameObject gameObject;
                private Transform transform { get { return gameObject.transform; } }
                private Text infoText;
                private Image iconImage;
                private string itemID;
                private const int limitUp = 250;
                private const int limitDown = -250;
                private const int resetGap = 500;

                public UIScrollItem(RectTransform parent, Vector3 localPos, Action<string> onClick) {
                    gameObject = ObjectTool.InstantiateGo("ScrollItemUI", "UI/Custom/ScrollItemUI", 
                        parent, localPos, Vector3.zero, Vector3.one);
                    infoText = transform.Find("Info").GetComponent<Text>();
                    iconImage = transform.Find("Icon").GetComponent<Image>();
                } // end UIScrollItem

                public void ResetItem(Sprite sprite, string info) {
                    infoText.text = info;
                    iconImage.sprite = sprite;
                } // end ResetItem

                public bool ScrollUp(float interval) {
                    transform.localPosition += Vector3.up * interval;
                    if (transform.localPosition.y < limitUp) return true;
                    // end if
                    return false;
                } // end ScrollUp

                public void SetTop() {
                    transform.localPosition = new Vector3(0, transform.localPosition.y + resetGap, 0);
                } // end SetTop

                public void SetBotton() {
                    transform.localPosition = new Vector3(0, transform.localPosition.y - resetGap, 0);
                } // end SetBotton

                public bool ScorllDown(float interval) {
                    transform.localPosition += Vector3.down * interval;
                    if (transform.localPosition.y > limitDown) return true;
                    // end if  
                    return false;
                } // end ScorllDown
            } // end class UIScrollItem 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider
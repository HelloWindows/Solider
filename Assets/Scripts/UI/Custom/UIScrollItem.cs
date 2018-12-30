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
                private string id;
                private const int resetGap = 500;

                public UIScrollItem(RectTransform parent, Vector3 localPos, Action<string> onClick) {
                    gameObject = ObjectTool.InstantiateGo("ScrollItemUI", "UI/Custom/ScrollItemUI", 
                        parent, localPos, Vector3.zero, Vector3.one);
                    gameObject.AddComponent<UIButton>().AddListener(delegate() { onClick(id); });
                    infoText = transform.Find("Info").GetComponent<Text>();
                    iconImage = transform.Find("Icon").GetComponent<Image>();
                } // end UIScrollItem

                public void ResetItem(string id, Sprite sprite, string info) {
                    this.id = id;
                    infoText.text = info;
                    iconImage.sprite = sprite;
                } // end ResetItem

                public void SetTop() {
                    transform.localPosition = new Vector3(0, transform.localPosition.y + resetGap, 0);
                } // end SetTop

                public void SetBotton() {
                    transform.localPosition = new Vector3(0, transform.localPosition.y - resetGap, 0);
                } // end SetBotton
            } // end class UIScrollItem 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider
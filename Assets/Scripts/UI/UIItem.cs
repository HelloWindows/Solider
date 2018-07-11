/*******************************************************************
 * FileName: UIItem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UIItem : MonoBehaviour {

        private Image image;
        private Text countText;

        private void Awake() {
            image = transform.Find("Image").GetComponent<Image>();
            countText = transform.Find("Text").GetComponent<Text>();
        } // end Awake

        public void SetSprite(Sprite sprite) {
            image.sprite = sprite;
        } // end SetSprite

        public void SetCount(int count) {
            if (count <= 0) {
                countText.text = "";
                return;
            } // end if
            countText.text = count.ToString();
        } // end SetCount
    } // end class UIItem 
} // end namespace Solider
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
        public Text countText;

        public int count { get; private set; }
        public Sprite sprite { get; private set; }

        private void Awake() {
            image = transform.Find("Image").GetComponent<Image>();
            image.raycastTarget = false;
            countText = transform.Find("Text").GetComponent<Text>();
            countText.raycastTarget = false;
        } // end Awake

        public void SetSprite(Sprite sprite) {
            this.sprite = sprite;
            image.sprite = sprite;
        } // end SetSprite

        public void SetCount(int count) {
            if (count <= 0) {
                this.count = 0;
                countText.text = "";
                return;
            } // end if
            this.count = count;
            countText.text = count.ToString();
        } // end SetCount
    } // end class UIItem 
} // end namespace Solider
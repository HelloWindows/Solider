/*******************************************************************
 * FileName: UIItem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIItem : MonoBehaviour {
                private Image image;
                public Text text;

                public int count { get; private set; }
                public Sprite sprite { get; private set; }

                private void Awake() {
                    image = transform.Find("Image").GetComponent<Image>();
                    image.raycastTarget = false;
                    text = transform.Find("Text").GetComponent<Text>();
                    text.raycastTarget = false;
                } // end Awake

                public void SetSprite(Sprite sprite) {
                    this.sprite = sprite;
                    image.sprite = sprite;
                } // end SetSprite

                public void SetCount(int count) {
                    if (count <= 1) {
                        text.text = "";
                        return;
                    } // end if
                    this.count = count;
                    text.text = count.ToString();
                } // end SetCount

                public void SetPercent(int numerator, int denominator) {
                    if (denominator <= 0) {
                        text.text = "";
                        return;
                    } // end if
                    if (numerator < denominator) {
                        text.text = "<color=#FF0000FF>" + numerator + "/" + denominator + "</color>";
                    } else {
                        text.text = "<color=#7CFC00FF>" + numerator + "/" + denominator + "</color>";
                    } // end if
                } // end Percent
            } // end class UIItem 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider
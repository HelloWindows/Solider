/*******************************************************************
 * FileName: UISkill.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine;
using UnityEngine.UI;
using Framework.Tools;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UISkill : IDisposable {
                private Image icon;
                private Image mask;
                private Text timer;

                public UISkill(string id, RectTransform parent, string spritePath, Vector2 iconSize) {
                    icon = CanvasTool.InstantiateImage(id, parent, spritePath, Vector3.zero, iconSize);
                    mask = CanvasTool.InstantiateImage("mask", icon.rectTransform, Vector3.zero, iconSize);
                    timer = CanvasTool.InstantiateText("timer", parent, Vector3.zero);
                    timer.fontSize = 20;
                    timer.alignment = TextAnchor.MiddleCenter;
                    mask.color = new Color(0, 0, 0, 0.33f);
                    mask.type = Image.Type.Filled;
                    mask.fillMethod = Image.FillMethod.Radial360;
                    mask.fillOrigin = 2;
                    mask.fillClockwise = false;
                    mask.fillAmount = 0;
                } // end Icon

                public void SetAmount(float amount) {
                    if (null == mask) return;
                    // end if
                    mask.fillAmount = amount;
                } // end SetAmount

                public void SetTimer(float value) {
                    if (null == timer) return;
                    // end if
                    timer.text = value.ToString("f1");
                } // end SetTimer

                public void Dispose() {
                    if (null != mask) UnityEngine.Object.Destroy(mask.gameObject);
                    // end if
                    if (null != icon) UnityEngine.Object.Destroy(icon.gameObject);
                    // end if
                } // end Dispose
            } // end class UISkill
        } // end namespace
    } // end namespace
} // end namespace Custom 

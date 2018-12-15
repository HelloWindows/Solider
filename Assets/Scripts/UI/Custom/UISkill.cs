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
using Solider.Config.Interface;
using Solider.ModelData.Interface;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UISkill : IDisposable {
                private Image icon;
                private Image mask;
                private Text timeText;
                private RectTransform transfrom;
                private ITimer timer;

                public UISkill(ISkillInfo info, ITimer timer, RectTransform parent, Vector3 localPos, Vector2 iconSize) {
                    this.timer = timer;
                    transfrom = CanvasTool.InstantiateEmptyUI("uiskill", parent, localPos).GetComponent<RectTransform>();
                    icon = CanvasTool.InstantiateImage(info.id, transfrom, info.spritepath, Vector3.zero, iconSize);
                    mask = CanvasTool.InstantiateImage("mask", icon.rectTransform, Vector3.zero, iconSize);
                    timeText = CanvasTool.InstantiateText("timer", transfrom, Vector3.zero);
                    timeText.fontSize = 20;
                    timeText.alignment = TextAnchor.MiddleCenter;
                    mask.color = new Color(0, 0, 0, 0.33f);
                    mask.type = Image.Type.Filled;
                    mask.fillMethod = Image.FillMethod.Radial360;
                    mask.fillOrigin = 2;
                    mask.fillClockwise = false;
                    mask.fillAmount = 0;
                } // end Icon

                public void Update() {
                    if (null == timer) return;
                    // end if
                    timeText.text = timer.timer.ToString("f1");
                    mask.fillAmount = timer.schedule;
                } // end Update

                public void Dispose() {
                    if (null != mask) UnityEngine.Object.Destroy(mask.gameObject);
                    // end if
                    if (null != icon) UnityEngine.Object.Destroy(icon.gameObject);
                    // end if
                    if(null != timeText) UnityEngine.Object.Destroy(timeText.gameObject);
                } // end Dispose
            } // end class UISkill
        } // end namespace
    } // end namespace
} // end namespace Custom 

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
using Framework.Manager;
using Solider.Model.Interface;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UISkill : IDisposable {
                private Image icon;
                private Image mask;
                private Text timeText;
                private RectTransform transfrom;
                private ISkillModle modle;

                public UISkill(ISkillModle modle, RectTransform parent, Vector3 localPos, Vector2 iconSize) {
                    this.modle = modle;
                    transfrom = CanvasTool.InstantiateEmptyUI("uiskill", parent, localPos).GetComponent<RectTransform>();
                    icon = CanvasTool.InstantiateImage(modle.info.id, transfrom, Vector3.zero, iconSize);
                    icon.sprite = ResourcesTool.LoadSprite(modle.info.spritepath);
                    icon.gameObject.AddComponent<UIButton>().AddListener(CastSkill);
                    icon.raycastTarget = true;
                    mask = CanvasTool.InstantiateImage("mask", icon.rectTransform, Vector3.zero, iconSize);
                    mask.sprite = icon.sprite;
                    timeText = CanvasTool.InstantiateText("timer", transfrom, iconSize);
                    timeText.font = Font.CreateDynamicFontFromOSFont("Arial", 32);
                    timeText.fontSize = 32;
                    timeText.color = Color.red;
                    timeText.alignment = TextAnchor.MiddleCenter;
                    mask.color = new Color(0, 0, 0, 0.5f);
                    mask.type = Image.Type.Filled;
                    mask.fillMethod = Image.FillMethod.Radial360;
                    mask.fillOrigin = 2;
                    mask.fillClockwise = false;
                    mask.fillAmount = 0;
                } // end Icon

                public void Update() {
                    if (null == modle) return;
                    // end if
                    mask.fillAmount = modle.schedule;
                    if (modle.time == 0) {
                        timeText.text = "";
                    } else {
                        timeText.text = modle.time.ToString("f1");
                    } // end if
                } // end Update

                private void CastSkill() {
                    if (false == modle.isCD) return;
                    // end if
                    if (null == SceneManager.mainCharacter) return;
                    // end if
                    if (modle.layer <= SceneManager.mainCharacter.fsm.currentLayer) return;
                    // end if
                    SceneManager.mainCharacter.skill.CastSkill(modle.info.id);
                } // end CastSkill

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

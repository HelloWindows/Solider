/*******************************************************************
 * FileName: UISkillPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using Solider.Model.Interface;
using System;
using UnityEngine;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UISkillPanel : IDisposable {
                private UISkill[] skillUIArr;
                private RectTransform transform;
                private Vector3[] localPosArr = { new Vector3(212f, -220f, 0f), new Vector3(292f, -100f, 0f), new Vector3(412f, -20f, 0f) };

                public UISkillPanel(RectTransform parent) {
                    transform = CanvasTool.InstantiateEmptyUI("UISkillPanel", parent, Vector3.zero).GetComponent<RectTransform>();
                    ISkillModle[] modleArr =  SceneManager.mainCharacter.skill.GetSkillModleArray();
                    if (null == modleArr || modleArr.Length == 0 || modleArr.Length > localPosArr.Length) {
                        DebugTool.ThrowException("UISkillPanel UISkillPanel modleArr is error!!!");
                        return;
                    } // end if
                    skillUIArr = new UISkill[modleArr.Length];
                    for (int i = 0; i < modleArr.Length; i++) {
                        skillUIArr[i] = new UISkill(modleArr[i], transform, localPosArr[i], new Vector2(100, 100));
                    } // end for
                } // end UISkillPanel

                public void Update() {
                    for (int i = 0; i < skillUIArr.Length; i++) {
                        if (null == skillUIArr[i]) continue;
                        // end if
                        skillUIArr[i].Update();
                    } // end for
                } // end Update

                public void Dispose() {
                    for (int i = 0; i < skillUIArr.Length; i++) {
                        if (null == skillUIArr[i]) continue;
                        // end if
                        skillUIArr[i].Dispose();
                        skillUIArr[i] = null;
                    } // end for
                    skillUIArr = null;
                } // end Dispose
            } // end class UISkillPanel
        } // end namespace Custom
    } // end namespace UI
} // end namespace Solider 

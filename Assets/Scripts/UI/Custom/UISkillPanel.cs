/*******************************************************************
 * FileName: UISkillPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Manager;
using Framework.Tools;
using Solider.Config.Interface;
using Solider.ModelData.Interface;
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
                    string[] idArr;
                    SceneManager.mainCharacter.skill.GetSkillIDArray(out idArr);
                    if (null == idArr || idArr.Length == 0 || idArr.Length > localPosArr.Length) {
                        DebugTool.ThrowException("UISkillPanel UISkillPanel iaArr is null!!!");
                        return;
                    } // end if
                    skillUIArr = new UISkill[idArr.Length];
                    for (int i = 0; i < idArr.Length; i++) {
                        ISkillInfo info;
                        if (false == Configs.iconConfig.TryGetSkillInfo(idArr[i], out info)) return;
                        // end if
                        if (null == info) return;
                        // end if
                        ITimer timer;
                        if (false == SceneManager.mainCharacter.skill.GetTimer(idArr[i], out timer)) {
                            DebugTool.ThrowException("UISkillPanel timer is null!!! ID:" + idArr[i]);
                        } // end if
                        skillUIArr[i] = new UISkill(info, timer, transform, localPosArr[i], new Vector2(100, 100));
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

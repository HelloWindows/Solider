/*******************************************************************
 * FileName: UISkillPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Tools;
using Solider.Config.Interface;
using System;
using UnityEngine;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UISkillPanel : IDisposable {
                private UISkill[] skillUIArr;
                private RectTransform transform;

                public UISkillPanel(params string[] idArr) {
                    if (null == idArr || idArr.Length == 0) {
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
                        skillUIArr[i] = new UISkill(info, transform, new Vector2(100, 100));
                    } // end for
                } // end UISkillPanel

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

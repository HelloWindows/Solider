/*******************************************************************
 * FileName: CharacterSkill.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.ModelData.Interface;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        public class CharacterSkill : ICharacterSkill {
            #region /******** 技能计时器 *******/
            private class SkillTimer : ITimer {
                public ISkillInfo info { get; private set; }
                public bool isCD { get { return timer == 0; } }
                public float schedule { get { return timer / CD; } }
                public float timer { get; private set; }
                public float CD { get; private set; }

                public SkillTimer(ISkillInfo info) {
                    this.info = info;
                    timer = 0;
                    CD = info.CD;
                } // end SkillTimer

                public void Cooldown(float coolTime) {
                    if (isCD) return;
                    // end if
                    timer = MathTool.LimitZero(timer - coolTime);
                } // end Cooldown

                public void Cast(bool ignoreCD) {
                    if (ignoreCD) return;
                    // end if
                    timer = CD;
                } // end Cast
            } // end class SkillTimer
            #endregion
            private List<SkillTimer> skillList;

            public CharacterSkill() {
                skillList = new List<SkillTimer>();
            } // end CharacterSkill

            public void Update(float deltaTime) {
                for (int i = 0; i < skillList.Count; i++) {
                    skillList[i].Cooldown(deltaTime);
                } // end for
            } // end Update

            public void PushSkill(string id) {
                ISkillInfo info;
                if (false == Configs.iconConfig.TryGetSkillInfo(id, out info)) return;
                // end if
                if (null == info) return;
                // end if
                for (int i = 0; i < skillList.Count; i++)
                    if (skillList[i].info.id == id) {
                        DebugTool.ThrowException("CharacterSkill PushSkill id is repeat!!! ID:" + id);
                        return;
                    } // end if
                // end for         
                skillList.Add(new SkillTimer(info));
            } // end PushSkill

            public bool CastSkill(string id, bool ignoreCD = false) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].info.id != id) continue;
                    // end if
                    if (false == skillList[i].isCD) return false;
                    // end if
                    skillList[i].Cast(ignoreCD);
                    return true;
                } // end for
                return false;
            } // end CastSkill

            public ITimer[] GetTimerArray(params string[] idArray) {
                if (null == idArray || 0 == idArray.Length) return null;
                // end if
                ITimer[] timerArr = new ITimer[idArray.Length];
                for (int i = 0; i < idArray.Length; i++) {
                    for (int j = 0; j < skillList.Count; i++) {
                    } // end for
                } // end for
                return timerArr;
            } // end GetTimerArray
        } // end class CharacterSkill 
    } // end namespace Character
} // end namespace Solider
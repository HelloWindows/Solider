/*******************************************************************
 * FileName: CharacterSkill.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Solider.Config.Icon;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        public class CharacterSkill {
            #region /******** 技能计时器 *******/
            private class SkillTimer {
                public string id { get; private set; }
                public bool isCooldown { get { return timer == 0; } }
                public float schedule { get { return timer / CD; } }
                public float timer { get; private set; }
                private float CD;

                public SkillTimer(SkillInfo info) {
                    id = info.id;
                    timer = 0;
                    CD = info.CD;
                } // end SkillTimer

                public void Cooldown(float deltaTime) {
                    if (isCooldown) return;
                    // end if
                    timer -= deltaTime;
                    if (timer < 0) timer = 0;
                    // end if
                } // end Cooldown

                public void Cast() {
                    timer = 0;
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
                SkillInfo info = Configs.iconConfig.GetSkillInfo(id);
                if (null == info) return;
                // end if
                for (int i = 0; i < skillList.Count; i++)
                    if (skillList[i].id == id) return;
                    // end if
                // end for         
                skillList.Add(new SkillTimer(info));
            } // end PushSkill

            public bool CastSkill(string id) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].id != id) continue;
                    // end if
                    if (false == skillList[i].isCooldown) return false;
                    // end if
                    skillList[i].Cast();
                    return true;
                } // end for
                return false;
            } // end CastSkill

            public float GetSchedule(string id) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].id != id) continue;
                    // end if
                    return skillList[i].schedule;
                } // end for
                return 0;
            } // end GetSchedule

            public float GetTimer(string id) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].id != id) continue;
                    // end if
                    return skillList[i].timer;
                } // end for
                return 0;
            } // end GetTimer
        } // end class CharacterSkill 
    } // end namespace Character
} // end namespace Solider
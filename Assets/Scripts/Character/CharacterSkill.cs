/*******************************************************************
 * FileName: CharacterSkill.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.FSM.Interface;
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
                public float schedule { get { return timer == 0 ? 0 : timer / CD; } }
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

                public void InstantCooldown() {
                    timer = 0;
                } // end InstantCooldown

                public void Cast(bool ignoreCD) {
                    if (ignoreCD) return;
                    // end if
                    timer = CD;
                } // end Cast
            } // end class SkillTimer
            #endregion
            private ICharacter character;
            private List<SkillTimer> skillList;
            private Dictionary<string, ISkillFSMState> stateDict;

            public CharacterSkill(ICharacter character) {
                this.character = character;
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
                    ISkillFSMState skillState;
                    if (false == stateDict.TryGetValue(id, out skillState)) {
                        DebugTool.ThrowException("CharacterSkill CastSkill id is not exsit!!! ID:" + id);
                        return false;
                    } // end if
                    IFSMState state = skillState.CreateInstance(character, skillList[i].info);
                    character.fsm.PerformTransition(state);
                    return true;
                } // end for
                return false;
            } // end CastSkill

            public ITimer GetTimer(string id) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].info.id != id) continue;
                    // end if
                    return skillList[i];
                } // end for
                return null;
            } // end GetTimerArray

            public void Cooldown(string id, float coolTime) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].info.id != id) continue;
                    // end if
                    skillList[i].Cooldown(coolTime);
                    break;
                } // end for
            } // end Cooldown

            public void CooldownAll(float coolTime) {
                for (int i = 0; i < skillList.Count; i++) {
                    skillList[i].Cooldown(coolTime);
                } // end for
            } // end CooldownAll

            public void InstantCooldown(string id) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].info.id != id) continue;
                    // end if
                    skillList[i].InstantCooldown();
                    break;
                } // end for
            } // end InstantCooldown

            public void InstantCooldownAll() {
                for (int i = 0; i < skillList.Count; i++) {
                    skillList[i].InstantCooldown();
                } // end for
            } // end InstantCooldownAll

            public void InstantCooldownAll(params string[] ignoreIDList) {
                for (int i = 0; i < skillList.Count; i++) {
                    bool isIgnore = false;
                    for (int j = 0; j < ignoreIDList.Length; i++) {
                        if (skillList[i].info.id == ignoreIDList[j]) {
                            isIgnore = true;
                            break;
                        } // end if
                    } // end for
                    if (isIgnore) continue;
                    // end if
                    skillList[i].InstantCooldown();
                } // end for
            } // end InstantCooldownAlls
        } // end class CharacterSkill 
    } // end namespace Character
} // end namespace Solider
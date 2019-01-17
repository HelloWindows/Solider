/*******************************************************************
 * FileName: CharacterSkill.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Tools;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.Model.Interface;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        public class CharacterSkill : ICharacterSkill {
            #region /******** 技能数据 *******/
            private class SkillModle : ISkillModle {
                public int layer { get { return state.layer; } }
                public ISkillInfo info { get; private set; }
                public bool isCD { get { return time == 0; } }
                public float schedule { get { return time == 0 ? 0 : time / CD; } }
                public float time { get; private set; }
                public float CD { get; private set; }
                public ICharacterState state { get; private set; }

                public SkillModle(ISkillInfo info, ICharacterState state) {
                    this.info = info;
                    this.state = state;
                    time = 0;
                    CD = info.CD;
                } // end SkillModle

                public void Cooldown(float coolTime) {
                    if (isCD) return;
                    // end if
                    time = MathTool.LimitZero(time - coolTime);
                } // end Cooldown

                public void InstantCooldown() {
                    time = 0;
                } // end InstantCooldown

                public void Cast(bool ignoreCD) {
                    if (ignoreCD) return;
                    // end if
                    time = CD;
                } // end Cast
            } // end class SkillModle
            #endregion
            private ICharacter character;
            private List<SkillModle> skillList;

            public CharacterSkill(ICharacter character) {
                this.character = character;
                skillList = new List<SkillModle>();
                PushSkill("500201");
                PushSkill("500202");
                PushSkill("500203");
            } // end CharacterSkill

            public void Update() {
                for (int i = 0; i < skillList.Count; i++) {
                    skillList[i].Cooldown(UnityEngine.Time.deltaTime);
                } // end for
            } // end Update

            public void PushSkill(string id) {
                ISkillInfo info;
                if (false == Configs.iconConfig.TryGetSkillInfo(id, out info)) {
                    DebugTool.ThrowException("CharacterSkill PushSkill IconConfig is don't configure!");
                    return;
                } // end if
                if (null == info) {
                    DebugTool.ThrowException("CharacterSkill PushSkill IconConfig configure error!!! ID:" + id);
                    return;
                } // end if
                for (int i = 0; i < skillList.Count; i++)
                    if (skillList[i].info.id == id) {
                        DebugTool.ThrowException("CharacterSkill PushSkill id is repeat!!! ID:" + id);
                        return;
                    } // end if
                // end for         
                SkillStateProxy proxy = CharacterStateProxy.GetSkillStateProxy(id);
                if (null == proxy) {
                    DebugTool.ThrowException("CharacterSkill PushSkill CharacterStateProxy configure error!!! ID:" + id);
                    return;
                } // end if
                ICharacterState state = proxy(character, info);
                if (null == state) {
                    DebugTool.ThrowException("CharacterSkill PushSkill character state is null!!! ID:" + id);
                    return;
                } // end if
                skillList.Add(new SkillModle(info, state));
            } // end PushSkill

            public ISkillModle[] GetSkillModleArray() {
                if (0 == skillList.Count) return null;
                // end if
                ISkillModle[] modleArr = new ISkillModle[skillList.Count];
                for (int i = 0; i < skillList.Count; i++) {
                    modleArr[i] = skillList[i];
                } // end for
                return modleArr;
            } // end GetSkillIDArray

            public bool CastSkill(string id, bool ignoreCD = false) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].info.id != id) continue;
                    // end if
                    if (false == skillList[i].isCD) return false;
                    // end if            
                    if (false == character.fsm.TransitionOnLayer(skillList[i].state)) return false;
                    // end if
                    skillList[i].Cast(ignoreCD);
                    return true;
                } // end for
                return false;
            } // end CastSkill

            public bool GetTimer(string id, out ITimer timer) {
                for (int i = 0; i < skillList.Count; i++) {
                    if (skillList[i].info.id != id) continue;
                    // end if
                    timer = skillList[i];
                    return true;
                } // end for
                timer = null;
                return false;
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
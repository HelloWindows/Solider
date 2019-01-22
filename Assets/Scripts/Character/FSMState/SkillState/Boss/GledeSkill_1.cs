/*******************************************************************
 * FileName: GledeSkill_1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.ModelData.Data;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class GledeSkill_1 : ICharacterState {
                public const string ID = "502002";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new GledeSkill_1(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private ICharacter character;
                private ISkillInfo info;
                private bool isFlight;

                private GledeSkill_1(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end GledeSkill_1

                public void DoBeforeEntering() {
                    isFlight = false;
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill1");
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition("die");
                        return;
                    } // end if
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("idle");
                        return;
                    } // end if
                    Flight();
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                private void Flight() {
                    if (isFlight) return;
                    // end if
                    AnimationState state = character.avatar.GetCurrentState("skill1");
                    if (null == state || state.normalizedTime < 0.5f) return;
                    // end if
                    isFlight = true;
                    if (null == character.info.lockCharacter) return;
                    // end if
                    if (Vector3.Distance(character.info.lockCharacter.position, (character.position + character.forward)) > 1) return;
                    // end if
                    DamageData damage = new DamageData(character, info);
                    character.info.lockCharacter.info.UnderAttack(damage);
                } // end Flight
            } // end class GledeSkill_1 
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider
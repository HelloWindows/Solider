/*******************************************************************
 * FileName: SfixSkill_1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.ModelData.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class SfixSkill_1 : IFSMState, ICharacterState {
                public const string ID = "502001";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new SfixSkill_1(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private ICharacter character;
                private ISkillInfo info;
                private float speed;
                private float lastNormalizeTime;
                private UnityAction m_action;

                private SfixSkill_1(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end SfixSkill_1

                public void DoBeforeEntering() {
                    speed = 10f;
                    lastNormalizeTime = 0f;
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill1_1");
                    m_action = LookTarget;
                } // end DoBeforeEntering

                public void Reason() {
                    if (null == m_action || false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition("die");
                        return;
                    } // end if
                    m_action();
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                private void LookTarget() {
                    if (false == character.avatar.IsPlaying("skill1_1")) {
                        character.avatar.Play("skill1_2");
                        m_action = Flight;
                        return;
                    } // end if
                    if (null == character.info.lockCharacter) return;
                    // end if
                    character.move.LookAt(character.info.lockCharacter.position);
                    speed = Vector3.Distance(character.position, character.info.lockCharacter.position) - 2;
                } // end LookTarget

                private void Flight() {
                    AnimationState state = character.avatar.GetCurrentState("skill1_2");
                    if (null == state) {
                        character.avatar.Play("skill1_3");
                        m_action = Finish;
                        if (null == character.info.lockCharacter) return;
                        // end if
                        if (Vector3.Distance(character.info.lockCharacter.position, (character.position + character.forward)) > 1) return;
                        // end if
                        DamageData damage = new DamageData(character, info);
                        character.info.lockCharacter.info.UnderAttack(damage);
                    } else {
                        float smooth = state.normalizedTime - lastNormalizeTime;
                        lastNormalizeTime = state.normalizedTime;
                        character.move.MoveForward(speed * smooth / Time.deltaTime);                     
                    } // end if
                } // end ShowArrow

                private void Finish() {
                    if (character.avatar.isPlaying) return;
                    // end if
                    character.fsm.PerformTransition("idle");
                    m_action = null;
                } // end FlightArrow
            } // end class SfixSkill_1
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

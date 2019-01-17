/*******************************************************************
 * FileName: ArcherSkill1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.ModelData.Data;
using Solider.Widget;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class ArcherSkill1 : ICharacterState {
                public const string ID = "500201";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new ArcherSkill1(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private float step;
                private ICharacter character;
                private ISkillInfo info;
                private bool isFlight;
                private bool isFinish;

                private ArcherSkill1(ICharacter character, ISkillInfo info) {
                    step = 2f;
                    this.character = character;
                    this.info = info;
                } // end ArcherSkill1

                public void DoBeforeEntering() {
                    isFlight = false;
                    isFinish = false;
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill1_1");
                } // end DoBeforeEntering

                public void Reason() {
                    if (character.avatar.isPlaying) return;
                    // end if
                    if (isFinish) {
                        character.fsm.PerformTransition("wait");
                    } else {
                        character.avatar.Play("skill1_2");
                        isFinish = true;
                    } // end if
                } // end Reason

                public void Act() {
                    if (isFlight) return;
                    // end if
                    MoveBackward();
                    FlightArrow();
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                private void MoveBackward() {
                    AnimationState state = character.avatar.GetCurrentState("skill1_1");
                    if (null == state) return;
                    // end if
                    character.move.MoveBackward(step);
                } // end MoveBackward

                private void FlightArrow() {
                    AnimationState state = character.avatar.GetCurrentState("skill1_2");
                    if (null == state || state.normalizedTime < 0.3f) return;
                    // end if
                    isFlight = true;
                    DamageData damage = new DamageData(character);
                    PierceArrow arrow = Object.Instantiate(ResourcesTool.LoadPrefab("pierce_arrow")).AddComponent<PierceArrow>();
                    arrow.transform.position = character.position + Vector3.up * 0.8f;
                    arrow.transform.rotation = character.rotation;
                    arrow.SetDamage(damage);
                } // end FlightArrow
            } // end class ArcherSkill1
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

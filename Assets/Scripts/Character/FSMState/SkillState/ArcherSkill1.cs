/*******************************************************************
 * FileName: ArcherSkill1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class ArcherSkill1 : ICharacterState {
                public string id { get { return "600201"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private float step;
                private ICharacter character;
                private ISkillInfo info;

                public ArcherSkill1(ICharacter character, ISkillInfo info) {
                    step = 2f;
                    this.character = character;
                    this.info = info;
                } // end ArcherSkill1

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.PlayQueued(new string[] { "skill1_1", "skill1_2" });
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                    AnimationState state = character.avatar.GetCurrentState("skill1_1");
                    if (null == state) return;
                    // end if
                    if (state.normalizedTime < 0.5f) {
                        character.move.StepForward(step, Time.deltaTime);
                    } else {
                        character.move.StepBackward(step, Time.deltaTime);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class ArcherSkill1
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

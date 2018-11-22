﻿/*******************************************************************
 * FileName: ArcherSkill1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherSkill1 : IFSMState {
                public string name { get { return "archer_skill1"; } }
                private float step;
                private ICharacter character;

                public ArcherSkill1(ICharacter character) {
                    step = 2f;
                    this.character = character;
                } // end ArcherCrit

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("archer_skill1");
                    character.avatar.PlayQueued(new string[] { "skill1_1", "skill1_2" });
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition(new ArcherWait(character));
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    AnimationState state = character.avatar.GetCurrentState("skill1_1");
                    if (null == state) return;
                    // end if
                    if (state.normalizedTime < 0.5f) {
                        character.move.StepForward(step, deltaTime);
                    } else {
                        character.move.StepBackward(step, deltaTime);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class ArcherSkill1
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider 

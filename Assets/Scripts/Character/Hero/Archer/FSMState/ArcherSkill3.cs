﻿/*******************************************************************
 * FileName: ArcherSkill3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public class ArcherSkill3 : IFSMState {
                private enum SkillStep : int{
                    Step1 = 0,
                    Step2 = 1,
                    End = 2
                } // end enum SkillStep
                public string name { get; private set; }
                private bool[] signArr;
                private ICharacter character;
                private SkillStep skillStep;

                public ArcherSkill3(string name, ICharacter character) {
                    this.name = name;
                    signArr = new bool[18];
                    this.character = character;
                } // end ArcherCrit

                public void DoBeforeEntering() {
                    skillStep = SkillStep.Step1;
                    character.audio.PlaySoundCache("skill3");
                    character.avatar.Play("skill3_1");
                    for (int i = 0; i < signArr.Length; i++) {
                        signArr[i] = false;
                    } // end if
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (skillStep != SkillStep.End) {
                        switch (skillStep) {
                            default:
                                skillStep = SkillStep.End;
                                break;
                            case SkillStep.Step1:
                                if (true == character.avatar.isPlaying) return;
                                // end if
                                skillStep = SkillStep.Step2;
                                character.avatar.Play("skill3_2");
                                break;

                            case SkillStep.Step2:
                                AnimationState state = character.avatar.GetCurrentState("skill3_2");
                                if (null == state || state.normalizedTime < signArr.Length) return;
                                // end if
                                skillStep = SkillStep.End;
                                character.avatar.Play("skill3_3");
                                break;
                        } // end switch
                        return;
                    } // end if

                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    if (skillStep != SkillStep.Step2) return;
                    // end if
                    AnimationState state = character.avatar.GetCurrentState("skill3_2");
                    if (null == state) return;
                    // end if
                    int index = (int)state.normalizedTime;
                    if (index < 0 || index >= signArr.Length) return;
                    // end if
                    if (true == signArr[index]) return;
                    // end if
                    signArr[index] = true;
                    Debug.Log("Shoot: " + index);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                public void DoRemove() {
                } // end DoRemove
            } // end class ArcherSkill3
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 

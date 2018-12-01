/*******************************************************************
 * FileName: ArcherSkill3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class ArcherSkill3 : IFSMState, ICharacterFSMState {
                private enum SkillStep : int{
                    Step1 = 0,
                    Step2 = 1,
                    End = 2
                } // end enum SkillStep
                public string id { get { return "600203"; } }
                private bool[] signArr;
                private ICharacter character;
                private SkillStep skillStep;
                private string soundPath { get { return "Character/Hero/Archer/Sound/archer_skill3"; } }

                public ArcherSkill3(ICharacter character) {
                    signArr = new bool[18];
                    this.character = character;
                } // end ArcherSkill1

                public IFSMState CreateInstance(ICharacter character) {
                    if (null == character) {
                        DebugTool.ThrowException("ArcherSkill3 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new ArcherSkill3(character);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    skillStep = SkillStep.Step1;
                    character.audio.PlaySoundCacheForPath(id, soundPath);
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
            } // end class ArcherSkill3
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

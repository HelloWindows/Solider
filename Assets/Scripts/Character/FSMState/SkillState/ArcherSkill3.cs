/*******************************************************************
 * FileName: ArcherSkill3.cs
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
            public class ArcherSkill3 : ICharacterState {
                public const string ID = "500203";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new ArcherSkill3(character, info);
                } // end CreateInstance

                private enum SkillStep : int{
                    Step1 = 0,
                    Step2 = 1,
                    End = 2
                } // end enum SkillStep
                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private bool[] signArr;
                private ICharacter character;
                private SkillStep skillStep;
                private ISkillInfo info;

                private ArcherSkill3(ICharacter character, ISkillInfo info) {
                    signArr = new bool[18];
                    this.character = character;
                    this.info = info;
                } // end ArcherSkill1

                public void DoBeforeEntering() {
                    skillStep = SkillStep.Step1;
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill3_1");
                    for (int i = 0; i < signArr.Length; i++) {
                        signArr[i] = false;
                    } // end if
                } // end DoBeforeEntering

                public void Reason() {
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

                public void Act() {
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
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class ArcherSkill3
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

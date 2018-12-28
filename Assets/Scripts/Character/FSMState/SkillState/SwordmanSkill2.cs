/*******************************************************************
 * FileName: SwordmanSkill2.cs
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
            public class SwordmanSkill2 : ICharacterState {
                public const string ID = "500002";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    IMainCharacter mainCharacter = character as IMainCharacter;
                    if (null == mainCharacter) return null;
                    // end if
                    return new SwordmanSkill2(mainCharacter, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private IMainCharacter character;
                private ISkillInfo info;

                private SwordmanSkill2(IMainCharacter horeCharacter, ISkillInfo info) {
                    character = horeCharacter;
                    this.info = info;
                } // end SwordmanSkill2

                public void DoBeforeEntering() {
                    character.avatar.Play("skill2");
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                } // end DoBeforeEntering

                public void Reason() {
                    AnimationState state = character.avatar.GetCurrentState("skill2");
                    if (null != state && state.normalizedTime >= 7) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                    character.move.StepForward(character.input.joystickDir, Time.deltaTime);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill2
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

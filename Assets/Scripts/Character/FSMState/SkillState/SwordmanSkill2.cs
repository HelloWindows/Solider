/*******************************************************************
 * FileName: SwordmanSkill2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Config.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class SwordmanSkill2 : IFSMState, ISkillFSMState {
                public string id { get { return "500002"; } }
                private IMainCharacter character;
                private ISkillInfo info;


                public SwordmanSkill2(IMainCharacter horeCharacter, ISkillInfo info) {
                    character = horeCharacter;
                    this.info = info;
                } // end SwordmanSkill2

                public IFSMState CreateInstance(ICharacter character, ISkillInfo info) {
                    IMainCharacter horeCharacter = character as IMainCharacter;
                    if (null == horeCharacter) {
                        DebugTool.ThrowException("SwordmanSkill2 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    if (null == info) {
                        DebugTool.ThrowException("SwordmanSkill2 CreateInstance SkillInfo is null!!!");
                        return null;
                    } // end if
                    return new SwordmanSkill2(horeCharacter, info);
                } // end CreateInstance

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

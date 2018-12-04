﻿/*******************************************************************
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
                public string id { get { return "600002"; } }
                private IHeroCharacter character;
                private static ICharacterFSMStateInfo info;


                public SwordmanSkill2(IHeroCharacter character) {
                    this.character = character;
                    if (null == info)
                        info = Configs.characterFSMStateConfig.GetCharacterFSMStateInfo(id);
                    // end if
                } // end SwordmanSkill2

                public IFSMState CreateInstance(ICharacter character, ISkillInfo skillInfo) {
                    IHeroCharacter horeCharacter = character as IHeroCharacter;
                    if (null == horeCharacter) {
                        DebugTool.ThrowException("SwordmanSkill2 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new SwordmanSkill2(horeCharacter);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.avatar.Play("skill2");
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    AnimationState state = character.avatar.GetCurrentState("skill2");
                    if (null != state && state.normalizedTime >= 7) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    character.move.StepForward(character.input.joystickDir, deltaTime);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill2
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

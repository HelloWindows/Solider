/*******************************************************************
 * FileName: ArcherSkill1.cs
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
            public class ArcherSkill1 : IFSMState, ICharacterFSMState {
                public string id { get { return "600201"; } }
                private float step;
                private ICharacter character;
                private static ICharacterFSMStateInfo info;

                public ArcherSkill1(ICharacter character) {
                    step = 2f;
                    this.character = character;
                    if (null == info)
                        info = Configs.characterFSMStateConfig.GetCharacterFSMStateInfo(id);
                    // end if
                } // end ArcherSkill1

                public IFSMState CreateInstance(ICharacter character) {
                    if (null == character) {
                        DebugTool.ThrowException("ArcherSkill1 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new ArcherSkill1(character);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.PlayQueued(new string[] { "skill1_1", "skill1_2" });
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
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
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

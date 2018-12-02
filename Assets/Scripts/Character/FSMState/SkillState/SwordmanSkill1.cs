/*******************************************************************
 * FileName: SwordmanSkill1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Config.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class SwordmanSkill1 : IFSMState, ICharacterFSMState {
                public string id { get { return "600001"; } }
                private float step;
                private ICharacter character;
                private static ICharacterFSMStateInfo info;

                public SwordmanSkill1(ICharacter character) {
                    step = 3f;
                    this.character = character;
                    if (null == info)
                        info = Configs.characterFSMStateConfig.GetCharacterFSMStateInfo(id);
                    // end if
                } // end SwordmanSkill1

                public IFSMState CreateInstance(ICharacter character) {
                    if (null == character) {
                        DebugTool.ThrowException("SwordmanSkill1 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new SwordmanSkill1(character);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.avatar.Play("skill1");
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    character.move.StepForward(step, deltaTime);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill1
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

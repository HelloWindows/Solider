/*******************************************************************
 * FileName: SwordmanSkill3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class SwordmanSkill3 : IFSMState, ICharacterFSMState {
                public string id { get { return "600003"; } }
                private ICharacter character;
                private string soundPath { get { return "Character/Hero/Swordman/Sound/swordman_skill_3"; } }

                public SwordmanSkill3( ICharacter character) {
                    this.character = character;
                } // end SwordmanSkill3

                public IFSMState CreateInstance(ICharacter character) {
                    if (null == character) {
                        DebugTool.ThrowException("SwordmanSkill3 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new SwordmanSkill3(character);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.avatar.Play("skill3");
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill3
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

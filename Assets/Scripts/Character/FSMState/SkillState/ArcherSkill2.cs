/*******************************************************************
 * FileName: ArcherSkill2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class ArcherSkill2 : IFSMState {
                public string id { get { return "archer_skill2"; } }
                private ICharacter character;

                public ArcherSkill2(ICharacter character) {
                    this.character = character;
                } // end ArcherCrit

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("archer_skill2");
                    character.avatar.PlayQueued(new string[] { "skill2_1", "skill2_2", "skill2_3" });
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
            } // end class ArcherSkill2
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

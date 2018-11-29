/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class SwordmanSkill3 : IFSMState {
                public string id { get { return "skill3"; } }
                private ICharacter character;

                public SwordmanSkill3( ICharacter character) {
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    character.avatar.Play("skill3");
                    character.audio.PlaySoundCache("swordman_skill_3");
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

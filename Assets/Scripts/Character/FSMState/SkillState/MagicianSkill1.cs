/*******************************************************************
 * FileName: MagicianSkill1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class MagicianSkill1 : IFSMState {
                public string id { get { return "magician_skill1"; } }
                private ICharacter character;

                public MagicianSkill1(ICharacter character) {
                    this.character = character;
                } // end MagicianAttack2

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("magician_skill1");
                    character.avatar.Play("skill1");
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
            } // end class MagicianSkill1 
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider
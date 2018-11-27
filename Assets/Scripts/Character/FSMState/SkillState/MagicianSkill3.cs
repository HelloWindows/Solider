/*******************************************************************
 * FileName: MagicianSkill3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianSkill3 : IFSMState {
                public string id { get { return "magician_skill2"; } }
                private ICharacter character;

                public MagicianSkill3(ICharacter character) {
                    this.character = character;
                } // end MagicianSkill3

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("magician_skill3");
                    character.avatar.Play("skill3");
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
            } // end class MagicianSkill3 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider
/*******************************************************************
 * FileName: ArcherDie.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherDie : IFSMState {
                public string name { get { return "die"; } }
                private ICharacter character;

                public ArcherDie(ICharacter character) {
                    this.character = character;
                } // end ArcherDie

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.audio.PlaySoundCache("archer_die");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanDie 
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider
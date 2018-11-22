/*******************************************************************
 * FileName: SwordmanDie.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Swordman {
            public class SwordmanDie : IFSMState {
                public string name { get { return "die"; } }
                private ICharacter character;

                public SwordmanDie(ICharacter character) {
                    this.character = character;
                } // end SwordmanDie

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.audio.PlaySoundCache("swordman_die");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanDie 
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Solider
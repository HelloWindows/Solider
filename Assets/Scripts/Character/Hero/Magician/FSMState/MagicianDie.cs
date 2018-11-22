/*******************************************************************
 * FileName: MagicianDie.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianDie : IFSMState {
                public string name { get { return "die"; } }
                private ICharacter character;

                public MagicianDie(ICharacter character) {
                    this.character = character;
                } // end MagicianDie

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.audio.PlaySoundCache("magician_die");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MagicianDie 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider
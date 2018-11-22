/*******************************************************************
 * FileName: MagicianIdle.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianIdle : IFSMState {
                public string name { get { return "idle"; } }
                private ICharacter character;

                public MagicianIdle(ICharacter character) {
                    this.character = character;
                } // end MagicianIdle

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.surface.FurlWeapon();
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.input.joystickDir.magnitude > 0f) {
                        character.fsm.PerformTransition(new MagicianWalk(character));
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MagicianIdle
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider 

/*******************************************************************
 * FileName: ArcherIdle.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherIdle : IFSMState {
                public string name { get { return "idle"; } }
                private ICharacter character;

                public ArcherIdle(ICharacter character) {
                    this.character = character;
                } // end ArcherIdle

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.surface.FurlWeapon();
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.input.joystickDir.magnitude > 0f) {
                        character.fsm.PerformTransition(new ArcherWalk(character));
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class ArcherIdle
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider 

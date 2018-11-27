/*******************************************************************
 * FileName: HoreIdle.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Hore {
            public class HoreIdle : IFSMState {
                public string id { get { return "idle"; } }
                private string anim { get { return "idle"; } }
                private ICharacter character;

                public HoreIdle(ICharacter character) {
                    this.character = character;
                } // end HoreIdle

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                    character.surface.FurlWeapon();
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.input.joystickDir.magnitude > 0f) {
                        character.fsm.PerformTransition("walk");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class HoreIdle
        } // end namespace Hore
    } // end namespace Character
} // end namespace Solider 

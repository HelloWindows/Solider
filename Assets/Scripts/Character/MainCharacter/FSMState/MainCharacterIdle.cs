/*******************************************************************
 * FileName: MainCharacterIdle.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterIdle : IFSMState {
                public string id { get { return "idle"; } }
                private string anim { get { return "idle"; } }
                private IMainCharacter character;

                public MainCharacterIdle(IMainCharacter character) {
                    this.character = character;
                } // end MainCharacterIdle

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
            } // end class MainCharacterIdle
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

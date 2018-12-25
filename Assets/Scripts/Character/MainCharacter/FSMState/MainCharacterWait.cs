/*******************************************************************
 * FileName: MainCharacterWait.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterWait : IFSMState {
                public string id { get { return "wait"; } }
                private string anim { get { return "wait"; } }
                private IMainCharacter character;

                public MainCharacterWait(IMainCharacter character) {
                    this.character = character;
                } // end MainCharacterWait

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                    character.surface.LiftWeapon();
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.input.joystickDir.magnitude > 0f) {
                        character.fsm.PerformTransition("run");
                        return;
                    } // end if
                    if (character.input.GetButtonDown(ButtonCode.ATTACK)) {
                        character.fsm.PerformTransition("attack");
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MainCharacterWait
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

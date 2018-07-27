/*******************************************************************
 * FileName: Idle.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public class HeroIdle : IFSMState {
                public string name { get; private set; }
                private IIputInfo input;
                private ICharacter character;

                public HeroIdle(string name, ICharacter character, IIputInfo input) {
                    this.name = name;
                    this.input = input;
                    this.character = character;
                } // end Idle

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.surface.FurlWeapon();
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (input.joystickDir.magnitude > 0f) {
                        character.fsm.PerformTransition("walk");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {

                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving

                public void DoRemove() {
                } // end DoRemove
            } // end class HeroIdle
        } // end namespaceFSMState
    } // end namespace Character
} // end namespace Solider 

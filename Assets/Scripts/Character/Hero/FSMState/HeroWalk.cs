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
            public class HeroWalk : IFSMState {
                public string name { get; private set; }
                private IIputInfo input;
                private ICharacter character;

                public HeroWalk(string name, ICharacter character, IIputInfo input) {
                    this.name = name;
                    this.input = input;
                    this.character = character;
                } // end Idle

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (input.joystickDir.magnitude == 0f) {
                        character.fsm.PerformTransition("idle");
                        return;
                    } // end if
                    if (input.OnButtonDown(ButtonCode.ATTACK)) {
                        character.fsm.PerformTransition("attack_1");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    character.move.MoveForward(input.joystickDir, deltaTime);
                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving
            } // end class HeroWalk
        } // end namespaceFSMState
    } // end namespace Character
} // end namespace Solider 

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
            public class HeroWait : IFSMState {
                public string name { get; private set; }
                private IIputInfo input;
                private ICharacter character;

                public HeroWait(string name, ICharacter character, IIputInfo input) {
                    this.name = name;
                    this.input = input;
                    this.character = character;
                } // end Idle

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (input.joystickDir.magnitude > 0f) {
                        character.fsm.PerformTransition("run");
                        return;
                    } // end if
                    if (input.OnButtonClick(ButtonCode.ATTACK)) {
                        character.fsm.PerformTransition("atkStep1");
                        return;
                    } // end if
                    if (input.OnButtonClick(ButtonCode.SKILL_1)) {
                        character.fsm.PerformTransition("skill1");
                        return;
                    } // end if
                    if (input.OnButtonClick(ButtonCode.SKILL_2)) {
                        character.fsm.PerformTransition("skill2");
                        return;
                    } // end if
                    if (input.OnButtonClick(ButtonCode.SKILL_3)) {
                        character.fsm.PerformTransition("skill3");
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {

                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving

                public void DoRemove() {

                } // end DoRemove
            } // end class HeroWait
        } // end namespaceFSMState
    } // end namespace Character
} // end namespace Solider 

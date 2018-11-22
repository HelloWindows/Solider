/*******************************************************************
 * FileName: MagicianWait.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianWait : IFSMState {
                public string name { get { return "wait"; } }
                private ICharacter character;

                public MagicianWait(ICharacter character) {
                    this.character = character;
                } // end MagicianWait

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.surface.LiftWeapon();
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.input.joystickDir.magnitude > 0f) {
                        character.fsm.PerformTransition(new MagicianRun(character));
                        return;
                    } // end if
                    if (character.input.GetButtonDown(ButtonCode.ATTACK)) {
                        character.fsm.PerformTransition(new MagicianAttack1(character));
                        return;
                    } // end if
                    if (character.input.GetButtonUp(ButtonCode.SKILL_1)) {
                        character.fsm.PerformTransition(new MagicianSkill1(character));
                        return;
                    } // end if
                    if (character.input.GetButtonUp(ButtonCode.SKILL_2)) {
                        character.fsm.PerformTransition(new MagicianSkill2(character));
                        return;
                    } // end if
                    if (character.input.GetButtonUp(ButtonCode.SKILL_3)) {
                        character.fsm.PerformTransition(new MagicianSkill3(character));
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MagicianWait
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider 

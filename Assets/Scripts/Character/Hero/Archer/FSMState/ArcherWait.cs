/*******************************************************************
 * FileName: ArcherWait.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherWait : IFSMState {
                public string name { get { return "wait"; } }
                private ICharacter character;

                public ArcherWait(ICharacter character) {
                    this.character = character;
                } // end ArcherWait

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.surface.LiftWeapon();
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.input.joystickDir.magnitude > 0f) {
                        character.fsm.PerformTransition(new ArcherRun(character));
                        return;
                    } // end if
                    if (character.input.GetButtonDown(ButtonCode.ATTACK)) {
                        character.fsm.PerformTransition(new ArcherAttack(character));
                        return;
                    } // end if
                    if (character.input.GetButtonUp(ButtonCode.SKILL_1)) {
                        character.fsm.PerformTransition(new ArcherSkill1(character));
                        return;
                    } // end if
                    if (character.input.GetButtonUp(ButtonCode.SKILL_2)) {
                        character.fsm.PerformTransition(new ArcherSkill2(character));
                        return;
                    } // end if
                    if (character.input.GetButtonUp(ButtonCode.SKILL_3)) {
                        character.fsm.PerformTransition(new ArcherSkill3(character));
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanWait
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider 

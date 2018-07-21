﻿/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public class SwordmanSkill2 : IFSMState {
                public string name { get; private set; }
                private IIputInfo input;
                private ICharacter character;

                public SwordmanSkill2(string name, ICharacter character, IIputInfo input) {
                    this.name = name;
                    this.input = input;
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    character.avatar.Play("skill2");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    AnimationState state = character.avatar.GetCurrentState("skill2");
                    if (null != state && state.normalizedTime >= 5) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    character.move.StepForward(input.joystickDir, deltaTime);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill2
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 
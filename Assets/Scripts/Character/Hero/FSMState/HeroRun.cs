﻿/*******************************************************************
 * FileName: Idle.cs
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
            public class HeroRun : IFSMState {
                public string name { get; private set; }
                private IIputInfo input;
                private ICharacter character;
                private float[] timeArr;
                private bool[] signArr;

                public HeroRun(string name, ICharacter character, IIputInfo input) {
                    this.name = name;
                    this.input = input;
                    this.character = character;
                    timeArr = new float[] { 0.35f, 0.8f };
                    signArr = new bool[] { false, false };
                } // end Idle

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    signArr = new bool[] { false, false };
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (input.joystickDir.magnitude == 0f) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    if (input.OnButtonDown(ButtonCode.ATTACK)) {
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
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition(name);
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    character.move.MoveForward(input.joystickDir, deltaTime);
                    AnimationState state = character.avatar.GetCurrentState(name);
                    if (null == state) return;
                    // end if
                    PlayRunEffect(0, state.normalizedTime);
                    PlayRunEffect(1, state.normalizedTime);
                } // end Act

                public void DoBeforeLeaving() {
                    
                } // end DoBeforeLeaving

                private void PlayRunEffect(int index, float normalizedTime) {
                    if (true == signArr[index] || normalizedTime < timeArr[index]) return;
                    // end if
                    signArr[index] = true;
                    character.audio.PlaySoundCache("heroRun");
                } // end PlayRunSound
            } // end class HeroWalk
        } // end namespaceFSMState
    } // end namespace Character
} // end namespace Solider 
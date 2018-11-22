﻿/*******************************************************************
 * FileName: MagicianRun.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Tools;
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianRun : IFSMState {
                public string name { get { return "run"; } }
                private ICharacter character;
                private float[] timeArr;
                private bool[] signArr;

                public MagicianRun(ICharacter character) {
                    this.character = character;
                    timeArr = new float[] { 0.35f, 0.8f };
                    signArr = new bool[] { false, false };
                } // end MagicianRun

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    for (int i = 0; i < signArr.Length; i++) {
                        signArr[i] = false;
                    } // end for
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.input.joystickDir.magnitude == 0f) {
                        character.fsm.PerformTransition(new MagicianWait(character));
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
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition(this);
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    character.move.MoveForward(character.input.joystickDir, deltaTime);
                    AnimationState state = character.avatar.GetCurrentState(name);
                    if (null == state) return;
                    // end if
                    for (int i = 0; i < signArr.Length; i++) {
                        PlayRunEffect(i, state.normalizedTime);
                    } // end for
                } // end Act

                public void DoBeforeLeaving() {           
                } // end DoBeforeLeaving

                private void PlayRunEffect(int index, float normalizedTime) {
                    if (true == signArr[index] || normalizedTime < timeArr[index]) return;
                    // end if
                    signArr[index] = true;
                    character.audio.PlaySoundCache("heroRun");
                    EffectTool.ShowEffectFromPool("runEffect", 0.5f, character.position);
                } // end PlayRunSound
            } // end class MagicianRun
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider 
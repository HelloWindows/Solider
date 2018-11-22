﻿/*******************************************************************
 * FileName: ArcherWalk.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;
using Solider.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherWalk : IFSMState {
                public string name { get { return "walk"; } }
                private ICharacter character;
                private float[] timeArr;
                private bool[] signArr;

                public ArcherWalk(ICharacter character) {
                    this.character = character;
                    timeArr = new float[] { 0.35f, 0.8f };
                    signArr = new bool[] { false, false };
                } // end ArcherWalk

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    for (int i = 0; i < signArr.Length; i++) {
                        signArr[i] = false;
                    } // end for
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.input.joystickDir.magnitude == 0f) {
                        character.fsm.PerformTransition(new ArcherIdle(character));
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
            } // end class SwordmanWalk
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider 

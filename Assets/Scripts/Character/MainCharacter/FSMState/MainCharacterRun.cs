/*******************************************************************
 * FileName: MainCharacterRun.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Tools;
using Framework.FSM.Interface;
using Solider.Character.Interface;
using UnityEngine;
using Framework.Interface.Input;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterRun : IFSMState {
                public string id { get { return "run"; } }
                private string anim { get { return "run"; } }
                private IMainCharacter character;
                private float[] timeArr;
                private bool[] signArr;
                private string soundPath;

                public MainCharacterRun(IMainCharacter character) {
                    this.character = character;
                    timeArr = new float[] { 0.35f, 0.8f };
                    signArr = new bool[] { false, false };
                    character.config.TryGetSoundPath("run", out soundPath);
                } // end MainCharacterRun

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                    for (int i = 0; i < signArr.Length; i++) {
                        signArr[i] = false;
                    } // end for
                } // end DoBeforeEntering

                public void Reason() {
                    if (character.input.joystickDir.magnitude == 0f) {
                        character.fsm.PerformTransition(new MainCharacterWait(character));
                        return;
                    } // end if
                    if (character.input.GetButtonDown(ButtonCode.ATTACK)) {
                        character.fsm.PerformTransition("attack");
                        return;
                    } // end if
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition(this);
                        return;
                    } // end if
                } // end Reason

                public void Act() {
                    character.move.MoveForward(character.input.joystickDir, Time.deltaTime);
                    AnimationState state = character.avatar.GetCurrentState(anim);
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
                    character.audio.PlaySoundCacheForPath("run", soundPath);
                    EffectTool.ShowEffectFromPool("runEffect", 0.5f, character.position);
                } // end PlayRunSound
            } // end class MainCharacterRun
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

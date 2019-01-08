/*******************************************************************
 * FileName: MainCharacterWalk.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterWalk : ICharacterState {
                public string id { get { return "walk"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "walk"; } }
                private string soundPath;
                private IMainCharacter mainCharacter;
                private float[] timeArr;
                private bool[] signArr;

                public MainCharacterWalk(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                    timeArr = new float[] { 0.35f, 0.8f };
                    signArr = new bool[] { false, false };
                    mainCharacter.config.TryGetSoundPath("run", out soundPath);
                } // end MainCharacterWalk

                public void DoBeforeEntering() {
                    mainCharacter.avatar.Play(anim);
                    for (int i = 0; i < signArr.Length; i++) {
                        signArr[i] = false;
                    } // end for
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.input.joystickDir.magnitude == 0f) {
                        mainCharacter.fsm.PerformTransition(new MainCharacterIdle(mainCharacter));
                        return;
                    } // end if
                    if (false == mainCharacter.avatar.isPlaying) {
                        mainCharacter.fsm.PerformTransition(this);
                        return;
                    } // end if
                } // end Reason

                public void Act() {
                    mainCharacter.move.MoveForward(mainCharacter.input.joystickDir, mainCharacter.info.characterData.MSP);
                    AnimationState state = mainCharacter.avatar.GetCurrentState(anim);
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
                    mainCharacter.audio.PlaySoundCacheForPath("run", soundPath);
                    EffectTool.ShowEffectFromPool("maincharachter_run_effect", 0.5f, mainCharacter.position);
                } // end PlayRunSound
            } // end class MainCharacterWalk
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

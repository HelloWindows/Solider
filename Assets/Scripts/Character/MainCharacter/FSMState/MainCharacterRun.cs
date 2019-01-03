/*******************************************************************
 * FileName: MainCharacterRun.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Tools;
using Solider.Character.Interface;
using UnityEngine;
using Framework.Interface.Input;
using Solider.Character.FSM;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterRun : ICharacterState {
                public string id { get { return "run"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "run"; } }
                private IMainCharacter mainCharacter;
                private float[] timeArr;
                private bool[] signArr;
                private string soundPath;

                public MainCharacterRun(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                    timeArr = new float[] { 0.35f, 0.8f };
                    signArr = new bool[] { false, false };
                    mainCharacter.config.TryGetSoundPath("run", out soundPath);
                } // end MainCharacterRun

                public void DoBeforeEntering() {
                    mainCharacter.avatar.Play(anim);
                    for (int i = 0; i < signArr.Length; i++) {
                        signArr[i] = false;
                    } // end for
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.input.joystickDir.magnitude == 0f) {
                        mainCharacter.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    if (false == mainCharacter.avatar.isPlaying) {
                        mainCharacter.fsm.PerformTransition(this);
                        return;
                    } // end if
                } // end Reason

                public void Act() {
                    mainCharacter.move.MoveForward(mainCharacter.input.joystickDir, Time.deltaTime);
                    AnimationState state = mainCharacter.avatar.GetCurrentState(anim);
                    if (null == state) return;
                    // end if
                    for (int i = 0; i < signArr.Length; i++) {
                        PlayRunEffect(i, state.normalizedTime);
                    } // end for
                } // end Act

                public void DoBeforeLeaving() {
                    mainCharacter.input.RemoveListener(OnClickAttack);
                } // end DoBeforeLeaving

                private void OnClickAttack(ClickEvent type) {
                    if (ClickEvent.OnAttack != type) return;
                    // end if
                    mainCharacter.fsm.PerformTransition("attack");
                } // end OnClickAttack

                private void PlayRunEffect(int index, float normalizedTime) {
                    if (true == signArr[index] || normalizedTime < timeArr[index]) return;
                    // end if
                    signArr[index] = true;
                    mainCharacter.audio.PlaySoundCacheForPath("run", soundPath);
                    EffectTool.ShowEffectFromPool("maincharachter_run_effect", 0.5f, mainCharacter.position);
                } // end PlayRunSound
            } // end class MainCharacterRun
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

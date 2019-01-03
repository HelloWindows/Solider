/*******************************************************************
 * FileName: MainCharacterWalk.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
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
                private IMainCharacter character;
                private float[] timeArr;
                private bool[] signArr;

                public MainCharacterWalk(IMainCharacter character) {
                    this.character = character;
                    timeArr = new float[] { 0.35f, 0.8f };
                    signArr = new bool[] { false, false };
                    character.config.TryGetSoundPath("run", out soundPath);
                } // end MainCharacterWalk

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                    for (int i = 0; i < signArr.Length; i++) {
                        signArr[i] = false;
                    } // end for
                } // end DoBeforeEntering

                public void Reason() {
                    if (character.input.joystickDir.magnitude == 0f) {
                        character.fsm.PerformTransition(new MainCharacterIdle(character));
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
                    EffectTool.ShowEffectFromPool("maincharachter_run_effect", 0.5f, character.position);
                } // end PlayRunSound
            } // end class MainCharacterWalk
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

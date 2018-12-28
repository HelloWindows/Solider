﻿/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanAttack1 : ICharacterState {
                public string id { get { return "attack"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private float step;
                private bool isCarom;
                private bool isFinish;
                private IMainCharacter mainCharacter;
                private ICharacterState caromState;
                private string soundPath { get { return "Character/Hero/Swordman/Sound/swordman_attack_1"; } }

                public SwordmanAttack1(IMainCharacter mainCharacter) {
                    step = 1f;
                    this.mainCharacter = mainCharacter;
                    caromState = new SwordmanAttack2(mainCharacter);
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    isCarom = false;
                    isFinish = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack1_1", "attack1_2" });
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (isFinish) {
                        mainCharacter.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    if (isCarom) {
                        mainCharacter.fsm.PerformTransition(caromState);
                    } else {
                        mainCharacter.avatar.Play("attack1_3");
                        isFinish = true;
                    } // end if
                } // end Reason

                public void Act() {
                    if (mainCharacter.avatar.IsPlaying("attack1_2"))  {
                        mainCharacter.move.StepForward(step, UnityEngine.Time.deltaTime);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                    mainCharacter.input.RemoveListener(OnClickAttack);
                } // end DoBeforeLeaving

                private void OnClickAttack(ClickEvent type) {
                    if (isCarom || ClickEvent.OnAttack != type) return;
                    // end if
                    if (mainCharacter.avatar.IsPlaying("attack1_2")) isCarom = true;
                    // end if
                } // end OnClickAttack
            } // end class SwordmanAttack1
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

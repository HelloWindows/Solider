﻿/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanAttack3 : IFSMState {
                public string id { get { return "attack3"; } }
                private float step;
                private bool isCarom;
                private IMainCharacter mainCharacter;
                private string soundPath { get { return "Character/Hero/Swordman/Sound/swordman_attack_3"; } }

                public SwordmanAttack3(IMainCharacter mainCharacter) {
                    step = 1f;
                    this.mainCharacter = mainCharacter;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    isCarom = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack3_1", "attack3_2" });
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (isCarom) {
                        mainCharacter.fsm.PerformTransition(new SwordmanAttack4(mainCharacter));
                    } else {
                        mainCharacter.avatar.Play("attack3_3");
                        mainCharacter.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                    if (mainCharacter.avatar.IsPlaying("attack3_2"))  {
                        mainCharacter.move.StepForward(step, UnityEngine.Time.deltaTime);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                    mainCharacter.input.RemoveListener(OnClickAttack);
                } // end DoBeforeLeaving

                private void OnClickAttack(ClickEvent type) {
                    if (isCarom || ClickEvent.OnAttack != type) return;
                    // end if
                    if (mainCharacter.avatar.IsPlaying("attack3_2")) isCarom = true;
                    // end if
                } // end OnClickAttack
            } // end class SwordmanAttack3
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

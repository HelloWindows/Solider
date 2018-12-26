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
                private enum AttackMode : int {
                    /// <summary>
                    /// 默认
                    /// </summary>
                    DEFAULT = 0, 
                    /// <summary>
                    /// 连击
                    /// </summary>
                    CAROM = 1,
                    /// <summary>
                    /// 失效
                    /// </summary>
                    NEGATE = 2 
                } // end enum AttackMode
                public string id { get { return "attack3"; } }
                private float step;
                private AttackMode mode;
                private IMainCharacter character;
                private string soundPath { get { return "Character/Hero/Swordman/Sound/swordman_attack_3"; } }

                public SwordmanAttack3(IMainCharacter character) {
                    step = 1f;
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    mode = AttackMode.DEFAULT;
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                    character.avatar.PlayQueued(new string[] { "attack3_1", "attack3_2" });
                } // end DoBeforeEntering

                public void Reason() {
                    if (character.avatar.isPlaying) return;
                    // end if
                    if (mode != AttackMode.NEGATE) {
                        switch (mode) {
                            default:
                                character.avatar.Play("attack3_3");
                                break;
                            case AttackMode.CAROM:
                                character.fsm.PerformTransition(new SwordmanAttack4(character));
                                break;
                        } // end switch
                        mode = AttackMode.NEGATE;
                    } else {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                    if (character.avatar.IsPlaying("attack3_2")) {
                        character.move.StepForward(step, UnityEngine.Time.deltaTime);
                        if (mode != AttackMode.DEFAULT) return;
                        // end if
                        if (character.input.GetButton(ButtonCode.ATTACK)) mode = AttackMode.CAROM;
                        // end if
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanAttack3
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 
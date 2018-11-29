﻿/*******************************************************************
 * FileName: ArcherAttack.cs
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
        namespace Hero {
            public class ArcherAttack : IFSMState {
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
                public string id { get { return "attack"; } }
                private string anim { get { return "attack"; } }
                private AttackMode mode;
                private IHeroCharacter character;

                public ArcherAttack(IHeroCharacter character) {
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    mode = AttackMode.DEFAULT;
                    character.audio.PlaySoundCache("archer_attack");
                    character.avatar.Play(anim);
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.avatar.isPlaying) return;
                    // end if
                    if (mode != AttackMode.NEGATE) {
                        switch (mode) {
                            default:
                                character.fsm.PerformTransition("wait");
                                break;
                            case AttackMode.CAROM:
                                character.fsm.PerformTransition(new ArcherAttack(character));
                                break;
                        } // end switch
                        mode = AttackMode.NEGATE;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    AnimationState state = character.avatar.GetCurrentState(anim);
                    if (null == state || state.normalizedTime < 0.5f) return;
                    // end if
                    if (character.avatar.isPlaying) {
                        if (mode != AttackMode.DEFAULT) return;
                        // end if
                        if (character.input.GetButton(ButtonCode.ATTACK)) mode = AttackMode.CAROM;
                        // end if
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving
            } // end class ArcherAttack1
        } // end namespace Hero
    } // end namespace Character
} // end namespace Solider 

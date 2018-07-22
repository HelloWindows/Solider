/*******************************************************************
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
        namespace FSMState {
            public class SwordmanAttack2 : IFSMState {
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
                public string name { get; private set; }
                private float step;
                private AttackMode mode;
                private IIputInfo input;
                private ICharacter character;

                public SwordmanAttack2(string name, ICharacter character, IIputInfo input) {
                    step = 1f;
                    this.name = name;
                    this.input = input;
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    mode = AttackMode.DEFAULT;
                    character.audio.PlaySoundCache("swordman_attack_2");
                    character.avatar.PlayQueued(new string[] { "attack_4", "attack_5" });
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.avatar.IsPlaying("attack_4")) return;
                    // end if
                    if (character.avatar.IsPlaying("attack_5")) return;
                    // end if
                    if (character.avatar.IsPlaying("attack_6")) return;
                    // end if
                    if (mode != AttackMode.NEGATE) {
                        switch (mode) {
                            default:
                                break;
                            case AttackMode.DEFAULT:
                                character.avatar.Play("attack_6");
                                break;
                            case AttackMode.CAROM:
                                character.fsm.PerformTransition("atkStep3");
                                break;
                        } // end switch
                        mode = AttackMode.NEGATE;
                    } // end if
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    if (character.avatar.IsPlaying("attack_5")) {
                        character.move.StepForward(step, deltaTime);
                        if (mode == AttackMode.NEGATE || mode == AttackMode.CAROM) return;
                        // end if
                        if (input.OnButtonClick(ButtonCode.ATTACK)) mode = AttackMode.CAROM;
                        // end if
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanAttack2
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 

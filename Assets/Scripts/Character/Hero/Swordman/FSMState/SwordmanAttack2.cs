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
        namespace Swordman {
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
                public string name { get { return "atkStep2"; } }
                private float step;
                private AttackMode mode;
                private ICharacter character;

                public SwordmanAttack2(ICharacter character) {
                    step = 1f;
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    mode = AttackMode.DEFAULT;
                    character.audio.PlaySoundCache("swordman_attack_2");
                    character.avatar.PlayQueued(new string[] { "attack2_1", "attack2_2" });
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.avatar.isPlaying) return;
                    // end if
                    if (mode != AttackMode.NEGATE) {
                        switch (mode) {
                            default:
                                character.avatar.Play("attack2_3");
                                break;
                            case AttackMode.CAROM:
                                character.fsm.PerformTransition(new SwordmanAttack3(character));
                                break;
                        } // end switch
                        mode = AttackMode.NEGATE;
                    } else {
                        character.fsm.PerformTransition(new SwordmanWait(character));
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    if (character.avatar.IsPlaying("attack2_2")) {
                        character.move.StepForward(step, deltaTime);
                        if (mode != AttackMode.DEFAULT) return;
                        // end if
                        if (character.input.GetButton(ButtonCode.ATTACK)) mode = AttackMode.CAROM;
                        // end if
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanAttack2
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Solider 

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
        namespace MainCharacter {
            public class SwordmanAttack1 : IFSMState {
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
                public string id { get { return "attack1"; } }
                private float step;
                private AttackMode mode;
                private IMainCharacter mainCharacter;
                private string soundPath { get { return "Character/Hero/Swordman/Sound/swordman_attack_1"; } }

                public SwordmanAttack1(IMainCharacter mainCharacter) {
                    step = 1f;
                    this.mainCharacter = mainCharacter;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    mode = AttackMode.DEFAULT;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack1_1", "attack1_2" });
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (mode != AttackMode.NEGATE) {
                        switch (mode) {
                            default:
                                mainCharacter.avatar.Play("attack1_3");
                                break;
                            case AttackMode.CAROM:
                                mainCharacter.fsm.PerformTransition(new SwordmanAttack2(mainCharacter));
                                break;
                        } // end switch
                        mode = AttackMode.NEGATE;
                    } else {
                        mainCharacter.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                    if (mainCharacter.avatar.IsPlaying("attack1_2")) {
                        mainCharacter.move.StepForward(step, UnityEngine.Time.deltaTime);
                        if (mode != AttackMode.DEFAULT) return;
                        // end if
                        if (mainCharacter.input.GetButton(ButtonCode.ATTACK)) mode = AttackMode.CAROM;
                        // end if
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanAttack1
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

/*******************************************************************
 * FileName: MagicianAttack2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Hero {
            public class MagicianAttack2 : IFSMState {
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
                public string id { get { return "magician_attack2"; } }
                private AttackMode mode;
                private IHeroCharacter character;

                public MagicianAttack2(IHeroCharacter character) {
                    this.character = character;
                } // end MagicianAttack2

                public void DoBeforeEntering() {
                    mode = AttackMode.DEFAULT;
                    character.audio.PlaySoundCache("magician_attack1");
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
                                character.fsm.PerformTransition(new MagicianAttack3(character));
                                break;
                        } // end switch
                        mode = AttackMode.NEGATE;
                    } else {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    if (character.avatar.IsPlaying("attack2_2")) {
                        if (mode != AttackMode.DEFAULT) return;
                        // end if
                        if (character.input.GetButton(ButtonCode.ATTACK)) mode = AttackMode.CAROM;
                        // end if
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MagicianAttack2 
        } // end namespace Hero
    } // end namespace Character
} // end namespace Solider
/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public class SwordmanAttack4 : IFSMState {
                public string name { get; private set; }
                private float step;
                private ICharacter character;

                public SwordmanAttack4(string name, ICharacter character) {
                    step = 2f;
                    this.name = name;
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("swordman_attack_4");
                    character.avatar.PlayQueued(new string[] { "attack_10", "attack_11", "attack_12" });
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (character.avatar.IsPlaying("attack_10")) return;
                    // end if
                    if (character.avatar.IsPlaying("attack_11")) return;
                    // end if
                    if (character.avatar.IsPlaying("attack_12")) return;
                    // end if
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    if (character.avatar.IsPlaying("attack_11")) {
                        character.move.StepForward(step, deltaTime);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanAttack4
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 

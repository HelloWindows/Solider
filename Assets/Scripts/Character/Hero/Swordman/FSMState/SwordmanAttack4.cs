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
                    character.avatar.PlayQueued(new string[] { "attack4_1", "attack4_2", "attack4_3" });
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    if (character.avatar.IsPlaying("attack4_2")) {
                        character.move.StepForward(step, deltaTime);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving

                public void DoRemove() {

                } // end DoRemove
            } // end class SwordmanAttack4
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 

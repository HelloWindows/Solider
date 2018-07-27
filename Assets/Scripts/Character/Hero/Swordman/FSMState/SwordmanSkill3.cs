/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public class SwordmanSkill3 : IFSMState {
                public string name { get; private set; }
                private ICharacter character;

                public SwordmanSkill3(string name, ICharacter character) {
                    this.name = name;
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    character.avatar.Play("skill3");
                    character.audio.PlaySoundCache("swordman_skill_3");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {

                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving

                public void DoRemove() {

                } // end DoRemove
            } // end class SwordmanSkill3
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 

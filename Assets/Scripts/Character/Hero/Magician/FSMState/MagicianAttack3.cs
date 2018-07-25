/*******************************************************************
 * FileName: MagicianAttack3.cs
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
            public class MagicianAttack3 : IFSMState {
                public string name { get; private set; }
                private ICharacter character;

                public MagicianAttack3(string name, ICharacter character) {
                    this.name = name;
                    this.character = character;
                } // end MagicianAttack2

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("magician_attack2");
                    character.avatar.PlayQueued(new string[] { "attack3_1", "attack3_2", "attack3_3" });
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
            } // end class MagicianAttack3 
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider
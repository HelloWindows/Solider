/*******************************************************************
 * FileName: ArcherCrit.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public class ArcherCrit : IFSMState {
                public string name { get; private set; }
                private ICharacter character;

                public ArcherCrit(string name, ICharacter character) {
                    this.name = name;
                    this.character = character;
                } // end ArcherCrit

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("archer_crit");
                    character.avatar.Play(name);
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
            } // end class ArcherCrit
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 

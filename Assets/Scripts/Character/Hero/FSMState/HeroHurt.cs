/*******************************************************************
 * FileName: HeroHurt.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public class HeroHurt : IFSMState {
                public string name { get; private set; }
                private ICharacter character;

                public HeroHurt(string name, ICharacter character) {
                    this.name = name;
                    this.character = character;
                } // end HeroHurt

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.audio.PlaySoundCache("swordman_hurt");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {

                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving

                public void DoRemove() {

                } // end DoRemove
            } // end class HeroHurt          
        } // end namespace FSMState
    } // end namespace Character
} // end namespace Solider 
/*******************************************************************
 * FileName: SwordmanHurt.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Swordman {
            public class SwordmanHurt : IFSMState {
                public string name { get { return "hurt"; } }
                private ICharacter character;

                public SwordmanHurt(ICharacter character) {
                    this.character = character;
                } // end SwordmanHurt

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.audio.PlaySoundCache("swordman_hurt");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition(new SwordmanWait(character));
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanHurt          
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Solider 
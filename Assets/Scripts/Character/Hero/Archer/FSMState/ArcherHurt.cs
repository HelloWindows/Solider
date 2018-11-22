/*******************************************************************
 * FileName: ArcherHurt.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherHurt : IFSMState {
                public string name { get { return "hurt"; } }
                private ICharacter character;

                public ArcherHurt(ICharacter character) {
                    this.character = character;
                } // end ArcherHurt

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.audio.PlaySoundCache("archer_hurt");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition(new ArcherWait(character));
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class ArcherHurt          
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider 
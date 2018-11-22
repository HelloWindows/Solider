/*******************************************************************
 * FileName: MagicianHurt.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianHurt : IFSMState {
                public string name { get { return "hurt"; } }
                private ICharacter character;

                public MagicianHurt(ICharacter character) {
                    this.character = character;
                } // end MagicianHurt

                public void DoBeforeEntering() {
                    character.avatar.Play(name);
                    character.audio.PlaySoundCache("magician_hurt");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition(new MagicianWait(character));
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MagicianHurt          
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider 
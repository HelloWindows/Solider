/*******************************************************************
 * FileName: MagicianSkill2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Magician {
            public class MagicianSkill2 : IFSMState {
                public string name { get { return "magician_skill2"; } }
                private ICharacter character;

                public MagicianSkill2(ICharacter character) {
                    this.character = character;
                } // end MagicianSkill2

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("magician_skill2");
                    character.avatar.Play("skill2");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition(new MagicianWait(character));
                    } // end if   
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MagicianSkill2 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider
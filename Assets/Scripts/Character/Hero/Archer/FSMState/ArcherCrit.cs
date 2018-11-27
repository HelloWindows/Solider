﻿/*******************************************************************
 * FileName: ArcherCrit.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherCrit : IFSMState {
                public string id { get { return "attCrit"; } }
                private string anim { get { return "attCrit"; } }
                private ICharacter character;

                public ArcherCrit(ICharacter character) {
                    this.character = character;
                } // end ArcherCrit

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("archer_crit");
                    character.avatar.Play(anim);
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
            } // end class ArcherCrit
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider 

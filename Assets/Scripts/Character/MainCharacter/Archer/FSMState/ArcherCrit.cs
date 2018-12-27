/*******************************************************************
 * FileName: ArcherCrit.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class ArcherCrit : ICharacterState {
                public string id { get { return "attCrit"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "attCrit"; } }
                private ICharacter character;
                private string soundPath { get { return "Character/Hero/Archer/Sound/archer_crit"; } }

                public ArcherCrit(ICharacter character) {
                    this.character = character;
                } // end ArcherCrit

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                    character.avatar.Play(anim);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving
            } // end class ArcherCrit
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

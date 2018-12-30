/*******************************************************************
 * FileName: MagicianAttack3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MagicianAttack3 : ICharacterState {
                public string id { get { return "attack3"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private ICharacter mainCharacter;
                private string soundPath { get { return "magician_attack_2"; } }

                public MagicianAttack3(ICharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                } // end MagicianAttack2

                public void DoBeforeEntering() {
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack3_1", "attack3_2", "attack3_3" });
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == mainCharacter.avatar.isPlaying) {
                        mainCharacter.fsm.PerformTransition("wait");
                    } // end if   
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MagicianAttack3 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
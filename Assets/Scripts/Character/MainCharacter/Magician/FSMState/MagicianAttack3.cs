/*******************************************************************
 * FileName: MagicianAttack3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MagicianAttack3 : IFSMState {
                public string id { get { return "attack3"; } }
                private ICharacter character;
                private string soundPath { get { return "Character/Hero/Magician/Sound/magician_attack_2"; } }

                public MagicianAttack3(ICharacter character) {
                    this.character = character;
                } // end MagicianAttack2

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, soundPath);
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
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
/*******************************************************************
 * FileName: MainCharacterHurt.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterHurt : IFSMState {
                public string id { get { return "hurt"; } }
                private string anim { get { return "hurt"; } }
                private ICharacter character;

                public MainCharacterHurt(ICharacter character) {
                    this.character = character;
                } // end MainCharacterHurt

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                    string soundPath;
                    if (character.config.TryGetSoundPath("hurt", out soundPath))
                        character.audio.PlaySoundCacheForPath("hurt", soundPath);
                    // end if
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MainCharacterHurt          
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 
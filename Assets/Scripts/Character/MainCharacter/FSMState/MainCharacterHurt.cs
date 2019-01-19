/*******************************************************************
 * FileName: MainCharacterHurt.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterHurt : ICharacterState {
                public string id { get { return "hurt"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "hurt"; } }
                private IMainCharacter mainCharacter;
                private string soundPath;

                public MainCharacterHurt(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                    mainCharacter.config.TryGetSoundPath("hurt", out soundPath);
                } // end MainCharacterHurt

                public void DoBeforeEntering() {
                    mainCharacter.avatar.Play(anim);
                    mainCharacter.audio.PlaySoundCacheForPath("hurt", soundPath);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == mainCharacter.avatar.isPlaying) {
                        mainCharacter.fsm.PerformTransition("wait");
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
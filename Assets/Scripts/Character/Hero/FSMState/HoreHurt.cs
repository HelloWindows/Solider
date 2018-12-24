﻿/*******************************************************************
 * FileName: HoreHurt.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Hore {
            public class HoreHurt : IFSMState {
                public string id { get { return "hurt"; } }
                private string anim { get { return "hurt"; } }
                private ICharacter character;

                public HoreHurt(ICharacter character) {
                    this.character = character;
                } // end HoreHurt

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                    string soundPath;
                    if (character.config.TryGetSoundPath("hurt", out soundPath))
                        character.audio.PlaySoundCacheForPath("hurt", soundPath);
                    // end if
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class HoreHurt          
        } // end namespace Hore
    } // end namespace Character
} // end namespace Solider 
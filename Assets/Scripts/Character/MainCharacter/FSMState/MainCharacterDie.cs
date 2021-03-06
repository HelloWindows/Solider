﻿/*******************************************************************
 * FileName: MainCharacterDie.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterDie : ICharacterState {
                public string id { get { return "die"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Highest); } }
                private string anim { get { return "die"; } }
                private ICharacter character;
                private string soundPath;

                public MainCharacterDie(ICharacter character) {
                    this.character = character;
                    character.config.TryGetSoundPath("die", out soundPath);
                } // end MainCharacterDie

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                    character.audio.PlaySoundCacheForPath("die", soundPath);
                } // end DoBeforeEntering

                public void Reason() {
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MainCharacterDie 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
/*******************************************************************
 * FileName: HoreDie.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Hore {
            public class HoreDie : IFSMState {
                public string id { get { return "die"; } }
                private string anim { get { return "die"; } }
                private string sound;
                private ICharacter character;

                public HoreDie(ICharacter character, string sound) {
                    this.sound = sound;
                    this.character = character;
                } // end ArcherDie

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                    character.audio.PlaySoundCache(sound);
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class HoreDie 
        } // end namespace Hore
    } // end namespace Character
} // end namespace Solider
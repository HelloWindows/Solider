﻿/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanAttack4 : IFSMState {
                public string id { get { return "attack3"; } }
                private float step;
                private ICharacter character;
                private string soundPath { get { return "Character/Hero/Swordman/Sound/swordman_attack_4"; } }

                public SwordmanAttack4( ICharacter character) {
                    step = 2f;
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                    character.avatar.PlayQueued(new string[] { "attack4_1", "attack4_2", "attack4_3" });
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                    if (character.avatar.IsPlaying("attack4_2")) {
                        character.move.StepForward(step, UnityEngine.Time.deltaTime);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanAttack4
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

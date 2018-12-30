/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanAttack4 : ICharacterState {
                public string id { get { return "attack3"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private float step;
                private IMainCharacter mainCharacter;
                private string soundPath { get { return "swordman_attack_4"; } }

                public SwordmanAttack4(IMainCharacter mainCharacter) {
                    step = 2f;
                    this.mainCharacter = mainCharacter;
                } // end SwordmanAttack4

                public void DoBeforeEntering() {
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack4_1", "attack4_2", "attack4_3" });
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == mainCharacter.avatar.isPlaying) {
                        mainCharacter.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                    if (mainCharacter.avatar.IsPlaying("attack4_2")) {
                        mainCharacter.move.StepForward(step, UnityEngine.Time.deltaTime);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanAttack4
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

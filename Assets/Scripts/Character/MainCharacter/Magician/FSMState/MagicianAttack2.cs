/*******************************************************************
 * FileName: MagicianAttack2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MagicianAttack2 : ICharacterState {
                public string id { get { return "attack2"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private bool isCarom;
                private IMainCharacter mainCharacter;
                private string soundPath { get { return "Character/Hero/Magician/Sound/magician_attack_1"; } }

                public MagicianAttack2(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                } // end MagicianAttack2

                public void DoBeforeEntering() {
                    isCarom = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack2_1", "attack2_2" });
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (isCarom) {
                        mainCharacter.fsm.PerformTransition(new MagicianAttack3(mainCharacter));
                    } else {
                        mainCharacter.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                    mainCharacter.input.RemoveListener(OnClickAttack);
                } // end DoBeforeLeaving

                private void OnClickAttack(ClickEvent type) {
                    if (isCarom || ClickEvent.OnAttack != type) return;
                    // end if
                    if (mainCharacter.avatar.IsPlaying("attack2_2")) isCarom = true;
                    // end if   
                } // end OnClickAttack
            } // end class MagicianAttack2 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
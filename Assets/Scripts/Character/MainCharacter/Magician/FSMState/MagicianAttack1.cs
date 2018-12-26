/*******************************************************************
 * FileName: MagicianAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Input;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MagicianAttack1 : IFSMState {
                public string id { get { return "attack"; } }
                private bool isCarom;
                private IMainCharacter mainCharacter;
                private string soundPath { get { return "Character/Hero/Magician/Sound/magician_attack_1"; } }

                public MagicianAttack1(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    isCarom = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack1_1", "attack1_2" });
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (isCarom) {
                        mainCharacter.fsm.PerformTransition(new MagicianAttack2(mainCharacter));
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
                    if (mainCharacter.avatar.IsPlaying("attack1_2")) isCarom = true;
                    // end if   
                } // end OnClickAttack
            } // end class MagicianAttack1 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
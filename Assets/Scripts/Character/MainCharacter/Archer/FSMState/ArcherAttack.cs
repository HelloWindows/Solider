/*******************************************************************
 * FileName: ArcherAttack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.Character.FSM;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class ArcherAttack : ICharacterState {
                public string id { get { return "attack"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "attack"; } }
                private bool isCarom;
                private IMainCharacter mainCharacter;
                private string soundPath { get { return "archer_attack"; } }

                public ArcherAttack(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    isCarom = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.Play(anim);
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (isCarom) {
                        mainCharacter.fsm.PerformTransition(new ArcherAttack(mainCharacter));
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
                    AnimationState state = mainCharacter.avatar.GetCurrentState(anim);
                    if (null == state || state.normalizedTime < 0.5f) return;
                    // end if
                    isCarom = true;
                } // end OnClickAttack
            } // end class ArcherAttack1
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

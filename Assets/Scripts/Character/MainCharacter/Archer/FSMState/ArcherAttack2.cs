/*******************************************************************
 * FileName: ArcherAttack2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Framework.Manager;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.ModelData.Data;
using Solider.Widget;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class ArcherAttack2 : ICharacterState {
                public string id { get { return "attack2"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "attack"; } }
                private bool isCarom;
                private bool isFinish;
                private IMainCharacter mainCharacter;
                private ICharacterState caromState;
                private string soundPath { get { return "archer_attack"; } }

                public ArcherAttack2(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                    caromState = new ArcherCrit(mainCharacter);
                } // end ArcherAttack2

                public void DoBeforeEntering() {
                    isCarom = false;
                    isFinish = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.Play(anim);
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == mainCharacter.avatar.isPlaying) {
                        if (isCarom) {
                            mainCharacter.fsm.PerformTransition(caromState);
                        } else {
                            mainCharacter.fsm.PerformTransition("wait");
                        } // end if
                        return;
                    } // end if
                    if (isFinish) return;
                    // end if
                    AnimationState state = mainCharacter.avatar.GetCurrentState(anim);
                    if (state.normalizedTime < 0.5f) return;
                    // end if
                    isFinish = true;
                    DamageData damage = new DamageData(mainCharacter);
                    Arrow arrow = InstanceMgr.GetObjectManager().GetGameObject<Arrow>("arrow");
                    arrow.transform.position = mainCharacter.position + Vector3.up * 0.8f;
                    arrow.transform.rotation = mainCharacter.rotation;
                    arrow.SetDamage(damage);
                    arrow.gameObject.SetActive(true);
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
            } // end class ArcherAttack2
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

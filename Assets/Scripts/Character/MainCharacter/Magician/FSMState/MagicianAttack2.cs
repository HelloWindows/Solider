/*******************************************************************
 * FileName: MagicianAttack2.cs
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
            public class MagicianAttack2 : ICharacterState {
                public string id { get { return "attack2"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private bool isCarom;
                private bool isFlight;
                private bool isFinish;
                private ICharacterState caromState;
                private IMainCharacter mainCharacter;
                private string soundPath { get { return "magician_attack_1"; } }

                public MagicianAttack2(IMainCharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                    caromState = new MagicianAttack3(mainCharacter);
                } // end MagicianAttack2

                public void DoBeforeEntering() {
                    isCarom = false;
                    isFlight = false;
                    isFinish = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.Play("attack2_1");
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if(Flight()) return;
                    // end if
                    if (isFinish) {
                        mainCharacter.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    if (isCarom) {
                        mainCharacter.fsm.PerformTransition(caromState);
                    } else {
                        mainCharacter.avatar.Play("attack2_3");
                        isFinish = true;
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

                private bool Flight() {
                    if (isFlight) return false;
                    // end if
                    isFlight = true;
                    mainCharacter.avatar.Play("attack2_2");
                    DamageData damage = new DamageData(mainCharacter);
                    Magic_0 arrow = InstanceMgr.GetObjectManager().GetGameObject<Magic_0>(Magic_0.poolName);
                    arrow.transform.position = mainCharacter.position + Vector3.up * 0.8f;
                    arrow.transform.rotation = mainCharacter.rotation;
                    arrow.SetDamage(damage);
                    arrow.gameObject.SetActive(true);
                    return true;
                } // end Flight
            } // end class MagicianAttack2 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
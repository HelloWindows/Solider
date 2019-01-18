/*******************************************************************
 * FileName: MagicianAttack3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Framework.FSM.Interface;
using Solider.Character.Interface;
using Solider.ModelData.Data;
using Framework.Manager;
using Solider.Widget;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MagicianAttack3 : ICharacterState {
                public string id { get { return "attack3"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private ICharacter mainCharacter;
                private bool isFlight;
                private bool isFinish;
                private string soundPath { get { return "magician_attack_2"; } }

                public MagicianAttack3(ICharacter mainCharacter) {
                    this.mainCharacter = mainCharacter;
                } // end MagicianAttack2

                public void DoBeforeEntering() {
                    isFlight = false;
                    isFinish = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.Play("attack3_1");
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (Flight()) return;
                    // end if
                    if (isFinish) {
                        mainCharacter.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    mainCharacter.avatar.Play("attack3_3");
                    isFinish = true;
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                private bool Flight() {
                    if (isFlight) return false;
                    // end if
                    isFlight = true;
                    mainCharacter.avatar.Play("attack3_2");
                    DamageData damage = new DamageData(mainCharacter);
                    Magic_1 arrow = InstanceMgr.GetObjectManager().GetGameObject<Magic_1>(Magic_1.poolName);
                    arrow.transform.position = mainCharacter.position + Vector3.up * 0.8f;
                    arrow.transform.rotation = mainCharacter.rotation;
                    arrow.SetDamage(damage);
                    arrow.gameObject.SetActive(true);
                    return true;
                } // end Flight
            } // end class MagicianAttack3 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
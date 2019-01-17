/*******************************************************************
 * FileName: ArcherCrit.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.ModelData.Data;
using Solider.Widget;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class ArcherCrit : ICharacterState {
                public string id { get { return "attCrit"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private string anim { get { return "attCrit"; } }
                private bool isFinish;
                private ICharacter character;
                private string soundPath { get { return "archer_crit"; } }

                public ArcherCrit(ICharacter character) {
                    this.character = character;
                } // end ArcherCrit

                public void DoBeforeEntering() {
                    isFinish = false;
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                    character.avatar.Play(anim);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    if (isFinish) return;
                    // end if
                    AnimationState state = character.avatar.GetCurrentState(anim);
                    if (state.normalizedTime < 0.5f) return;
                    // end if
                    isFinish = true;
                    DamageData damage = new DamageData(character);
                    damage.CertainCrit();
                    Arrow arrow = InstanceMgr.GetObjectManager().GetGameObject<Arrow>("arrow");
                    arrow.transform.position = character.position + Vector3.up * 0.8f;
                    arrow.transform.rotation = character.rotation;
                    arrow.SetDamage(damage);
                    arrow.gameObject.SetActive(true);
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {

                } // end DoBeforeLeaving
            } // end class ArcherCrit
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

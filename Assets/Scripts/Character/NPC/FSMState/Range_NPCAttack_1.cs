/*******************************************************************
 * FileName: Range_NPCAttack_1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.ModelData.Data;
using Solider.Config.Common;
using Solider.Widget;
using Framework.Manager;
using Framework.Tools;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Range_NPCAttack_1 : ICharacterState {
                public string id { get { return NPCStateID.Attack_1; } }
                public string anim { get { return "attack_1"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }

                private float reach;
                private bool isFlight;
                private string soundPath;
                private string effectPath;
                private ICharacter character;

                public Range_NPCAttack_1(ICharacter character) {
                    if (false == ParamConfig.TryGetNPCReach((NPCType)character.config.npc_type, out reach)) reach = 1;
                    // end if
                    this.character = character;
                    character.config.TryGetSoundPath(id, out soundPath);
                    if (character.config.TryGetEffectPath(id, out effectPath)) return;
                    // end if
                    effectPath = "npc_arrow";
                } // end Range_NPCAttack_1

                public void DoBeforeEntering() {
                    isFlight = false;
                    character.avatar.Play(anim);
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition(NPCStateID.Die);
                        return;
                    } // end if
                    if (false == character.avatar.isPlaying) {
                        if (null == character.info.lockCharacter) {
                            character.fsm.PerformTransition(NPCStateID.Idle);
                            return;
                        } //end if
                        if (Vector3.Distance(character.info.lockCharacter.position, character.position) < reach) {
                            character.fsm.PerformTransition(id);
                            return;
                        } // end if
                        character.fsm.PerformTransition(NPCStateID.Chase);
                        return;
                    } // end if
                    if (isFlight) return;
                    // end if
                    if (null == character.info.lockCharacter) {
                        character.fsm.PerformTransition(NPCStateID.Idle);
                        return;
                    } //end if
                    character.move.LookAt(character.info.lockCharacter.position);
                    AnimationState state = character.avatar.GetCurrentState(anim);
                    if (null == state || state.normalizedTime < 0.5f) return;
                    // end if
                    isFlight = true; 
                    if (Vector3.Distance(character.info.lockCharacter.position, character.position) > reach) return;
                    // end if
                    DamageData damage = new DamageData(character);
                    Debug.Log(effectPath);
                    NPC_Arrow arrow = InstanceMgr.GetObjectManager().GetGameObject<NPC_Arrow>(effectPath);
                    arrow.transform.position = character.position + Vector3.up * 0.5f;
                    arrow.transform.rotation = character.rotation;
                    arrow.SetDamage(effectPath, damage);
                    arrow.gameObject.SetActive(true);
                } // end Reason

                public void Act() {

                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class Range_NPCAttack_1
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider

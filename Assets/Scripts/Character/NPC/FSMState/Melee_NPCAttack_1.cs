/*******************************************************************
 * FileName: Melee_NPCAttack_1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.ModelData.Data;
using Solider.Tools;
using Solider.Config.Common;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Melee_NPCAttack_1 : ICharacterState {
                public string id { get { return NPCStateID.Attack_1; } }
                public string anim { get { return "attack_1"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }

                private float reach;
                private bool isFlight;
                private string soundPath;
                private string effectPath;
                private ICharacter character;

                public Melee_NPCAttack_1(ICharacter character) {
                    if (false == ParamConfig.TryGetNPCReach((NPCType)character.config.npc_type, out reach)) reach = 1;
                    // end if
                    this.character = character;
                    character.config.TryGetSoundPath(id, out soundPath);
                    character.config.TryGetEffectPath(id, out effectPath);
                } // end Melee_NPCAttack_1

                public void DoBeforeEntering() {
                    isFlight = false;
                    character.avatar.Play(anim);
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                    if (string.IsNullOrEmpty(effectPath)) return;
                    // end if
                    EffectTool.ShowEffectFromPool(effectPath, 1f, character.position, character.rotation);
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
                    AnimationState state = character.avatar.GetCurrentState(anim);
                    if (null == state || state.normalizedTime < 0.5f) return;
                    // end if
                    isFlight = true;
                    if (Vector3.Distance(character.info.lockCharacter.position, character.position) > reach) return;
                    // end if
                    DamageData damage = new DamageData(character);
                    character.info.lockCharacter.info.UnderAttack(damage);
                } // end Reason

                public void Act() {

                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class Melee_NPCAttack_1
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider

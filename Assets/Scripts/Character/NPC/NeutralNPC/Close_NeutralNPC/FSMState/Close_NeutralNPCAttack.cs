/*******************************************************************
 * FileName: Close_NeutralNPCAttack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.ModelData.Data;
using Framework.Manager;
using Solider.Tools;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class Close_NeutralNPCAttack : ICharacterState {
                public string id { get { return "attack_1"; } }
                public string anim { get { return "attack_1"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }

                private float reach;
                private bool isFlight;
                private string effectPath;
                private ICharacter character;

                public Close_NeutralNPCAttack(ICharacter character) {
                    reach = 1f;
                    this.character = character;
                    character.config.TryGetEffectPath(id, out effectPath);
                } // end Close_NeutralNPCAttack

                public void DoBeforeEntering() {
                    isFlight = false;
                    character.avatar.Play(anim);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition("die");
                        return;
                    } // end if
                    if (false == character.avatar.isPlaying) {
                        if (null == character.info.lockCharacter) {
                            character.fsm.PerformTransition("idle");
                            return;
                        } //end if
                        if (Vector3.Distance(character.info.lockCharacter.position, character.position) < reach) {
                            character.fsm.PerformTransition(id);
                            return;
                        } // end if
                        character.fsm.PerformTransition("chase");
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
                    if (string.IsNullOrEmpty(effectPath)) return;
                    // end if
                    EffectTool.ShowEffectFromPool(effectPath, 2f, character.position, character.rotation);
                } // end Reason

                public void Act() {

                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class Close_NeutralNPCAttack
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider

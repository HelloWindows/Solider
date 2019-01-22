/*******************************************************************
 * FileName: MagicianSkill2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Manager;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.ModelData.Data;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class MagicianSkill2 : ICharacterState {
                public const string ID = "500102";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new MagicianSkill2(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private ICharacter character;
                private ISkillInfo info;
                private bool isFlight;
                private Collider[] results;
                private const float radius = 4f;

                private MagicianSkill2(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                    results = new Collider[8];
                } // end MagicianSkill2

                public void DoBeforeEntering() {
                    isFlight = false;
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill2");
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition("die");
                        return;
                    } // end if
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    Flight();
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                private void Flight() {
                    if (isFlight) return;
                    // end if
                    AnimationState state = character.avatar.GetCurrentState("skill2");
                    if (null == state || state.normalizedTime < 0.5f) return;
                    // end if
                    isFlight = true;
                    DamageData damage = new DamageData(character);
                    int count = Physics.OverlapSphereNonAlloc(character.position, radius, results, LayerConfig.Mask_NPC);
                    if (count > 0) {
                        for (int i = 0; i < count; i++) {
                            ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(results[i].gameObject.name);
                            if (null == npc) continue;
                            // end if
                            npc.info.UnderAttack(damage);
                        } // end for
                    } // end if   
                } // end Flight
            } // end class MagicianSkill2 
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider
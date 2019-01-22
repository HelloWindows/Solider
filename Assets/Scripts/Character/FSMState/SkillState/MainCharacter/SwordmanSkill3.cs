/*******************************************************************
 * FileName: SwordmanSkill3.cs
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
            public class SwordmanSkill3 : ICharacterState {
                public const string ID = "500003";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new SwordmanSkill3(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                private string anim { get { return "skill3"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private ICharacter character;
                private ISkillInfo info;
                private Vector3 halfExtents;
                private Collider[] results;
                private bool isFinish;

                public SwordmanSkill3( ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                    halfExtents = new Vector3(0.3f, 0.5f, 0.6f);
                    results = new Collider[5];
                } // end SwordmanSkill3

                public void DoBeforeEntering() {
                    isFinish = false;
                    character.avatar.Play(anim);
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
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
                    AnimationState state = character.avatar.GetCurrentState(anim);
                    if (null == state) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    if (true == isFinish || state.normalizedTime < 0.6f) return;
                    // end if
                    isFinish = true;
                    int count = Physics.OverlapBoxNonAlloc(character.position + character.forward * 0.6f,
                        halfExtents, results, character.rotation, LayerConfig.Mask_NPC);
                    if (count > 0) {
                        DamageData damage = new DamageData(character, info);
                        for (int i = 0; i < count; i++) {
                            ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(results[i].gameObject.name);
                            if (null == npc) continue;
                            // end if
                            npc.info.UnderAttack(damage);
                        } // end for
                    } // end if
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill3
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

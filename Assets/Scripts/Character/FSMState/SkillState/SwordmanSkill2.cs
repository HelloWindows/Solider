/*******************************************************************
 * FileName: SwordmanSkill2.cs
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
            public class SwordmanSkill2 : ICharacterState {
                public const string ID = "500002";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    IMainCharacter mainCharacter = character as IMainCharacter;
                    if (null == mainCharacter) return null;
                    // end if
                    return new SwordmanSkill2(mainCharacter, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private IMainCharacter mainCharacter;
                private ISkillInfo info;
                private int atkSign;
                private const int maxSign = 7;
                private const float radius = 1f;
                private Collider[] results;

                private SwordmanSkill2(IMainCharacter mainCharacter, ISkillInfo info) {
                    this.mainCharacter = mainCharacter;
                    this.info = info;
                    results = new Collider[5];
                } // end SwordmanSkill2

                public void DoBeforeEntering() {
                    atkSign = 0;
                    mainCharacter.avatar.Play("skill2");
                    mainCharacter.audio.PlaySoundCacheForPath(id, info.soundPath);
                } // end DoBeforeEntering

                public void Reason() {
                    AnimationState state = mainCharacter.avatar.GetCurrentState("skill2");
                    if (null == state || state.normalizedTime >= maxSign) {
                        mainCharacter.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    if (state.normalizedTime > atkSign) {
                        atkSign++;
                        int count = Physics.OverlapSphereNonAlloc(mainCharacter.position + mainCharacter.forward * 0.5f,
                            radius, results, LayerConfig.Mask_NPC);
                        if (count > 0) {
                            DamageData damage = new DamageData(mainCharacter);
                            for (int i = 0; i < count; i++) {
                                ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(results[i].gameObject.name);
                                if (null == npc) continue;
                                // end if
                                npc.info.UnderAttack(damage);
                            } // end for
                        } // end if
                    } // end if
                } // end Reason

                public void Act() {
                    mainCharacter.move.MoveForward(mainCharacter.input.joystickDir, mainCharacter.info.characterData.MSP);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill2
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

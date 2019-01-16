/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Manager;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.ModelData.Data;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanAttack4 : ICharacterState {
                public string id { get { return "attack3"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private float step;
                private bool isFinish;
                private readonly float radius;
                private Collider[] results;
                private IMainCharacter mainCharacter;
                private string soundPath { get { return "swordman_attack_4"; } }

                public SwordmanAttack4(IMainCharacter mainCharacter) {
                    step = 2f;
                    radius = 1f;
                    results = new Collider[5];
                    this.mainCharacter = mainCharacter;
                } // end SwordmanAttack4

                public void DoBeforeEntering() {
                    isFinish = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack4_1", "attack4_2"});
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (isFinish) {
                        mainCharacter.fsm.PerformTransition("wait");
                        return;
                    } // end if
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
                    mainCharacter.avatar.Play("attack4_3");
                    isFinish = true;
                } // end Reason

                public void Act() {
                    if (mainCharacter.avatar.IsPlaying("attack4_2")) {
                        mainCharacter.move.MoveForward(step);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanAttack4
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

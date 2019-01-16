/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Interface.Input;
using Framework.Manager;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.ModelData.Data;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanAttack1 : ICharacterState {
                public string id { get { return "attack"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private float step;
                private bool isCarom;
                private bool isFinish;
                private const float radius = 1f;
                private Collider[] results;
                private IMainCharacter mainCharacter;
                private ICharacterState caromState;
                private string soundPath { get { return "swordman_attack_1"; } }

                public SwordmanAttack1(IMainCharacter mainCharacter) {
                    step = 1f;
                    results = new Collider[5];
                    this.mainCharacter = mainCharacter;
                    caromState = new SwordmanAttack2(mainCharacter);
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    isCarom = false;
                    isFinish = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack1_1", "attack1_2" });
                    mainCharacter.input.AddListener(OnClickAttack);
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
                    if (isCarom) {
                        mainCharacter.fsm.PerformTransition(caromState);
                    } else {
                        mainCharacter.avatar.Play("attack1_3");
                        isFinish = true;
                    } // end if
                } // end Reason

                public void Act() {
                    if (mainCharacter.avatar.IsPlaying("attack1_2"))  {
                        mainCharacter.move.MoveForward(step);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                    mainCharacter.input.RemoveListener(OnClickAttack);
                } // end DoBeforeLeaving

                private void OnClickAttack(ClickEvent type) {
                    if (isCarom || ClickEvent.OnAttack != type) return;
                    // end if
                    if (mainCharacter.avatar.IsPlaying("attack1_2")) isCarom = true;
                    // end if
                } // end OnClickAttack

            } // end class SwordmanAttack1
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

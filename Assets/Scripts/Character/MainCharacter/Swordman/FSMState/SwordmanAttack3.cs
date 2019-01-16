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
            public class SwordmanAttack3 : ICharacterState {
                public string id { get { return "attack3"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }
                private float step;
                private bool isCarom;
                private bool isFinish;
                private Vector3 halfExtents;
                private Collider[] results;
                private IMainCharacter mainCharacter;
                private ICharacterState caromState;
                private string soundPath { get { return "swordman_attack_3"; } }

                public SwordmanAttack3(IMainCharacter mainCharacter) {
                    step = 1f;
                    halfExtents = new Vector3(0.3f, 0.5f, 0.6f);
                    results = new Collider[5];
                    this.mainCharacter = mainCharacter;
                    caromState = new SwordmanAttack4(mainCharacter);
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    isCarom = false;
                    isFinish = false;
                    mainCharacter.audio.PlaySoundCacheForPath(id, soundPath);
                    mainCharacter.avatar.PlayQueued(new string[] { "attack3_1", "attack3_2" });
                    mainCharacter.input.AddListener(OnClickAttack);
                } // end DoBeforeEntering

                public void Reason() {
                    if (mainCharacter.avatar.isPlaying) return;
                    // end if
                    if (isFinish) {
                        mainCharacter.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    int count = Physics.OverlapBoxNonAlloc(mainCharacter.position + mainCharacter.forward * 0.6f,
                        halfExtents, results, mainCharacter.rotation, LayerConfig.Mask_NPC);
                    if (count > 0) {
                        DamageData damage = new DamageData(mainCharacter);
                        for (int i = 0; i < count; i++)
                        {
                            ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(results[i].gameObject.name);
                            if (null == npc) continue;
                            // end if
                            npc.info.UnderAttack(damage);
                        } // end for
                    } // end if
                    if (isCarom) {
                        mainCharacter.fsm.PerformTransition(caromState);
                    } else {
                        mainCharacter.avatar.Play("attack3_3");
                        isFinish = true;
                    } // end if
                } // end Reason

                public void Act() {
                    if (mainCharacter.avatar.IsPlaying("attack3_2"))  {
                        mainCharacter.move.MoveForward(step);
                    } // end if
                } // end Act

                public void DoBeforeLeaving() {
                    mainCharacter.input.RemoveListener(OnClickAttack);
                } // end DoBeforeLeaving

                private void OnClickAttack(ClickEvent type) {
                    if (isCarom || ClickEvent.OnAttack != type) return;
                    // end if
                    if (mainCharacter.avatar.IsPlaying("attack3_2")) isCarom = true;
                    // end if
                } // end OnClickAttack
            } // end class SwordmanAttack3
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

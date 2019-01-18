/*******************************************************************
 * FileName: Thunder.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Manager;
using Solider.Character.Interface;
using Solider.ModelData.Interface;
using UnityEngine;

namespace Solider {
    namespace Widget {
        public class Thunder : MonoBehaviour {
            private float timer;
            private float lastTimer;
            private Collider[] results;
            private const float radius = 5f;
            private const float duration = 3.5f;
            private const float damageInterval = 0.5f;
            private IDamageData damage;

            private void Awake() {
                results = new Collider[10];
                timer = 0;
                lastTimer = 0;
            } // end Awake

            public void SetDamage(IDamageData damage) {
                this.damage = damage;
            } // end SetDamage

            void Update() {
                timer += Time.deltaTime;
                FollowUpDamage();
            } // end Update

            private void FollowUpDamage() {
                if (timer > duration) {
                    Destroy(gameObject);
                    return;
                } // end if
                if (timer - lastTimer < damageInterval) return;
                // end if
                lastTimer = timer;
                int count = Physics.OverlapSphereNonAlloc(transform.position, radius, results, LayerConfig.Mask_NPC);
                if (count > 0) {
                    for (int i = 0; i < count; i++) {
                        ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(results[i].gameObject.name);
                        if (null == npc) continue;
                        // end if
                        npc.info.UnderAttack(damage);
                    } // end for
                } // end if
            } // end FollowUpDamage
        } // end class Thunder
    } // end namespace Widget
} // end namespace Solider

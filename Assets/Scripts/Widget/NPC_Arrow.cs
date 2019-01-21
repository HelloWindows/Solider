/*******************************************************************
 * FileName: NPC_Arrow.cs
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
        public class NPC_Arrow : MonoBehaviour {
            private string poolName;
            private float timer;
            private Collider[] results;
            private const float speed = 20f;
            private const float radius = 0.2f;
            private const float maxTime = 1f;
            private IDamageData damage;

            private void Awake() {
                results = new Collider[1];
            } // end Awake

            private void OnEnable() {
                timer = 0f;
            } // end OnEnable

            public void SetDamage(string poolName, IDamageData damage) {
                this.poolName = poolName;
                this.damage = damage;
            } // end SetDamage

            private void Update() {
                timer += Time.deltaTime;
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
                int count = Physics.OverlapSphereNonAlloc(transform.position, radius, results, LayerConfig.Mask_Main);
                if (count > 0) {
                    for (int i = 0; i < count; i++) {
                        ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(results[i].gameObject.name);
                        if (null == npc) continue;
                        // end if
                        npc.info.UnderAttack(damage);
                    } // end for
                    Recycling();
                    return;
                } // end if
                if (timer > maxTime) {
                    Recycling();
                } // end if
            } // end Update

            public void Recycling() {
                damage = null;
                foreach (TrailRenderer trail in GetComponentsInChildren<TrailRenderer>()) {
                    trail.Clear();
                } // end foreach
                InstanceMgr.GetObjectManager().Recycling(poolName, gameObject);
            } // end Recycling
        } // end class NPC_Arrow 
    } // end namespace Widget
} // end namespace Solider
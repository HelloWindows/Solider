/*******************************************************************
 * FileName: ExplosiveArrow.cs
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
        public class ExplosiveArrow : MonoBehaviour {
            private GameObject arrow;
            private GameObject explosion;
            private float timer;
            private float lastTimer;
            private Collider[] results;
            private const float speed = 20f;
            private const float arrowRadius = 0.2f;
            private const float explosionRadius = 3f;
            private const float flightTime = 1f;
            private const float duration = 5f;
            private const float damageInterval = 1f;
            private IDamageData damage;
            private bool isExplosive;

            private void Awake() {
                results = new Collider[6];
                arrow = transform.Find("arrow").gameObject;
                explosion = transform.Find("explosion").gameObject;
                timer = 0;
                lastTimer = 0;
                isExplosive = false;
                explosion.SetActive(false);
            } // end Awake

            public void SetDamage(IDamageData damage) {
                this.damage = damage;
            } // end SetDamage

            void Update() {
                timer += Time.deltaTime;
                Flight();
                FollowUpDamage();
            } // end Update

            private void Flight() {
                if (isExplosive) return;
                // end if
                if (timer > flightTime) {
                    Destroy(gameObject);
                    return;
                } // end if
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
                if (Physics.OverlapSphereNonAlloc(transform.position, arrowRadius, results, LayerConfig.Mask_NPC) > 0) {
                    isExplosive = true;
                    arrow.SetActive(false);
                    explosion.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                    explosion.SetActive(true);
                    timer = 0;
                    lastTimer = 0;
                } // end if
            } // end Flight

            private void FollowUpDamage() {
                if (false == isExplosive) return;
                // end if
                if (timer > duration) {
                    Destroy(gameObject);
                    return;
                } // end if
                if (timer - lastTimer < damageInterval) return;
                // end if
                lastTimer = timer;
                int count = Physics.OverlapSphereNonAlloc(explosion.transform.position, explosionRadius, results, LayerConfig.Mask_NPC);
                if (count > 0) {
                    for (int i = 0; i < count; i++) {
                        ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(results[i].gameObject.name);
                        if (null == npc) continue;
                        // end if
                        npc.info.UnderAttack(damage);
                    } // end for
                } // end if
            } // end FollowUpDamage
        } // end class ExplosiveArrow
    } // end namespace Widget
} // end namespace Solider

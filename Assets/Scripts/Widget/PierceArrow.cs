/*******************************************************************
 * FileName: PierceArrow.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
/*******************************************************************
 * FileName: Arrow.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Manager;
using Solider.Character.Interface;
using Solider.ModelData.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Widget {
        public class PierceArrow : MonoBehaviour {

            private float timer;
            private Collider[] results;
            private const float speed = 25f;
            private const float radius = 0.2f;
            private const float maxTime = 1f;
            private IDamageData damage;
            private List<string> idList;

            private void Awake() {
                results = new Collider[1];
                idList = new List<string>();
            } // end Awake

            private void OnEnable() {
                timer = 0f;
            } // end OnEnable

            public void SetDamage(IDamageData damage) {
                this.damage = damage;
            } // end SetDamage

            private void Update() {
                timer += Time.deltaTime;
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
                int count = Physics.OverlapSphereNonAlloc(transform.position, radius, results, LayerConfig.Mask_NPC);
                if (count > 0) {
                    for (int i = 0; i < count; i++) {
                        ICharacter npc = SceneManager.characterManager.factory.GetNPCharacter(results[i].gameObject.name);
                        if (null == npc || idList.Contains(npc.hashID)) continue;
                        // end if
                        idList.Add(npc.hashID);
                        npc.info.UnderAttack(damage);
                    } // end for
                } // end if
                if (timer > maxTime) {
                    idList.Clear();
                    Destroy(gameObject);
                } // end if
            } // end Update
        } // end class PierceArrow 
    } // end namespace Widget
} // end namespace Solider
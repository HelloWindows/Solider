/*******************************************************************
 * FileName: NPC_Grocery.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Solider {
    namespace Character {
        namespace NPC {
            public class NPC_Grocery : MonoBehaviour {

                // Use this for initialization
                void Start() {
                    Animation anim = GetComponent<Animation>();
                    foreach (AnimationState state in anim) {
                        state.speed = 0.5f;
                    } // end foreach
                } // end Start

                private void OnMouseDown() {
                    if (Vector3.Distance(transform.position, SceneManager.mainCharacter.position) < 4) {
                        transform.LookAt(SceneManager.mainCharacter.position);
                        SceneManager.uiPanelFMS.PerformTransition("UIGroceryPanel");
                    } // end if
                } // end OnMouseDown
            } // end class NPC_Grocery 
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider
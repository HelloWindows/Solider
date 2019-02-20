/*******************************************************************
 * FileName: NPC_Transmitter2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Manager;
using Solider.Scene.UI;
using System.Collections.Generic;
using UnityEngine;
namespace Solider {
    namespace Character {
        namespace NPC {
            public class NPC_Transmitter2 : MonoBehaviour {
                // Use this for initialization
                void Start() {
                    Animation anim = GetComponent<Animation>();
                    foreach (AnimationState state in anim) {
                        state.speed = 0.5f;
                    } // end foreach
                } // end Start

                private void OnMouseDown() {
                    if (Vector3.Distance(transform.position, SceneManager.mainCharacter.position) < 4) {
                        Dictionary<string, string> mitterDict = new Dictionary<string, string>();
                        mitterDict[GameConfig.NOVICE_VILLAGE] = "城镇";
                        SceneManager.uiPanelFMS.PerformTransition(new UITransmitterPanel(mitterDict));
                        if (null == SceneManager.mainCharacter) return;
                        // end if
                        Vector3 position = new Vector3(SceneManager.mainCharacter.position.x, transform.position.y, SceneManager.mainCharacter.position.z);
                        transform.LookAt(position);
                    } // end if
                } // end OnMouseDown
            } // end class NPC_Transmitter2 
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider

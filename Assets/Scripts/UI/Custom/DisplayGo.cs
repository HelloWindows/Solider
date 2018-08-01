/*******************************************************************
 * FileName: DisplayGo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.Tools;
using Solider.UI.Interface;
using System;
using UnityEngine;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class DisplayGo : IDisplayGo {
                public bool isDispose { get; private set; }
                private float lastX;
                private Vector3 rotSpeed;
                private GameObject displayGo;
                private Vector3 localPos;
                private Vector3 localRot;
                private Vector3 localSca;

                public DisplayGo(string roleType) {
                    string prefix = "";
                    string weapon = "";
                    string armor = "";
                    string liftHand = "";
                    string[] animPathArr = new string[] { "pose", "wait" };
                    switch (roleType) {
                        case ConstConfig.SWORDMAN:
                            weapon = "sword6";
                            liftHand = "right_hand";
                            armor = "swordmanArmor6";
                            prefix = "Character/Hero/Swordman/Animation/";
                            break;
                        case ConstConfig.ARCHER:
                            weapon = "bow6";
                            liftHand = "left_hand";
                            armor = "archerArmor6";
                            prefix = "Character/Hero/Archer/Animation/";
                            break;
                        case ConstConfig.MAGICIAN:
                            weapon = "staff6";
                            liftHand = "right_hand";
                            armor = "magicianArmor6";
                            prefix = "Character/Hero/Magician/Animation/";
                            break;
                        default:
                            return;
                    } // ens switch
                    isDispose = false;
                    rotSpeed = new Vector3(0, 1, 0);
                    localPos = new Vector3(0, -7f, 30);
                    localRot = new Vector3(0, 180, 0);
                    localSca = Vector3.one * 15;
                    try {
                        displayGo = ObjectTool.InstantiateGo(roleType, Configs.prefabConfig.GetPath(roleType));
                    } catch {                                         
                    } // end try
                    if (null == displayGo) return;
                    // end if
                    GameObject Go = ObjectTool.InstantiateGo(weapon, Configs.prefabConfig.GetPath(weapon));
                    if (null == Go) {
                        DebugTool.ThrowException("DisplayGo weapon name: " + weapon + " path: " +
                            Configs.prefabConfig.GetPath(weapon) + " prefab is don't exsit!");
                        return;
                    } // end if
                    Transform liftTrans = null;
                    Transform[] allChildren = displayGo.transform.GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == liftHand) {
                            liftTrans = child;
                            break;
                        } // end if
                    } // end foreach    
                    Go.layer = 2;  
                    Go.transform.SetParent(liftTrans);
                    Go.transform.localPosition = Vector3.zero;
                    Go.transform.localRotation = Quaternion.identity;
                    foreach (Transform child in Go.transform) {
                        child.gameObject.layer = 2;
                    } // end foreach     
                    SkinnedMeshRenderer meshRenderer = displayGo.transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    Material material = Resources.Load<Material>(Configs.materialConfig.GetPath(armor));
                    if (null == material) {
                        DebugTool.ThrowException("DisplayGo armor  name: " + armor + " path: " +
                            Configs.materialConfig.GetPath(armor) + " prefab is don't exsit!");
                        return;
                    } // end if
                    meshRenderer.material = material;
                    Animation avatar = displayGo.AddComponent<Animation>();
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + animPathArr[0]), animPathArr[0]);
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix+ animPathArr[1]), animPathArr[1]);
                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach              
                    foreach (Transform child in displayGo.transform) {
                        child.gameObject.layer = 2;
                    } // end foreach     
                    avatar.Play(animPathArr[0]);
                    avatar.PlayQueued(animPathArr[1], QueueMode.CompleteOthers);
                } // end DisplayGo

                public void Reset(Transform parent) {
                    if (null == displayGo) return;
                    // end if
                    displayGo.transform.SetParent(parent);
                    displayGo.transform.localPosition = localPos;
                    displayGo.transform.localEulerAngles = localRot;
                    displayGo.transform.localScale = localSca;
                } // end Reset

                public void Dispose() {
                    isDispose = true;
                    if (null != displayGo) UnityEngine.Object.Destroy(displayGo);
                    // end if
                    displayGo = null;
                } // end Dispose

                public void Rotate(float offset) {
                    if (null == displayGo) return;
                    // end if
                    displayGo.transform.localEulerAngles -= rotSpeed * offset;
                } // end Rotate
            } // end class DisplayGo
        } // end namespace Custom
    } // end namespace UI
} // end namespace Solider

/*******************************************************************
 * FileName: DisplayRole.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.Tools;
using Solider.Config.Interface;
using Solider.Manager;
using Solider.Model.Interface;
using Solider.UI.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class DisplayRole : IDisplayGo {
                private GameObject wingGo;
                private GameObject weaponGo;

                private string roleType;
                private Vector3 rotSpeed;
                private GameObject displayGo;
                private Vector3 localPos;
                private Vector3 localRot;
                private Vector3 localSca;

                private Transform wingTrans; // 穿戴翅膀的位置
                private Transform liftTrans; // 拿起武器的位置
                private SkinnedMeshRenderer meshRenderer;

                public DisplayRole(string roleType) {
                    this.roleType = roleType;
                    Init(roleType);
                    string weaponID = "";
                    switch (roleType) {
                        case ConstConfig.SWORDMAN:
                            weaponID = "100005";
                            break;
                        case ConstConfig.ARCHER:
                            weaponID = "100010";
                            break;
                        case ConstConfig.MAGICIAN:
                            weaponID = "100015";
                            break;
                        default:
                            DebugTool.ThrowException("DisplayRole roleType: " + roleType + "is not config!!");
                            return;
                    } // end switch
                    ReloadWing(Configs.itemConfig.GetItemInfo("106005") as IEquipInfo);
                    ReloadArmor(Configs.itemConfig.GetItemInfo("103005") as IEquipInfo);
                    ReloadWeapon(Configs.itemConfig.GetItemInfo(weaponID) as IEquipInfo);
                    InitAvatar(roleType);
                } // end DisplayRole

                public DisplayRole(string roleType, IWearInfo wearInfo) {
                    this.roleType = roleType;
                    Init(roleType);
                    Freshen(wearInfo);
                    InitAvatar(roleType);
                } // end DisplayRole

                public DisplayRole(string roleType, Dictionary<string, string> wearDict) {
                    this.roleType = roleType;
                    Init(roleType);
                    if (wearDict.ContainsKey(ConstConfig.WING)) 
                        ReloadWing(Configs.itemConfig.GetItemInfo(wearDict[ConstConfig.WING]) as IEquipInfo);
                    else 
                        ReloadWing(null);
                    // end if
                    if (wearDict.ContainsKey(ConstConfig.ARMOR)) 
                        ReloadArmor(Configs.itemConfig.GetItemInfo(wearDict[ConstConfig.ARMOR]) as IEquipInfo);
                    else 
                        ReloadArmor(null);
                    // end if
                    if (wearDict.ContainsKey(ConstConfig.ARMOR))
                        ReloadWeapon(Configs.itemConfig.GetItemInfo(wearDict[ConstConfig.WEAPON]) as IEquipInfo);
                    else
                        ReloadWeapon(null);
                    // end if
                    InitAvatar(roleType);
                } // end DisplayRole


                public void Freshen() {
                    if (null == GameManager.playerInfo.pack) return;
                    // end if
                    Freshen(GameManager.playerInfo.pack.GetWearInfo());
                } // end Freshen

                public void Reset(Transform parent) {
                    if (null == displayGo) return;
                    // end if
                    displayGo.transform.SetParent(parent);
                    displayGo.transform.localPosition = localPos;
                    displayGo.transform.localEulerAngles = localRot;
                    displayGo.transform.localScale = localSca;
                } // end Reset

                public void Dispose() {
                    if (null != displayGo) Object.Destroy(displayGo);
                    // end if
                    displayGo = null;
                } // end Dispose

                public void Rotate(float offset) {
                    if (null == displayGo) return;
                    // end if
                    displayGo.transform.localEulerAngles -= rotSpeed * offset;
                } // end Rotate

                private void Freshen(IWearInfo wearInfo) {
                    if (null == wearInfo) return;
                    // end if
                    ReloadWing(wearInfo.GetEquipInfo(ConstConfig.WING));
                    ReloadArmor(wearInfo.GetEquipInfo(ConstConfig.ARMOR));
                    ReloadWeapon(wearInfo.GetEquipInfo(ConstConfig.WEAPON));
                } // end ReloadEquip

                private void ReloadWeapon(IEquipInfo info) {
                    string id;
                    if (null == info)
                        id = roleType + "0";
                    else
                        id = info.id;
                    // end if            
                    GameObject Go = ObjectTool.InstantiateGo(id, Configs.prefabConfig.GetPath(id));
                    if (null == Go) {
                        DebugTool.ThrowException("ReloadWeapon ID: " + id + " path: " +
                            Configs.prefabConfig.GetPath(id) + " prefab is don't exsit!");
                        return;
                    } // end if
                    if (null != weaponGo) Object.Destroy(weaponGo);
                    // end if
                    weaponGo = Go;
                    Go.transform.SetParent(liftTrans);
                    Go.transform.localScale = Vector3.one;
                    Go.transform.localPosition = Vector3.zero;
                    Go.transform.localRotation = Quaternion.identity;
                    foreach (Transform child in Go.transform) {
                        child.gameObject.layer = 2;
                    } // end foreach     
                } // end ReloadWeapon

                private void ReloadWing(IEquipInfo info) {
                    if (null == info) {
                        if (null != wingGo) Object.Destroy(wingGo);
                        return;
                    } // end if
                    string id = info.id;
                    GameObject Go = ObjectTool.InstantiateGo(id, Configs.prefabConfig.GetPath(id));
                    if (null == Go) {
                        DebugTool.ThrowException("ReloadWing ID: " + id + " path: " +
                            Configs.prefabConfig.GetPath(id) + " prefab is don't exsit!");
                        return;
                    } // end if
                    if(null != wingGo) Object.Destroy(wingGo);
                    // end if
                    wingGo = Go;
                    Go.transform.SetParent(wingTrans);
                    Go.transform.localScale = Vector3.one;
                    Go.transform.localPosition = Vector3.zero;
                    Go.transform.localRotation = Quaternion.identity;
                    Transform[] allChildren = Go.transform.GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren) {
                        child.gameObject.layer = 2;
                    } // end foreach  
                } // end ReloadWing

                private void ReloadArmor(IEquipInfo info) {
                    string id;
                    if (null == info)
                        id = "0";
                    else
                        id = info.id;
                    // end if   
                    Material material = Resources.Load<Material>(Configs.materialConfig.GetPath(roleType + id));
                    if (null == material) {
                        DebugTool.ThrowException("ReloadArmor ID: " + id + " path: " +
                            Configs.materialConfig.GetPath(id) + " prefab is don't exsit!");
                        return;
                    } // end if
                    meshRenderer.material = material;
                } // end ReloadArmor

                private void Init(string roleType) {
                    displayGo = ObjectTool.InstantiateGo(roleType, Configs.prefabConfig.GetPath(roleType));
                    if (null == displayGo) return;
                    rotSpeed = new Vector3(0, 1, 0);
                    localPos = new Vector3(0, -7f, 30);
                    localRot = new Vector3(0, 180, 0);
                    localSca = Vector3.one * 15;
                    string liftHand = "";
                    switch (roleType) {
                        case ConstConfig.SWORDMAN:
                            liftHand = "right_hand";
                            break;
                        case ConstConfig.ARCHER:
                            liftHand = "left_hand";
                            break;
                        case ConstConfig.MAGICIAN:
                            liftHand = "right_hand";
                            break;
                        default:
                            DebugTool.ThrowException("DisplayRole roleType: " + roleType + "is not config!!");
                            return;
                    } // end switch
                    Transform[] allChildren = displayGo.transform.GetComponentsInChildren<Transform>();
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == liftHand) {
                            liftTrans = child;
                            break;
                        } // end if
                    } // end foreach   
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == "wing_spine") {
                            wingTrans = child;
                            break;
                        } // end if
                    } // end foreach
                    meshRenderer = displayGo.transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    meshRenderer.gameObject.layer = 2;
                } // end Init

                private void InitAvatar(string roleType) {
                    string prefix = "";
                    switch (roleType) {
                        case ConstConfig.SWORDMAN:
                            prefix = "Character/Hero/Swordman/Animation/";
                            break;
                        case ConstConfig.ARCHER:
                            prefix = "Character/Hero/Archer/Animation/";
                            break;
                        case ConstConfig.MAGICIAN:
                            prefix = "Character/Hero/Magician/Animation/";
                            break;
                        default:
                            DebugTool.ThrowException("DisplayRole roleType: " + roleType + "is not config!!");
                            return;
                    } // end switch
                    string[] animPathArr = new string[] { "pose", "wait" };
                    Animation avatar = displayGo.AddComponent<Animation>();
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + animPathArr[0]), animPathArr[0]);
                    avatar.AddClip(Resources.Load<AnimationClip>(prefix + animPathArr[1]), animPathArr[1]);
                    foreach (AnimationState state in avatar) {
                        state.speed = 0.5f;
                    } // end foreach                
                    avatar.Play(animPathArr[0]);
                    avatar.PlayQueued(animPathArr[1], QueueMode.CompleteOthers);
                } // end InitAvatar
            } // end class DisplayRole
        } // end namespace Custom
    } // end namespace UI
} // end namespace Solider

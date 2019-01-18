/*******************************************************************
 * FileName: MainCharacterSurface.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.Manager;
using System;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterSurface : CharacterSurface, IMainCharacterSurface, IDisposable {
                private GameObject wingGo;
                private GameObject weaponGo;

                private Transform wingTrans; // 穿戴翅膀的位置
                private Transform liftTrans; // 拿起武器的位置
                private Transform furlTrans; // 收起武器的位置
                private IMainCharacter mainCharacter;

                public MainCharacterSurface(IMainCharacter mainCharacter, Transform wingTrans, Transform liftTrans, Transform furlTrans, SkinnedMeshRenderer renderer) : base(renderer) {
                    this.mainCharacter = mainCharacter;
                    this.wingTrans = wingTrans;
                    this.liftTrans = liftTrans;
                    this.furlTrans = furlTrans;
                    mainCharacter.center.AddListener(Freshen);
                    Freshen();
                } // end MainCharacterSurface

                public void FurlWeapon() {
                    if (null == weaponGo || null == furlTrans) return;
                    // end if
                    weaponGo.transform.SetParent(furlTrans);
                    weaponGo.transform.localPosition = Vector3.zero;
                    weaponGo.transform.localRotation = Quaternion.identity;
                } // end FurlWeapon

                public void LiftWeapon() {
                    if (null == weaponGo || null == liftTrans) return;
                    // end if
                    weaponGo.transform.SetParent(liftTrans);
                    weaponGo.transform.localPosition = Vector3.zero;
                    weaponGo.transform.localRotation = Quaternion.identity;
                } // end LiftWeapon

                public void Freshen() {
                    ReloadWing(mainCharacter.pack.GetWearInfo().GetEquipInfo(ConstConfig.WING));
                    ReloadArmor(mainCharacter.pack.GetWearInfo().GetEquipInfo(ConstConfig.ARMOR));
                    ReloadWeapon(mainCharacter.pack.GetWearInfo().GetEquipInfo(ConstConfig.WEAPON));
                } // end ReloadEquip

                private void Freshen(CenterEvent type) {
                    if (CenterEvent.ReloadEquip != type) return;
                    // end if
                    Freshen();
                } // end Freshen

                private void ReloadWeapon(IEquipInfo info) {
                    string id;
                    if (null == info)
                        id = GameManager.playerInfo.roletype + "_weapon";
                    else
                        id = info.id;
                    // end if             
                    GameObject Go = ObjectTool.InstantiateGo(id, ResourcesTool.LoadPrefab(id));
                    if (null == Go) {
                        DebugTool.ThrowException("ReloadWeapon ID: " + id + " prefab is don't exsit!");
                        return;
                    } // end if
                    if (null != weaponGo) UnityEngine.Object.Destroy(weaponGo);
                    // end if
                    weaponGo = Go;
                    FurlWeapon();
                } // end ReloadWeapon

                private void ReloadWing(IEquipInfo info) {
                    if (null == info) {
                        if (null != wingGo) UnityEngine.Object.Destroy(wingGo);
                        // end if
                        return;
                    } // end if
                    string id = info.id;
                    GameObject Go = ObjectTool.InstantiateGo(id, ResourcesTool.LoadPrefab(id));
                    if (null == Go) {
                        DebugTool.ThrowException("ReloadWing ID: " + id + " prefab is don't exsit!");
                        return;
                    } // end if
                    if (null != wingGo) UnityEngine.Object.Destroy(wingGo);
                    // end if
                    wingGo = Go;
                    wingGo.transform.SetParent(wingTrans);
                    wingGo.transform.localPosition = Vector3.zero;
                    wingGo.transform.localRotation = Quaternion.identity;
                } // end ReloadWing

                private void ReloadArmor(IEquipInfo info) {
                    string id;
                    if (null == info)
                        id = "0";
                    else
                        id = info.id;
                    // end if    
                    Material material = ResourcesTool.LoadMaterial(GameManager.playerInfo.roletype + "_" + id);
                    if (null == material) {
                        DebugTool.ThrowException("ReloadArmor ID: " + id + " material is don't exsit!");
                        return;
                    } // end if
                    renderer.material = material;
                } // end ReloadArmor

                public void Dispose() {
                    mainCharacter.center.RemoveListener(Freshen);
                } // end Dispose
            } // end class MainCharacterSurface
        } // end namespace MainCharacter 
    } // end namespace Character
} // end namespace Solider 

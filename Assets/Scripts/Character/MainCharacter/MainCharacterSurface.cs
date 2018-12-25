/*******************************************************************
 * FileName: MainCharacterSurface.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Broadcast;
using Framework.Config;
using Framework.Config.Const;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Hero {
            public class MainCharacterSurface : IMainCharacterSurface {
                private GameObject wingGo;
                private GameObject weaponGo;

                private Transform wingTrans; // 穿戴翅膀的位置
                private Transform liftTrans; // 拿起武器的位置
                private Transform furlTrans; // 收起武器的位置
                private SkinnedMeshRenderer renderer;
                private ICharacterCenter center;
                private Dictionary<string, string> checkDict;

                public MainCharacterSurface(ICharacterCenter center, Transform wingTrans, Transform liftTrans, Transform furlTrans, SkinnedMeshRenderer renderer) {
                    this.center = center;
                    this.wingTrans = wingTrans;
                    this.liftTrans = liftTrans;
                    this.furlTrans = furlTrans;
                    this.renderer = renderer;
                    checkDict = new Dictionary<string, string>();
                    for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) {
                        checkDict[ConstConfig.EquipTypeList[i]] = "0";
                    } // end for
                    checkDict[ConstConfig.WEAPON] = "-1";
                    if (null == center) return;
                    // end if
                    center.AddListener(Freshen);
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
                    ReloadWing(GameManager.playerInfo.pack.GetWearInfo().GetEquipInfo(ConstConfig.WING));
                    ReloadArmor(GameManager.playerInfo.pack.GetWearInfo().GetEquipInfo(ConstConfig.ARMOR));
                    ReloadWeapon(GameManager.playerInfo.pack.GetWearInfo().GetEquipInfo(ConstConfig.WEAPON));
                } // end ReloadEquip

                private void Freshen(CenterEvent type) {
                } // end Freshen

                private void ReloadWeapon(IEquipInfo info) {
                    string id;
                    if (null == info)
                        id = GameManager.playerInfo.roleType + "0";
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
                    FurlWeapon();
                } // end ReloadWeapon

                private void ReloadWing(IEquipInfo info) {
                    if (null == info) {
                        if (null != wingGo) Object.Destroy(wingGo);
                        // end if
                        return;
                    } // end if
                    string id = info.id;
                    GameObject Go = ObjectTool.InstantiateGo(id, Configs.prefabConfig.GetPath(id));
                    if (null == Go) {
                        DebugTool.ThrowException("ReloadWing ID: " + id + " path: " +
                            Configs.prefabConfig.GetPath(id) + " prefab is don't exsit!");
                        return;
                    } // end if
                    if (null != wingGo) Object.Destroy(wingGo);
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
                    Material material = Resources.Load<Material>(Configs.materialConfig.GetPath(GameManager.playerInfo.roleType + id));
                    if (null == material) {
                        DebugTool.ThrowException("ReloadArmor ID: " + id + " path: " +
                            Configs.materialConfig.GetPath(id) + " prefab is don't exsit!");
                        return;
                    } // end if
                    renderer.material = material;
                } // end ReloadArmor

                public void Dispose() {
                    if (null == center) return;
                    // end if
                    center.RemoveListener(Freshen);
                } // end Dispose
            } // end class MainCharacterSurface
        } // end namespace Hero 
    } // end namespace Character
} // end namespace Custom 

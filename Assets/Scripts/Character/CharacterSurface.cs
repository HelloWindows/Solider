/*******************************************************************
 * FileName: CharacterSurface.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Config;
using Solider.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Character {
        public class CharacterSurface : ISurface {
            private GameObject wingGo;
            private GameObject weaponGo;

            private Transform wingTrans; // 穿戴翅膀的位置
            private Transform liftTrans; // 拿起武器的位置
            private Transform furlTrans; // 收起武器的位置
            private SkinnedMeshRenderer renderer;

            public CharacterSurface(Transform wingTrans, Transform liftTrans, Transform furlTrans, SkinnedMeshRenderer renderer) {
                this.wingTrans = wingTrans;
                this.liftTrans = liftTrans;
                this.furlTrans = furlTrans;
                this.renderer = renderer;
            } // end CharacterSurface

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

            public void ReloadEquip(string id) {
                if (CheckID(id, ConstConfig.WING)) {
                    ReloadWing(id);
                    return;
                }  // end if
                if (CheckID(id, ConstConfig.ARMOE)) {
                    ReloadArmor(id);
                    return;
                } // end if
                if ("0" == id || CheckID(id, ConstConfig.WEAPON)) {
                    ReloadWeapon(id);
                } // end if
            } // end ReloadEquip

            public void ReloadEquip(Dictionary<string, string> wearDict) {
                if (null == wearDict) return;
                // end if
                if (wearDict.ContainsKey(ConstConfig.WING)) {
                    ReloadWing(wearDict[ConstConfig.WING]);
                } // end if
                if (wearDict.ContainsKey(ConstConfig.ARMOE)) {
                    ReloadArmor(wearDict[ConstConfig.ARMOE]);
                } // end if
                if (wearDict.ContainsKey(ConstConfig.WEAPON)) {
                    ReloadWeapon(wearDict[ConstConfig.WEAPON]);
                } // end if
            } // end ReloadEquip

            private void ReloadWeapon(string id) {
                if ("0" == id) id = GameManager.playerInfo.roleType + "0";
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

            private void ReloadWing(string id) {
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

            private void ReloadArmor(string id) {
                Material material = Resources.Load<Material>(Configs.materialConfig.GetPath(GameManager.playerInfo.roleType + id));
                if (null == material) {
                    DebugTool.ThrowException("ReloadArmor ID: " + id + " path: " +
                        Configs.materialConfig.GetPath(id) + " prefab is don't exsit!");
                    return;
                } // end if
                renderer.material = material;
            } // end ReloadArmor

            private bool CheckID(string id, string type) {
                EquipInfo info = Configs.itemConfig.GetItemInfo(id) as EquipInfo;
                if (null == info || info.type != type) return false;
                // end if
                return true;
            } // end CheckID
        } // end class CharacterSurface
    } // end namespace Character
} // end namespace Custom 

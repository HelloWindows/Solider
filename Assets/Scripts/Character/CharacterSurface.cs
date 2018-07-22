/*******************************************************************
 * FileName: CharacterSurface.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Tools;
using Solider.Character.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Character {
        public class CharacterSurface : ISurface {
            private GameObject weaponGo;
            private Transform liftTrans; // 拿起武器的位置
            private Transform furlTrans; // 收起武器的位置
            private SkinnedMeshRenderer renderer;

            public CharacterSurface(Transform liftTrans, Transform furlTrans, SkinnedMeshRenderer renderer) {
                this.liftTrans = liftTrans;
                this.furlTrans = furlTrans;
                this.renderer = renderer;
            } // end CharacterSurface

            public void FurlWeapon() {
                if (null == weaponGo) return;
                // end if
                weaponGo.transform.SetParent(furlTrans);
                weaponGo.transform.localPosition = Vector3.zero;
                weaponGo.transform.localRotation = Quaternion.identity;
            } // end FurlWeapon

            public void LiftWeapon() {
                if (null == weaponGo) return;
                // end if
                weaponGo.transform.SetParent(liftTrans);
                weaponGo.transform.localPosition = Vector3.zero;
                weaponGo.transform.localRotation = Quaternion.identity;
            } // end LiftWeapon

            public void ReloadWeapon(string name) {
                GameObject Go = ObjectTool.InstantiateGo("name", Configs.prefabConfig.GetPath(name));
                if (null == Go) {
#if __MY_DEBUG__
                    throw new System.Exception("ReloadWeapon name: " + name + " path: " +
                        Configs.prefabConfig.GetPath(name) + " prefab is don't exsit!");
#else
                    return;
#endif
                } // end if
                if (null != weaponGo) Object.Destroy(weaponGo);
                // end if
                weaponGo = Go;
                FurlWeapon();
            } // end ReloadWeapon

            public void ReloadArmor(string name) {
                Material material = Resources.Load<Material>(Configs.materialConfig.GetPath(name));
                if (null == material) {
#if __MY_DEBUG__
                    throw new System.Exception("ReloadArmor name: " + name + " path: " +
                        Configs.materialConfig.GetPath(name) + " prefab is don't exsit!");
#else
                    return;
#endif
                } // end if
                renderer.material = material;
            } // end ReloadArmor
        } // end class CharacterSurface
    } // end namespace Character
} // end namespace Custom 

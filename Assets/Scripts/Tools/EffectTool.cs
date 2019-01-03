/*******************************************************************
 * FileName: EffectTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Tools {
        public static class EffectTool {
            public static void ShowEffectOnce(string name, Vector3 posistion) {
                ObjectTool.InstantiateGo(name, ResourcesTool.LoadPrefab(name), null, posistion, Vector3.zero, Vector3.one);
            } // end ShowEffectOnce

            public static void ShowEffectFromPool(string name, float time, Vector3 posistion) {
                GameObject Go = InstanceMgr.GetObjectManager().GetGameObject(name, time);
                Go.transform.position = posistion;
                Go.SetActive(true);
            } // end ShowEffectCache

            public static void ShowEffectFromPool(string name, float time, Vector3 posistion, Vector3 rotation) {
                GameObject Go = InstanceMgr.GetObjectManager().GetGameObject(name, time);
                Go.transform.position = posistion;
                Go.transform.eulerAngles = rotation;
                Go.SetActive(true);
            } // end ShowEffectCache
        } // end class EffectTool
    } // end namespace Tools
} // end namespace Solider 

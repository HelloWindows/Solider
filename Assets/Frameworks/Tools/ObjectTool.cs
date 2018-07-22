/*******************************************************************
 * FileName: ObjectTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2017-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Tools {
        public static class ObjectTool {

            public static GameObject InstantiateEmptyGo(string name) {
                return new GameObject(name);
            } // end InstantiateEmptyGo

            public static GameObject InstantiateEmptyGo(string name, Transform parent, Vector3 localPos) {
                return InstantiateEmptyGo(name, parent, localPos, Vector3.zero, Vector3.one);
            } // end InstantiateEmptyGo

            public static GameObject InstantiateEmptyGo(string name, Transform parent, Vector3 localPos, Vector3 localRot, Vector3 localSca) {
                GameObject Go = InstantiateEmptyGo(name);
                Go.transform.SetParent(parent);
                Go.transform.localPosition = localPos;
                Go.transform.localEulerAngles = localRot;
                Go.transform.localScale = localSca;
                return Go;
            } // end InstantiateEmptyGo

            public static GameObject InstantiateGo(string name, GameObject prefab) {
                return InstantiateGo(name, prefab, null, Vector3.zero, Vector3.zero, Vector3.one);
            } // end InstantiateGo

            public static GameObject InstantiateGo(string name, GameObject prefab, Transform parent) {
                return InstantiateGo(name, prefab, parent, Vector3.zero, Vector3.zero, Vector3.one);
            } // end InstantiateGo

            public static GameObject InstantiateGo(string name, GameObject prefab, Transform parent, Vector3 localPos, Vector3 localRot, Vector3 localSca) {
                GameObject Go = Object.Instantiate(prefab, parent);
                Go.transform.localScale = localSca;
                Go.transform.localPosition = localPos;
                Go.transform.localEulerAngles = localRot;
                Go.name = name;
                return Go;
            } // end InstantiateGo

            public static GameObject InstantiateGo(string name, string path) {
                GameObject prefab = Resources.Load<GameObject>(path);

                if (null == prefab) throw new System.Exception("InstantiateGo prefab is null!");
                // end if
                return InstantiateGo(name, prefab);
            } // end InstantiateGo

            public static GameObject InstantiateGo(string name, string path, Transform parent) {
                GameObject prefab = Resources.Load<GameObject>(path);

                if (null == prefab) throw new System.Exception("InstantiateGo prefab is null!");
                // end if
                return InstantiateGo(name, prefab, parent);
            } // end InstantiateGo

            public static GameObject InstantiateGo(string name, string path, Transform parent, Vector3 localPos, Vector3 localRot, Vector3 localSca) {
                GameObject prefab = Resources.Load<GameObject>(path);

                if (null == prefab) throw new System.Exception("InstantiateGo prefab is null!");
                // end if
                return InstantiateGo(name, prefab, parent, localPos, localRot, localSca);
            } // end InstantiateGo
        } // end class ObjectTools
    } // end namespace Tools
} // end namespace Custem

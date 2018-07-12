/*******************************************************************
 * FileName: ObjectPool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Instance {
        public class ObjectPool {
            private Transform poolParent;
            private Dictionary<string, GameObject> prefabDict;
            private Dictionary<string, List<GameObject>> objListDict;

            public ObjectPool() {
                poolParent = new GameObject("ObjectPool").transform;
                prefabDict = new Dictionary<string, GameObject>();          
                objListDict = new Dictionary<string, List<GameObject>>();
            } // end AudioManager

            public GameObject GetGameObject(string name) {

                if (!objListDict.ContainsKey(name)) {
                    Debug.LogError("ObjectPool GetGameObject Name:" + name + " Don't exsit!");
                    return null;
                } // end if
                GameObject Go;
                if (objListDict[name].Count > 0) {
                    Go = objListDict[name][0];
                    objListDict[name].RemoveAt(0);
                    return Go;
                } // end if
                Go = ObjectTool.InstantiateGo(name, prefabDict[name], poolParent);
                Go.SetActive(false);
                return Go;
            } // end GetGameObject

            public void Recycling(string name, GameObject Go) {

                if (null == Go) {
#if __MY_DEBUG__
                    ConsoleTool.SetError("ObjectPool Recycling Go is NULL");
#endif
                    return;
                } // end if

                if (!objListDict.ContainsKey(name)) {
                    Object.Destroy(Go);
                    Debug.LogWarning("ObjectPool Recycling Name:" + name + " Don't exist!!");
                    return;
                } // end if
                Go.transform.SetParent(poolParent);
                objListDict[name].Add(Go);
                Go.SetActive(false);
            } // end Recycling

            private void BuildPool(string name, string prefix, string suffix) {

                if (objListDict.ContainsKey(name) || prefabDict.ContainsKey(name)) {
                    Debug.LogWarning("ObjectPool BuildPool Name:" + name + " is exist!!");
                    return;
                } // end if
                objListDict.Add(name, new List<GameObject>());
                GameObject Go = Resources.Load<GameObject>(prefix + suffix);

                if (null == Go) {
                    Debug.LogWarning("Path: " + prefix + suffix + "Don't exsit!!");
                    return;
                } // end if
                prefabDict.Add(name, Go);
            } // end BuildPool
        } // end class ObjectPool
    } // end namespace Instances
} // end namespace Framework
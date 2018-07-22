/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Manager {
        public class ObjectManager {
            private Transform poolParent;
            private Queue<ObjectTimer> objQueue;
            private Dictionary<string, string> objPath;
            private Dictionary<string, GameObject> prefabDict;
            private Dictionary<string, List<GameObject>> objListDict;

            public ObjectManager() {
                objQueue = new Queue<ObjectTimer>();
                poolParent = new GameObject("ObjectManager").transform;
                objPath = new Dictionary<string, string>();
                prefabDict = new Dictionary<string, GameObject>();          
                objListDict = new Dictionary<string, List<GameObject>>();

                BuildPool("runEffect", Configs.effectConfig.GetPath("runEffect"));
            } // end AudioManager

            public void Update(float deltaTime) {
                int count = objQueue.Count;
                for (int i = 0; i < count; i++) {
                    ObjectTimer timer = objQueue.Dequeue();
                    if (timer.IsOverTime(deltaTime)) continue;
                    // end if
                    objQueue.Enqueue(timer);
                } // end for
            } // end Update

            public GameObject GetGameObject(string name, float time) {
                if (!objListDict.ContainsKey(name)) {
#if __MY_DEBUG__
                    Debug.LogError("ObjectPool GetGameObject Name:" + name + " Don't exsit!");
#endif
                    return null;
                } // end if
                GameObject Go;
                if (objListDict[name].Count > 0) {
                    Go = objListDict[name][0];
                    objListDict[name].RemoveAt(0);
                    objQueue.Enqueue(new ObjectTimer(name, Go, time));
                    return Go;
                } // end if
                GameObject prefab = GetPrefab(name);
                if (null == prefabDict) {
                    return null;
                } // end if
                Go = ObjectTool.InstantiateGo(name, prefab, poolParent);
                Go.SetActive(false);
                objQueue.Enqueue(new ObjectTimer(name, Go, time));
                return Go;
            } // end GetGameObject

            public GameObject GetGameObject(string name) {
                if (!objListDict.ContainsKey(name)) {
#if __MY_DEBUG__
                    Debug.LogError("ObjectPool GetGameObject Name:" + name + " Don't exsit!");
#endif
                    return null;
                } // end if
                GameObject Go;
                if (objListDict[name].Count > 0) {
                    Go = objListDict[name][0];
                    objListDict[name].RemoveAt(0);
                    return Go;
                } // end if
                GameObject prefab = GetPrefab(name);
                if (null == prefabDict) {
                    return null;
                } // end if
                Go = ObjectTool.InstantiateGo(name, prefab, poolParent);
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
#if __MY_DEBUG__
                    Debug.LogWarning("ObjectPool Recycling Name:" + name + " Don't exist!!");
#endif
                    return;
                } // end if
                if (objListDict[name].Contains(Go)) {
#if __MY_DEBUG__
                    Debug.LogWarning("ObjectPool Recycling Name:" + name + " replace recycling!!");
#endif
                    return;
                }  // end if
                Go.transform.SetParent(poolParent);
                objListDict[name].Add(Go);
                Go.SetActive(false);
            } // end Recycling

            private void BuildPool(string name, string path) {

                if (objListDict.ContainsKey(name) || objPath.ContainsKey(name)) {
#if __MY_DEBUG__
                    Debug.LogWarning("ObjectPool BuildPool Name:" + name + " is exist!!");
#endif
                    return;
                } // end if
                objListDict[name] = new List<GameObject>();
                objPath[name] = path;
            } // end BuildPool

            public GameObject GetPrefab(string name) {
                if (prefabDict.ContainsKey(name)) {
                    return prefabDict[name];
                } // end 
                GameObject Go = Resources.Load<GameObject>(objPath[name]);
                if (null == Go) {
#if __MY_DEBUG__
                    Debug.LogWarning(" GetPrefab name: " + name + " path: " + objPath[name] + " Don't exsit!!");
#endif
                    return null;
                } // end if
                prefabDict[name] = Go;
                return Go;
            } // end GetPrefab
        } // end class ObjectManager
    } // end namespace Manager
} // end namespace Framework
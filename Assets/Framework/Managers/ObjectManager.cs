/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Manager {
        public class ObjectManager {
            private Transform poolParent;
            private Queue<ObjectTimer> objQueue;
            private Dictionary<string, List<GameObject>> objListDict;

            public ObjectManager() {
                objQueue = new Queue<ObjectTimer>();
                poolParent = new GameObject("ObjectManager").transform;    
                objListDict = new Dictionary<string, List<GameObject>>();

                BuildPool("maincharachter_run_effect");
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
                    Debug.LogError(GetType() + "GetGameObject Name:" + name + " Don't exsit!");
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
                GameObject prefab = ResourcesTool.LoadPrefab(name);
                if (null == prefab) {
#if __MY_DEBUG__
                    Debug.LogError(GetType() + "GetGameObject prefab is null! name:" + name);
#endif
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
                GameObject prefab = ResourcesTool.LoadPrefab(name);
                if (null == prefab) {
#if __MY_DEBUG__
                    Debug.LogError(GetType() + "GetGameObject prefab is null! name:" + name);
#endif
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

            private void BuildPool(string name) {

                if (objListDict.ContainsKey(name)) {
#if __MY_DEBUG__
                    Debug.LogWarning("ObjectPool BuildPool Name:" + name + " is exist!!");
#endif
                    return;
                } // end if
                objListDict[name] = new List<GameObject>();
            } // end BuildPool
        } // end class ObjectManager
    } // end namespace Manager
} // end namespace Framework
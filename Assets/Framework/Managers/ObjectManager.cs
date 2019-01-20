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
            private Dictionary<string, Stack<GameObject>> objectsMap;

            public ObjectManager() {
                objQueue = new Queue<ObjectTimer>();
                poolParent = new GameObject("ObjectManager").transform;
                objectsMap = new Dictionary<string, Stack<GameObject>>();
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

            public GameObject GetGameObject(string name) {
                if (string.IsNullOrEmpty(name)) {
#if __MY_DEBUG__
                    ConsoleTool.SetError(GetType() + "GetGameObject name is null or empty! Name:" + name);
#endif
                    return null;
                } // end if
                Stack<GameObject> objects;
                if (false == objectsMap.TryGetValue(name, out objects)) {
#if __MY_DEBUG__
                    Debug.Log(GetType() + "GetGameObject Name:" + name + " build a pool!");
#endif
                    objects = new Stack<GameObject>();
                    objectsMap[name] = objects;
                } // end if
                GameObject Go = objects.Count > 0 ? objects.Pop() : null;
                if (Go != null) return Go;
                // end if
                GameObject prefab = ResourcesTool.LoadPrefabPool(name);
                if (null == prefab) {
#if __MY_DEBUG__
                    ConsoleTool.SetError(GetType() + "GetGameObject prefab is null! name:" + name);
#endif
                    return null;
                } // end if
                Go = Object.Instantiate(prefab, poolParent);
                Go.name = name;
                return Go;
            } // end GetGameObject

            public GameObject GetGameObject(string name, float time) {
                GameObject Go = GetGameObject(name);
                objQueue.Enqueue(new ObjectTimer(name, Go, time));
                return Go;
            } // end GetGameObject

            public T GetGameObject<T>(string name) where T : MonoBehaviour {
                GameObject Go = GetGameObject(name);
                T component = Go.GetComponent<T>();
                if (null != component) return component;
                // end if
                return Go.AddComponent<T>();
            } // end GetGameObject

            public void Recycling(string name, GameObject Go) {
                if (null == Go) {
#if __MY_DEBUG__
                    ConsoleTool.SetError(GetType() + "Recycling GameObject is NULL! Name:" + name);
#endif
                    return;
                } // end if
                if (string.IsNullOrEmpty(name)) {
#if __MY_DEBUG__
                    ConsoleTool.SetError(GetType() + "Recycling GameObject Name:" + name + " is null or empty!");
#endif
                    Object.Destroy(Go);
                    return;
                } // end if
                Stack<GameObject> objects;
                if (false == objectsMap.TryGetValue(name, out objects)) {
#if __MY_DEBUG__
                    ConsoleTool.SetError(GetType() + "Recycling GameObject Name:" + name + " dosn't build!!");
#endif
                    Object.Destroy(Go);
                    return;
                } // end if
                if (objects.Contains(Go)) {
#if __MY_DEBUG__
                    ConsoleTool.SetError(GetType() + "Recycling GameObject Name:" + name + " replace recycling!!");
#endif
                    Object.Destroy(Go);
                    return;
                }  // end if
                Go.SetActive(false);
                Go.transform.SetParent(poolParent, false);
                objects.Push(Go);
            } // end Recycling
        } // end class ObjectManager
    } // end namespace Manager
} // end namespace Framework
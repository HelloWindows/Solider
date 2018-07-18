/*******************************************************************
 * FileName: SceneManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Framework.Interface;

namespace Framework {
    namespace Manager {
        public class SceneManager : MonoBehaviour {
            private static IScene m_scene;
            public static IScene scene { get { return m_scene; } }
            public static ICamera mainCamera { get { return m_scene.mainCamera; } }
            public static ICanvas mainCanvas { get { return m_scene.mainCanvas; } }

            public static void SetScene(IScene scene) {
                if (null == scene) {
#if __MY_DEBUG__
                    ConsoleTool.SetError("SceneManager SetScene scene is null!");
#endif
                    throw new System.Exception("don't have scene can play!");
                } // end if
                m_scene = scene;
            } // end SetSceneName

            void Start() {
                InstanceMgr.Init();
                m_scene.Initialize();
            } // end Start

            private void Update() {
                if (scene.IsDispose) return;
                // end if
                m_scene.Update(Time.deltaTime);
            } // end Update
        } // end class SceneManager
    } // end namespace Manager 
} // end namespace Framework
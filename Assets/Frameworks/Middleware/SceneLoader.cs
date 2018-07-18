/*******************************************************************
 * FileName: SceneLoader.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using System.Collections;
using Framework.Interface;

namespace Framework {
    namespace Middleware {
        public class SceneLoader : MonoBehaviour {
            private static bool isLoaded;
            private static string sceneName;

            public static void LoadNextLevel(IScene scene) {
                if (isLoaded) return;
                // end if
                isLoaded = true;
                if(null != Manager.SceneManager.scene) { // 清理当前场景
                    Manager.SceneManager.scene.Dispose();
                } // edn if
                sceneName = scene.sceneName; // 加载的场景名
                Manager.SceneManager.SetScene(scene); // 设置场景资料
                UnityEngine.SceneManagement.SceneManager.LoadScene("SceneLoader");
            } // end LoadNextLevel

            IEnumerator Start() {
                isLoaded = false;
                AsyncOperation asyn = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
                yield return asyn;
            } // end Start
        } // end class SceneManager
    } // end namespace Middleware
} // end namespace Framework
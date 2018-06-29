/*******************************************************************
 * FileName: SceneLoader.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Framework.Manager;

namespace Framework {
    namespace Middleware {
        public class SceneLoader : MonoBehaviour {
            private static bool isLoaded;
            private static string sceneName;

            public static void LoadNextLevel(string level) {
                if (isLoaded) return;
                // end if
                isLoaded = true;
                sceneName = "Level";
                LevelManager.SetLevelName(level);
                SceneManager.LoadScene("SceneLoader");
            } // end LoadNextLevel

            public static void LoadNextScene(string name) {
                if (isLoaded) return;
                // end if
                isLoaded = true;
                sceneName = name;
                SceneManager.LoadScene("SceneLoader");
            } // end SetLevelName

            IEnumerator Start() {
                isLoaded = false;
                AsyncOperation asyn = SceneManager.LoadSceneAsync(sceneName);
                yield return asyn;
            } // end Start
        } // end class SceneManager
    } // end namespace Middleware
} // end namespace Framework
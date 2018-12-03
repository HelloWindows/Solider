/*******************************************************************
 * FileName: SceneLoader.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using System.Collections;
using Framework.Interface.Scene;
using Framework.Config.Game;
using UnityEngine.UI;
using Framework.Tools;

namespace Framework {
    namespace Middleware {
        public class LoaderScene : MonoBehaviour {
            private static bool isLoaded;
            private static string sceneName;
            private Text progressText;
            private Slider progressSlider;

            public static void LoadNextLevel(IScene scene) {
                if (isLoaded) return;
                // end if
                isLoaded = true;
                sceneName = scene.sceneName; // 加载的场景名
                Manager.SceneManager.SetScene(scene); // 设置场景资料
                UnityEngine.SceneManagement.SceneManager.LoadScene(GameConfig.LOADER_SCENE);
            } // end LoadNextLevel

            IEnumerator Start() {
                progressSlider = GameObject.Find("Canvas/ProgressSlider").GetComponent<Slider>();
                progressText = progressSlider.transform.Find("Handle Slide Area/Handle/ProgressText").GetComponent<Text>();
                AsyncOperation asyn = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
                asyn.allowSceneActivation = false;
                float smooth = 0;
                float progress = 0;
                WaitForEndOfFrame wait = new WaitForEndOfFrame();
                while (smooth < 1) {
                    if(progress < 1) progress = 1.125f * asyn.progress;
                    // end if
                    if (smooth < progress) smooth += Time.deltaTime;
                    // end if
                    progressText.text = (int)MathTool.Clamp((smooth * 100), 0, 100) + "%";
                    progressSlider.value = smooth;
                    yield return wait;
                } // end while
                isLoaded = false;
                asyn.allowSceneActivation = true;
            } // end Start
        } // end class LoaderScene
    } // end namespace Middleware
} // end namespace Framework
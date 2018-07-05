/*******************************************************************
 * FileName: SceneManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Framework.Middleware;
using Framework.Tools;
using Solider;

namespace Framework {
    namespace Manager {
        public class LevelManager : MonoBehaviour {
            public static string LevelName { get; private set; }

            public static void SetLevelName(string level) {
                LevelName = level;
            } // end SetSceneName

            void Start() {
                CanvasAdjustor adjustor = new CanvasAdjustor();
                adjustor.Adjusting();
                InstanceMgr.Init();
                LevelName = "MainGameLevel";

                switch (LevelName) {

                    case "MainGameLevel":
                        ObjectTool.InstantiateEmptyGo("MainGameLevel").AddComponent<MainGameLevel>();
                        break;

                    default:
                        Debug.LogWarning("LevelManager error! levelName is:" + LevelName);
                        break;
                } // end switch
                Destroy(gameObject);
            } // end Start
        } // end class LevelManager
    } // end namespace Manager 
} // end namespace Framework
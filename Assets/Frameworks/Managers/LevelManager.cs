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
using Solider.Data;

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
                SqliteManager.Init();
                //LevelName = "SelectRoleLevel";

                switch (LevelName) {

                    case "SelectRoleLevel":
                        ObjectTool.InstantiateEmptyGo("SelectRoleLevel").AddComponent<SelectRoleLevel>();
                        break;

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
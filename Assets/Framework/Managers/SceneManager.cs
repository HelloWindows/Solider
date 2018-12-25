/*******************************************************************
 * FileName: SceneManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Framework.Interface.Scene;
using Framework.Interface.View;
using Framework.Interface.UI;
using Framework.Tools;
using Solider.Manager;
using Solider.Character.Interface;
using Framework.FSM.Interface;

namespace Framework {
    namespace Manager {
        public class SceneManager : MonoBehaviour {
            private static IScene m_scene;
            public static IMainCamera mainCamera { get { return m_scene.mainCamera; } }
            public static IUICamera uiCamera { get { return m_scene.uiCamera; } }
            public static ICanvas uiCanvas { get { return m_scene.uiCanvas; } }
            public static IFSM uiPanelFMS { get { return m_scene.uiPanelFSM; } }
            public static IMainCharacter mainCharacter { get { return m_scene.mainCharacter; } }

            public static void SetScene(IScene scene) {
                GameManager.SetGameState(GameState.SWITCH);
                if (null != m_scene) { // 清理当前场景
                    m_scene.Dispose();
                } // end if
                if (null == scene) {
                    ConsoleTool.SetError("SceneManager SetScene scene is null!");
                    DebugTool.ThrowException("don't have scene can play!");
                    return;
                } // end if
                m_scene = scene;
            } // end SetSceneName

            private void Start() {
                GameManager.SetGameState(GameState.INITIALIZATION);
                InstanceMgr.Init();
                m_scene.Initialize();
                GameManager.SetGameState(GameState.PLAY);
            } // end Start

            private void Update() {
                float deltaTime = Time.deltaTime;
                m_scene.Update(deltaTime);
                if (GameManager.state == GameState.PLAY)
                    InstanceMgr.Update(Time.deltaTime);
                // end if
            } // end Update

            private void LateUpdate() {
                m_scene.LateUpdate(Time.deltaTime);
            } // end LateUpdate
        } // end class SceneManager
    } // end namespace Manager 
} // end namespace Framework
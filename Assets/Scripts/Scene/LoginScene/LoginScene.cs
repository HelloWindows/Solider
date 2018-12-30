/*******************************************************************
 * FileName: LoginScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom.View;
using Framework.Interface.UI;
using Framework.Interface.View;
using Framework.Interface.Scene;
using Framework.Tools;
using Solider.Scene.UI;
using UnityEngine;
using Framework.FSM.Interface;
using Framework.FSM;
using Solider.Character.Interface;
using Framework.Config.Game;
using Framework.Custom.UI;
using Framework.Custom.Audio;
using Framework.Interface.Audio;

namespace Solider {
    namespace Scene {
        public class LoginScene : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get { return m_fsmSystem; } }
            public IMainAudio mainAudio { get { return m_mainAudio; } }
            public IMainCanvas mainCanvas { get { return m_mainCanvas; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IMainCharacter mainCharacter { get; private set; }

            private FSMSystem m_fsmSystem;
            private MainAudio m_mainAudio;
            private MainCamera m_mainCamera;
            private MainCanvas m_mainCanvas;
            private GameObject gameObject;

            public LoginScene() {
                sceneName = GameConfig.EMPTY_SCENE;
                m_fsmSystem = new FSMSystem();
            } // end LoginScene

            public void Initialize() {
                m_mainAudio = new MainAudio();
                m_mainCanvas = new MainCanvas();
                m_mainCamera = new MainCamera();
                m_mainAudio.PlayBackgroundMusic("login_scene_bgm");
                gameObject = ObjectTool.InstantiateGo("LoginSceneBg", "Scene/LoginScene/LoginSceneBg", 
                    null, new Vector3(0, 0, 5.1f), Vector3.zero, Vector3.one);
                uiPanelFSM.PerformTransition(new UILoginPanel());
            } // end Initialize

            public void Update() {
                m_fsmSystem.Update();
            } // end Update

            public void LateUpdate() {
                if (null == mainCamera) return;
                // end if
                m_mainCamera.LateUpdate();
            } // end LateUpdate

            public void Dispose() {
                if (null != m_mainAudio) m_mainAudio.Dispose();
                // end if
                if (null != m_mainCanvas) m_mainCanvas.Dispose();
                // end if
                if (null != m_mainCamera) m_mainCamera.Dispose();
                // end if
                if (null != gameObject) Object.Destroy(gameObject);
                // end if
            } // end Dispose
        } // end class LoginScene 
    } // end namespace Scene
} // end namespace Custom
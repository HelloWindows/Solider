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

namespace Solider {
    namespace Scene {
        public class LoginScene : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get { return fsmSystem; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IUICamera uiCamera { get { return m_uiCamera; } }
            public ICanvas uiCanvas { get; private set; }
            public IMainCharacter mainCharacter { get; private set; }
            private MainCamera m_mainCamera;
            private UICamera m_uiCamera;
            private FSMSystem fsmSystem;
            private GameObject gameObject;

            public LoginScene() {
                sceneName = GameConfig.EMPTY_SCENE;
                fsmSystem = new FSMSystem();
            } // end LoginScene

            public void Initialize() {
                m_mainCamera = new MainCamera();
                m_uiCamera = new UICamera();
                uiCanvas = new UICanvas(m_uiCamera.camera);
                gameObject = ObjectTool.InstantiateGo("LoginSceneBg", "Scene/LoginScene/LoginSceneBg", 
                    null, new Vector3(0, 0, 5.1f), Vector3.zero, Vector3.one);
                uiPanelFSM.PerformTransition(new UILoginPanel());
            } // end Initialize

            public void Update() {
                fsmSystem.Update();
            } // end Update

            public void LateUpdate() {
                if (null == mainCamera) return;
                // end if
                m_mainCamera.LateUpdate();
            } // end LateUpdate

            public void Dispose() {
                if (null == gameObject) Object.Destroy(gameObject);
                // end if
            } // end Dispose
        } // end class LoginScene 
    } // end namespace Scene
} // end namespace Custom
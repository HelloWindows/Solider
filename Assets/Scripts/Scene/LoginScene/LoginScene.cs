/*******************************************************************
 * FileName: LoginScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom;
using Framework.Interface.UI;
using Framework.Interface.View;
using Framework.Interface.Scene;
using Framework.Tools;
using Solider.Scene.UI;
using UnityEngine;
using Framework.FSM.Interface;
using Framework.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Scene {
        public class LoginScene : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get; private set; }
            public ICamera mainCamera { get; private set; }
            public ICanvas mainCanvas { get; private set; }
            public ICharacter mainCharacter { get; private set; }
            private IFSMSystem fsmSystem;
            private GameObject gameObject;

            public LoginScene() {
                sceneName = "Level";
                fsmSystem = new FSMSystem();
                uiPanelFSM = fsmSystem as IFSM;
            } // end LoginScene

            public void Initialize() {
                mainCamera = new MainCamera();
                mainCanvas = new MainCanvas(mainCamera.camera);
                gameObject = ObjectTool.InstantiateGo("LoginSceneBg", "Scene/LoginScene/LoginSceneBg", 
                    null, new Vector3(0, 0, 5.1f), Vector3.zero, Vector3.one);
                fsmSystem.AddState(new UILoginPanel("UILogin", uiPanelFSM, mainCanvas.rectTransform));
                fsmSystem.AddState(new UIRegisterPanel("UIRegister", uiPanelFSM, mainCanvas.rectTransform));
            } // end Initialize

            public void Update(float deltaTime) {
                fsmSystem.Update(deltaTime);
            } // end Update

            public void LateUpdate(float deltaTime) {
                if (null == mainCamera) return;
                // end if
                mainCamera.LateUpdate(deltaTime);
            } // end LateUpdate

            public void Dispose() {
                if (null == gameObject) Object.Destroy(gameObject);
                // end if
                fsmSystem.RemoveState("UILogin");
                fsmSystem.RemoveState("UIRegister");
            } // end Dispose
        } // end class LoginScene 
    } // end namespace Scene
} // end namespace Custom
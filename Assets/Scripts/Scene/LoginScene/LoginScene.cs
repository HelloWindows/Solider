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

namespace Solider {
    namespace Scene {
        public class LoginScene : IScene {
            public bool IsDispose { get; private set; }
            public string sceneName { get; private set; }
            public ICamera mainCamera { get; private set; }
            public ICanvas mainCanvas { get; private set; }

            public LoginScene() {
                IsDispose = true; // 初始化之前是销毁状态
                sceneName = "Level";
            } // end LoginScene

            public void Initialize() {
                mainCamera = new MainCamera();
                mainCanvas = new MainCanvas(mainCamera.camera);
                ObjectTool.InstantiateGo("LoginSceneBg", "Scene/LoginScene/LoginSceneBg", 
                    null, new Vector3(0, 0, 5), Vector3.zero, Vector3.one);
                ObjectTool.InstantiateGo("LoginPanelUI", "Scene/LoginScene/LoginPanelUI",
                    mainCanvas.rectTransform).AddComponent<UILoginPanel>();
                IsDispose = false;
            } // end Initialize

            public void Update(float deltaTime) {
                if (IsDispose) return; // 已经销毁
                // end if
                mainCamera.Update(Time.deltaTime);
            } // end Update

            public void Dispose() {
                IsDispose = true;
            } // end Dispose
        } // end class LoginScene 
    } // end namespace Scene
} // end namespace Custom
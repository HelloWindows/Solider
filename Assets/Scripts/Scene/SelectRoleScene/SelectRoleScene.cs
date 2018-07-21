/*******************************************************************
 * FileName: SelectRoleScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom;
using Framework.Interface.Scene;
using Framework.Interface.View;
using Framework.Interface.UI;
using Framework.Tools;
using Solider.Scene.UI;

namespace Solider {
    namespace Scene {
        public class SelectRoleScene : IScene {
            public ICamera mainCamera { get; private set; }
            public ICanvas mainCanvas { get; private set; }
            public bool IsDispose { get; private set; }
            public string sceneName{ get; private set; }

            public SelectRoleScene() {
                IsDispose = true; 
                sceneName = "Level";
            } // end SelectRoleScene

            public void Initialize() {
                mainCamera = new MainCamera();
                mainCanvas = new MainCanvas(mainCamera.camera);
                ObjectTool.InstantiateGo("SelectRolePanelUI", "Scene/SelectRoleScene/SelectRolePanelUI", 
                    mainCanvas.rectTransform).AddComponent<UISelectRolePanel>();
                IsDispose = false;
            } // end Initialize

            public void Update(float deltaTime) {
            } // end Update

            public void Dispose() {
                IsDispose = true;
            } // end Dispose
        } // end class SelectRoleScene 
    } // end namespace Scene
} // end namespace Custom
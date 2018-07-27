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
using Framework.FSM.Interface;
using Framework.FSM;

namespace Solider {
    namespace Scene {
        public class SelectRoleScene : IScene {
            public ICamera mainCamera { get; private set; }
            public ICanvas mainCanvas { get; private set; }
            public IFSM uiPanelFSM { get; private set; }
            public bool isDispose { get; private set; }
            public string sceneName{ get; private set; }
            private IFSMSystem fsmSystem;

            public SelectRoleScene() {
                isDispose = true; 
                sceneName = "Level";
                fsmSystem = new FSMSystem();
            } // end SelectRoleScene

            public void Initialize() {
                mainCamera = new MainCamera();
                mainCanvas = new MainCanvas(mainCamera.camera);
                ObjectTool.InstantiateGo("SelectRolePanelUI", "Scene/SelectRoleScene/SelectRolePanelUI", 
                    mainCanvas.rectTransform).AddComponent<UISelectRolePanel>();
                isDispose = false;
            } // end Initialize

            public void Update(float deltaTime) {
            } // end Update

            public void Dispose() {
                isDispose = true;
            } // end Dispose
        } // end class SelectRoleScene 
    } // end namespace Scene
} // end namespace Custom
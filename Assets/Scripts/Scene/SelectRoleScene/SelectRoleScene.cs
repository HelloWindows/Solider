/*******************************************************************
 * FileName: SelectRoleScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom.View;
using Framework.Interface.Scene;
using Framework.Interface.View;
using Framework.Interface.UI;
using Solider.Scene.UI;
using Framework.FSM.Interface;
using Framework.FSM;
using Solider.Character.Interface;
using Framework.Config.Game;
using Framework.Custom.UI;

namespace Solider {
    namespace Scene {
        public class SelectRoleScene : IScene {
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IUICamera uiCamera { get { return m_uiCamera; } }
            public ICanvas uiCanvas { get; private set; }
            public IMainCharacter mainCharacter { get; private set; }
            public IFSM uiPanelFSM { get { return fsmSystem; } }
            public string sceneName{ get; private set; }
            private UICamera m_uiCamera;
            private MainCamera m_mainCamera;
            private FSMSystem fsmSystem;

            public SelectRoleScene() {
                sceneName = GameConfig.EMPTY_SCENE;
                fsmSystem = new FSMSystem();
            } // end SelectRoleScene

            public void Initialize() {
                m_mainCamera = new MainCamera();
                m_uiCamera = new UICamera();
                uiCanvas = new UICanvas(m_uiCamera.camera);
                uiPanelFSM.PerformTransition(new UISelectRolePanel());
            } // end Initialize

            public void Update() {
            } // end Update

            public void LateUpdate() {
            } // end LateUpdate

            public void Dispose() {
            } // end Dispose
        } // end class SelectRoleScene 
    } // end namespace Scene
} // end namespace Custom
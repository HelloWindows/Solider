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
using Framework.Interface.Audio;
using Framework.Custom.Audio;

namespace Solider {
    namespace Scene {
        public class SelectRoleScene : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get { return fsmSystem; } }
            public IMainAudio mainAudio { get { return m_mainAudio; } }
            public IMainCanvas mainCanvas { get { return m_mainCanvas; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IMainCharacter mainCharacter { get; private set; }

            private MainAudio m_mainAudio;
            private MainCanvas m_mainCanvas;
            private MainCamera m_mainCamera;
            private FSMSystem fsmSystem;

            public SelectRoleScene() {
                sceneName = GameConfig.EMPTY_SCENE;
                fsmSystem = new FSMSystem();
            } // end SelectRoleScene

            public void Initialize() {
                m_mainAudio = new MainAudio();
                m_mainCanvas = new MainCanvas();
                m_mainCamera = new MainCamera();
                m_mainAudio.PlayBackgroundMusic("select_role_scene_bgm");
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
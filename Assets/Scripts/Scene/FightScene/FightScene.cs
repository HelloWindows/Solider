﻿/*******************************************************************
 * FileName: FightScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom.UI;
using Framework.Custom.View;
using Framework.Interface.Scene;
using Framework.Interface.View;
using Framework.Interface.UI;
using Framework.FSM.Interface;
using Framework.FSM;
using Solider.Scene.UI;
using Solider.Character.Interface;
using Framework.Tools;
using Framework.Config.Game;
using Framework.Interface.Audio;
using Framework.Custom.Audio;
using Solider.Factory;

namespace Solider {
    namespace Scene {
        public class FightScene : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get { return m_fsmSystem; } }
            public IMainAudio mainAudio { get { return m_mainAudio; } }
            public IMainCanvas mainCanvas { get { return m_mainCanvas; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IMainCharacter mainCharacter { get { return m_characterFactory.mainCharacter; } }
            public ICharacterFactory charcterFactory { get { return m_characterFactory; } }

            private FSMSystem m_fsmSystem;
            private MainAudio m_mainAudio;
            private MainCanvas m_mainCanvas;
            private MainCamera m_mainCamera;
            private CharacterFactory m_characterFactory;

            public FightScene() {
                sceneName = GameConfig.FIGHT_SCENE;
                m_fsmSystem = new FSMSystem();
                m_characterFactory = new CharacterFactory();
            } // end NoviceVillage

            public void Initialize() {
                m_mainCanvas = new MainCanvas();
                m_mainAudio = new MainAudio();
                m_mainCamera = new MainCamera();
                m_characterFactory.CreateMainCharacter(new UnityEngine.Vector3(0, 0, -20));
                m_mainAudio.PlayBackgroundMusic("fight_scene_bgm");
                if (null == mainCharacter) {
                    DebugTool.ThrowException("NoviceVillage CreateMainCharacter is null!!");
                    return;
                } // end if
                m_mainCamera.SetTarget(mainCharacter);
                mainCharacter.fsm.PerformTransition("wait");
                uiPanelFSM.PerformTransition(new UIFightPanel());
            } // end Initialize

            public void Update() {
                m_fsmSystem.Update();
                m_characterFactory.Update();
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
                if (null != m_characterFactory) m_characterFactory.Dispose();
                // end if
            } // end Dispose
        } // end class NoviceVillage 
    } // end namespace Scene
} // end namespace Solider
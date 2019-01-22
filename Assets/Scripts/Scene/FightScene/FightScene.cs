/*******************************************************************
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
using Solider.Character.Manager;

namespace Solider {
    namespace Scene {
        public class FightScene : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get { return m_fsmSystem; } }
            public IMainAudio mainAudio { get { return m_mainAudio; } }
            public IMainCanvas mainCanvas { get { return m_mainCanvas; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IMainCharacter mainCharacter { get { return m_characterManager.mainCharacter; } }
            public ICharacterManager characterManager { get { return m_characterManager; } }

            private FSMSystem m_fsmSystem;
            private MainAudio m_mainAudio;
            private MainCanvas m_mainCanvas;
            private MainCamera m_mainCamera;
            private CharacterManager m_characterManager;

            public FightScene() {
                sceneName = GameConfig.FIGHT_SCENE;
                m_fsmSystem = new FSMSystem();
                m_characterManager = new CharacterManager();
            } // end NoviceVillage

            public void Initialize() {
                m_mainCanvas = new MainCanvas();
                m_mainAudio = new MainAudio();
                m_mainCamera = new MainCamera();
                m_characterManager.factory.CreateMainCharacter(new UnityEngine.Vector3(0, 0, -20));
                m_characterManager.factory.CreateNPC("906003", new UnityEngine.Vector3(0, 0, 0));
                //m_characterManager.factory.CreateNPC("901001", new UnityEngine.Vector3(0, 0, 0));
                //m_characterManager.factory.CreateNPC("902001", new UnityEngine.Vector3(0, 0, 0));
                //m_characterManager.factory.CreateNPC("903001", new UnityEngine.Vector3(0, 0, 10));
                //m_characterManager.factory.CreateNPC("904001", new UnityEngine.Vector3(5, 0, 10));
                //m_characterManager.factory.CreateNPC("904002", new UnityEngine.Vector3(10, 0, 10));
                //m_characterManager.factory.CreateNPC("904003", new UnityEngine.Vector3(15, 0, 10));
                //m_characterManager.factory.CreateNPC("904004", new UnityEngine.Vector3(15, 0, 15));
                //m_characterManager.factory.CreateNPC("904005", new UnityEngine.Vector3(20, 0, 15));
                //m_characterManager.factory.CreateNPC("904006", new UnityEngine.Vector3(20, 0, 20));
                //m_characterManager.factory.CreateNPC("904007", new UnityEngine.Vector3(25, 0, 20));
                //m_characterManager.factory.CreateNPC("904008", new UnityEngine.Vector3(25, 0, 25));
                //m_characterManager.factory.CreateNPC("904009", new UnityEngine.Vector3(30, 0, 25));
                //m_characterManager.factory.CreateNPC("904010", new UnityEngine.Vector3(30, 0, 30));
                //m_characterManager.factory.CreateNPC("905001", new UnityEngine.Vector3(35, 0, 30));
                //m_characterManager.factory.CreateNPC("905002", new UnityEngine.Vector3(35, 0, 35));
                //m_characterManager.factory.CreateNPC("905003", new UnityEngine.Vector3(40, 0, 35));
                m_mainAudio.PlayBackgroundMusic("fight_scene_bgm");
                if (null == mainCharacter) {
                    DebugTool.LogError("NoviceVillage CreateMainCharacter is null!!");
                    return;
                } // end if
                m_mainCamera.SetTarget(mainCharacter);
                mainCharacter.fsm.PerformTransition("wait");
                uiPanelFSM.PerformTransition(new UIFightPanel());
            } // end Initialize

            public void Update() {
                m_fsmSystem.Update();
                m_characterManager.Update();
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
                if (null != m_characterManager) m_characterManager.Dispose();
                // end if
            } // end Dispose
        } // end class NoviceVillage 
    } // end namespace Scene
} // end namespace Solider
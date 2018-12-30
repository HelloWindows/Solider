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
using System.Collections.Generic;
using Solider.Character.Interface;
using UnityEngine;
using Solider.Manager;
using Framework.Tools;
using Framework.Config.Const;
using Framework.Config.Game;
using Solider.Character.MainCharacter;
using Framework.Interface.Audio;
using Framework.Custom.Audio;

namespace Solider {
    namespace Scene {
        public class FightScene : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get { return m_fsmSystem; } }
            public IMainAudio mainAudio { get { return m_mainAudio; } }
            public IMainCanvas mainCanvas { get { return m_mainCanvas; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IMainCharacter mainCharacter { get { return m_mainCharacter; } }

            private FSMSystem m_fsmSystem;
            private MainAudio m_mainAudio;
            private MainCanvas m_mainCanvas;
            private MainCamera m_mainCamera;
            private MainCharacter m_mainCharacter;
            private List<Character.Character> charList;

            public FightScene() {
                sceneName = GameConfig.FIGHT_SCENE;
                m_fsmSystem = new FSMSystem();
                charList = new List<Character.Character>();
            } // end NoviceVillage

            public void Initialize() {
                m_mainCanvas = new MainCanvas();
                m_mainAudio = new MainAudio();
                m_mainCamera = new MainCamera();
                m_mainAudio.PlayBackgroundMusic("fight_scene_bgm");
                m_mainCharacter = CreateMainCharacter(new Vector3(0, 0, -20));
                if (null == mainCharacter) {
                    DebugTool.ThrowException("NoviceVillage CreateMainCharacter is null!!");
                    return;
                } // end if
                m_mainCamera.SetTarget(mainCharacter);
                mainCharacter.fsm.PerformTransition("wait");
                charList.Add(m_mainCharacter);
                uiPanelFSM.PerformTransition(new UIFightPanel());
            } // end Initialize

            public void Update() {
                m_fsmSystem.Update();
                List<int> indexList = new List<int>();
                for (int i = 0; i < charList.Count; i++) {
                    if (charList[i].isDisposed) indexList.Add(i);
                    // end if
                } // end for
                for (int i = 0; i < indexList.Count; i++) {
                    charList.RemoveAt(i);
                } // end for
                for (int i = 0; i < charList.Count; i++) {
                    charList[i].Update();
                } // end for
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
                if (null != m_mainCharacter) m_mainCharacter.Dispose();
                // end if
            } // end Dispose

            public MainCharacter CreateMainCharacter(Vector3 position) {
                if (null == GameManager.playerInfo || null == GameManager.playerInfo.roleType ||
                    GameManager.playerInfo.roleType == "" || null != mainCharacter) return null;
                // end if
                switch (GameManager.playerInfo.roleType) {
                    case ConstConfig.SWORDMAN:
                        return new SwordmanCharacter(ConstConfig.SWORDMAN, position, GameManager.playerInfo.rolename);

                    case ConstConfig.ARCHER:
                        return new ArcherCharacter(ConstConfig.ARCHER, position, GameManager.playerInfo.rolename);

                    case ConstConfig.MAGICIAN:
                        return new MagicianCharacter(ConstConfig.MAGICIAN, position, GameManager.playerInfo.rolename);
                } // end switch
                return null;
            } // end CreateMainCharacter
        } // end class NoviceVillage 
    } // end namespace Scene
} // end namespace Solider
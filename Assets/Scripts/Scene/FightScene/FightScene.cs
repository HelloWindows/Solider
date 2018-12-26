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
using System.Collections.Generic;
using Solider.Character.Interface;
using UnityEngine;
using Solider.Manager;
using Framework.Tools;
using Framework.Config.Const;
using Framework.Config.Game;
using Solider.Character.MainCharacter;

namespace Solider {
    namespace Scene {
        public class FightScene : IScene {
            public IFSM uiPanelFSM { get; private set; }
            public IUICamera uiCamera { get { return m_uiCamera; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public ICanvas uiCanvas { get { return m_uiCanvas; } }
            public IMainCharacter mainCharacter { get { return m_mainCharacter; } }
            public string sceneName { get; private set; }

            private MainCamera m_mainCamera;
            private MainCharacter m_mainCharacter;
            private UICamera m_uiCamera;
            private UICanvas m_uiCanvas;
            private IFSMSystem fsmSystem;
            private List<Character.Character> charList;

            public FightScene() {
                sceneName = GameConfig.FIGHT_SCENE;
                fsmSystem = new FSMSystem();
                charList = new List<Character.Character>();
                uiPanelFSM = fsmSystem as IFSM;
            } // end NoviceVillage

            public void Initialize() {
                m_mainCamera = new MainCamera();
                m_uiCamera = new UICamera();
                m_uiCanvas = new UICanvas(m_uiCamera.camera);
                m_mainCharacter = CreateMainCharacter(new Vector3(0, 0, -20));
                uiPanelFSM.PerformTransition(new UIFightPanel());
                if (null == mainCharacter) {
                    DebugTool.ThrowException("NoviceVillage CreateMainCharacter is null!!");
                    return;
                } // end if
                m_mainCamera.SetTarget(mainCharacter);
                mainCharacter.fsm.PerformTransition("wait");
                charList.Add(m_mainCharacter);
            } // end Initialize

            public void Update() {
                fsmSystem.Update();
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
                if(null != m_mainCharacter) m_mainCharacter.Dispose();
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
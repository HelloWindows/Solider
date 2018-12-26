/*******************************************************************
 * FileName: MainGameScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom.UI;
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
using Framework.Config;
using Solider.Character.NPC;
using Framework.Config.Const;
using Framework.Config.Game;
using Framework.Custom.View;
using Solider.Character.MainCharacter;

namespace Solider {
    namespace Scene {
        public class NoviceVillage : IScene {
            public IFSM uiPanelFSM { get; private set; }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IUICamera uiCamera { get { return m_uiCamera; } }
            public ICanvas uiCanvas { get; private set; }
            public IMainCharacter mainCharacter { get { return m_mainCharacter; } }
            public string sceneName { get; private set; }
            private UICamera m_uiCamera;
            private MainCamera m_mainCamera;
            private MainCharacter m_mainCharacter;
            private IFSMSystem fsmSystem;
            private List<int> indexList;
            private List<Character.Character> characterList;

            public NoviceVillage() {
                sceneName = GameConfig.NOVICE_VILLAGE;
                fsmSystem = new FSMSystem();
                indexList = new List<int>();
                characterList = new List<Character.Character>();
                uiPanelFSM = fsmSystem as IFSM;
            } // end NoviceVillage

            public void Initialize() {
                m_mainCamera = new MainCamera();
                m_uiCamera = new UICamera();
                uiCanvas = new UICanvas(m_uiCamera.camera);
                uiPanelFSM.PerformTransition(new UITownPanel());
                m_mainCharacter = CreateMainCharacter(new Vector3(0, 0, -20));
                if (null == mainCharacter) {
                    DebugTool.ThrowException("NoviceVillage CreateMainCharacter is null!!");
                    return;
                } // end if
                ObjectTool.InstantiateGo("npc_grocery", Configs.prefabConfig.GetPath("npc_grocery"),
                    null, new Vector3(24, 0, 3), new Vector3(0, 210, 0), Vector3.one).AddComponent<NPC_Grocery>();
                ObjectTool.InstantiateGo("npc_forge", Configs.prefabConfig.GetPath("npc_forge"),
                    null, new Vector3(-5, 0, 2), new Vector3(0, 160, 0), Vector3.one).AddComponent<NPC_Forge>();
                ObjectTool.InstantiateGo("npc_transmitter", Configs.prefabConfig.GetPath("npc_transmitter"),
                    null, new Vector3(17, 0, -24), new Vector3(0, 270, 0), Vector3.one).AddComponent<NPC_Transmitter>();
                m_mainCamera.SetTarget(mainCharacter);
                mainCharacter.fsm.PerformTransition("idle");
                characterList.Add(m_mainCharacter);
            } // end Initialize

            public void Update() {
                fsmSystem.Update();
                indexList.Clear();
                for (int i = 0; i < characterList.Count; i++) {
                    if (characterList[i].isDisposed) indexList.Add(i);
                    // end if
                } // end for
                for (int i = 0; i < indexList.Count; i++) {
                    characterList.RemoveAt(indexList[i]);
                } // end for
                for (int i = 0; i < characterList.Count; i++) {
                    characterList[i].Update();
                } // end for
            } // end Update

            public void LateUpdate() {
                if (null == mainCamera) return;
                // end if
                m_mainCamera.LateUpdate();
            } // end LateUpdate

            public void Dispose() {
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
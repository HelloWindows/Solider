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
using Framework.Interface.Audio;
using Framework.Custom.Audio;

namespace Solider {
    namespace Scene {
        public class NoviceVillage : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get { return fsmSystem; } }
            public IMainAudio mainAudio { get { return m_mainAudio; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IMainCanvas mainCanvas { get { return m_mainCanvas; } }
            public IMainCharacter mainCharacter { get { return m_mainCharacter; } }

            private MainAudio m_mainAudio;
            private MainCanvas m_mainCanvas;
            private MainCamera m_mainCamera;
            private MainCharacter m_mainCharacter;
            private FSMSystem fsmSystem;
            private List<int> indexList;
            private List<Character.Character> characterList;

            public NoviceVillage() {
                sceneName = GameConfig.NOVICE_VILLAGE;
                fsmSystem = new FSMSystem();
                indexList = new List<int>();
                characterList = new List<Character.Character>();
            } // end NoviceVillage

            public void Initialize() {
                m_mainAudio = new MainAudio();
                m_mainCanvas = new MainCanvas();
                m_mainCamera = new MainCamera();
                m_mainAudio.PlayBackgroundMusic("novice_village_bgm");
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
                uiPanelFSM.PerformTransition(new UITownPanel());
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
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
using Solider.Character.Interface;
using UnityEngine;
using Solider.Manager;
using Framework.Tools;
using Solider.Character.NPC;
using Framework.Config.Const;
using Framework.Config.Game;
using Framework.Custom.View;
using Solider.Character.MainCharacter;
using Framework.Interface.Audio;
using Framework.Custom.Audio;
using Solider.Character.Manager;

namespace Solider {
    namespace Scene {
        public class NoviceVillage : IScene {
            public string sceneName { get; private set; }
            public IFSM uiPanelFSM { get { return fsmSystem; } }
            public IMainAudio mainAudio { get { return m_mainAudio; } }
            public IMainCamera mainCamera { get { return m_mainCamera; } }
            public IMainCanvas mainCanvas { get { return m_mainCanvas; } }
            public IMainCharacter mainCharacter { get { return m_characterManager.mainCharacter; } }
            public ICharacterManager characterManager { get { return m_characterManager; } }

            private MainAudio m_mainAudio;
            private MainCanvas m_mainCanvas;
            private MainCamera m_mainCamera;
            private CharacterManager m_characterManager;

            private FSMSystem fsmSystem;

            public NoviceVillage() {
                sceneName = GameConfig.NOVICE_VILLAGE;
                fsmSystem = new FSMSystem();
                m_characterManager = new CharacterManager();
            } // end NoviceVillage

            public void Initialize() {
                m_mainAudio = new MainAudio();
                m_mainCanvas = new MainCanvas();
                m_mainCamera = new MainCamera();
                m_characterManager.factory.CreateMainCharacter(new Vector3(0, 0, -20));
                m_mainAudio.PlayBackgroundMusic("novice_village_bgm");
                if (null == mainCharacter) {
                    DebugTool.ThrowException("NoviceVillage CreateMainCharacter is null!!");
                    return;
                } // end if
                ObjectTool.InstantiateGo("npc_grocery", ResourcesTool.LoadPrefab("npc_grocery"),
                    null, new Vector3(24, 0, 3), new Vector3(0, 210, 0), Vector3.one).AddComponent<NPC_Grocery>();
                ObjectTool.InstantiateGo("npc_forge", ResourcesTool.LoadPrefab("npc_forge"),
                    null, new Vector3(-5, 0, 2), new Vector3(0, 160, 0), Vector3.one).AddComponent<NPC_Forge>();
                ObjectTool.InstantiateGo("npc_transmitter", ResourcesTool.LoadPrefab("npc_transmitter"),
                    null, new Vector3(17, 0, -24), new Vector3(0, 270, 0), Vector3.one).AddComponent<NPC_Transmitter>();
                m_mainCamera.SetTarget(mainCharacter);
                mainCharacter.fsm.PerformTransition("idle");
                uiPanelFSM.PerformTransition(new UITownPanel());
            } // end Initialize

            public void Update() {
                fsmSystem.Update();
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
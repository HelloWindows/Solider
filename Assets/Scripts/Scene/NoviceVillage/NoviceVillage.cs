﻿/*******************************************************************
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
using Solider.Character.Swordman;
using UnityEngine;
using Solider.Manager;
using Framework.Tools;
using Framework.Config;
using Solider.Character.NPC;
using Framework.Config.Const;
using Solider.Character.Archer;
using Solider.Character.Magician;
using Framework.Config.Game;
using Framework.Custom.View;
using Solider.Character.FSMState;

namespace Solider {
    namespace Scene {
        public class NoviceVillage : IScene {
            private float timer;
            public IFSM uiPanelFSM { get; private set; }
            public ICamera mainCamera { get; private set; }
            public ICanvas mainCanvas { get; private set; }
            public ICharacter mainCharacter { get; private set; }
            public string sceneName { get; private set; }
            private IFSMSystem fsmSystem;
            private List<ICharacter> charList;

            public NoviceVillage() {
                sceneName = GameConfig.NOVICE_VILLAGE;
                fsmSystem = new FSMSystem();
                charList = new List<ICharacter>();
                uiPanelFSM = fsmSystem as IFSM;
            } // end NoviceVillage

            public void Initialize() {
                timer = 0;
                mainCamera = new MainCamera();
                mainCanvas = new MainCanvas(mainCamera.camera);
                uiPanelFSM.PerformTransition(new UITownPanel());
                mainCharacter = CreateMainCharacter(new Vector3(0, 0, -20));
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
                mainCamera.SetTarget(mainCharacter);
                mainCharacter.fsm.PerformTransition(new BaseState("idle"));
                charList.Add(mainCharacter);
            } // end Initialize

            public void Update(float deltaTime) {
                fsmSystem.Update(deltaTime);
                List<int> indexList = new List<int>();
                for (int i = 0; i < charList.Count; i++) {
                    if (charList[i].isDisposed) indexList.Add(i);
                    // end if
                } // end for
                for (int i = 0; i < indexList.Count; i++) {
                    charList.RemoveAt(i);
                } // end for
                for (int i = 0; i < charList.Count; i++) {
                    charList[i].Update(deltaTime);
                } // end for
                timer += deltaTime;
                if (timer > 1) {
                    timer = 0;
                    for (int i = 0; i < charList.Count; i++) {
                        charList[i].info.SelfHealing();
                    } // end if
                } // end if
            } // end Update

            public void LateUpdate(float deltaTime) {
                if (null == mainCamera) return;
                // end if
                mainCamera.LateUpdate(deltaTime);
            } // end LateUpdate

            public void Dispose() {
                mainCharacter.Dispose();
            } // end Dispose

            public ICharacter CreateMainCharacter(Vector3 position) {
                if (null == GameManager.playerInfo || null == GameManager.playerInfo.roleType ||
                    GameManager.playerInfo.roleType == "" || null != mainCharacter) return null;
                // end if
                switch (GameManager.playerInfo.roleType) {
                    case ConstConfig.SWORDMAN:
                        return new SwordmanCharacter(position, GameManager.playerInfo.rolename);

                    case ConstConfig.ARCHER:
                        return new ArcherCharacter(position, GameManager.playerInfo.rolename);

                    case ConstConfig.MAGICIAN:
                        return new MagicianCharacter(position, GameManager.playerInfo.rolename);
                } // end switch
                return null;
            } // end CreateMainCharacter
        } // end class NoviceVillage 
    } // end namespace Scene
} // end namespace Solider
/*******************************************************************
 * FileName: MainGameScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom;
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
                sceneName = "NoviceVillage";
                fsmSystem = new FSMSystem();
                charList = new List<ICharacter>();
                uiPanelFSM = fsmSystem as IFSM;
            } // end NoviceVillage

            public void Initialize() {
                timer = 0;
                mainCamera = new MainCamera();
                mainCanvas = new MainCanvas(mainCamera.camera);
                fsmSystem.AddState(new UITownPanel("UITownPanel", uiPanelFSM, mainCanvas.rectTransform));
                fsmSystem.AddState(new UIMainPanel("UIMainPanel", mainCanvas.rectTransform));
                fsmSystem.AddState(new UIInfoPanel("UIInfoPanel", uiPanelFSM, mainCanvas.rectTransform));
                fsmSystem.AddState(new UIPackPanel("UIPackPanel", uiPanelFSM, mainCanvas.rectTransform));
                fsmSystem.AddState(new UISettingPanel("UISettingPanel", uiPanelFSM, mainCanvas.rectTransform));
                mainCharacter = new SwordmanCharacter(new Vector3(0, 0, -20), GameManager.playerInfo.rolename);
                ObjectTool.InstantiateGo("npc_grocery", Configs.prefabConfig.GetPath("npc_grocery"),
                    null, new Vector3(24, 0, 3), new Vector3(0, 210, 0), Vector3.one).AddComponent<NPC_Grocery>();
                mainCamera.SetTarget(mainCharacter);
                charList.Add(mainCharacter);
            } // end Initialize

            public void Update(float deltaTime) {
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
            } // end Dispose
        } // end class NoviceVillage 
    } // end namespace Scene
} // end namespace Custom
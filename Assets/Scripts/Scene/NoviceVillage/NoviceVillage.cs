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
using Framework.Tools;
using Framework.FSM.Interface;
using Framework.FSM;
using Solider.Scene.UI;

namespace Solider {
    namespace Scene {
        public class NoviceVillage : IScene {
            private float timer;
            public bool isDispose { get; private set; }
            public IFSM uiPanelFSM { get; private set; }
            public ICamera mainCamera { get; private set; }
            public ICanvas mainCanvas { get; private set; }
            public string sceneName { get; private set; }
            private IFSMSystem fsmSystem;

            public NoviceVillage() {
                isDispose = true;
                sceneName = "NoviceVillage";
                fsmSystem = new FSMSystem();
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
                isDispose = false;
            } // end Initialize

            public void Update(float deltaTime) {
                if (isDispose) return;
                // end if
                timer += deltaTime;
                if (timer > 1) {
                    timer = 0;
                    //RoleManager.info.SelfHealing();
                } // end if
            } // end Update

            public void Dispose() {
                isDispose = true;
            } // end Dispose
        } // end class NoviceVillage 
    } // end namespace Scene
} // end namespace Custom
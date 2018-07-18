/*******************************************************************
 * FileName: MainGameScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom;
using Framework.Interface;
using Framework.Manager;
using Framework.Tools;
using Solider.Manager;
using Solider.UI.Common;

namespace Solider {
    namespace Scene {
        public class NoviceVillage : IScene {
            private float timer;
            public bool IsDispose { get; private set; }
            public ICamera mainCamera { get; private set; }
            public ICanvas mainCanvas { get; private set; }
            public string sceneName { get; private set; }

            public NoviceVillage() {
                IsDispose = true;
                sceneName = "Level";
            } // end NoviceVillage

            public void Initialize() {
                timer = 0;
                mainCamera = new MainCamera();
                mainCanvas = new MainCanvas(mainCamera.camera);
                ObjectTool.InstantiateGo("MainPanelUI", "UI/Common/MainPanelUI", 
                    mainCanvas.rectTransform).AddComponent<UIMainPanel>();
                ObjectTool.InstantiateGo("TownPanelUI", "UI/Common/TownPanelUI", 
                    mainCanvas.rectTransform).AddComponent<UITownPanel>();
                IsDispose = false;
            } // end Initialize

            public void Update(float deltaTime) {
                if (IsDispose) return;
                // end if
                timer += deltaTime;
                if (timer > 1) {
                    timer = 0;
                    RoleManager.info.SelfHealing();
                } // end if
            } // end Update

            public void Dispose() {
                IsDispose = true;
            } // end Dispose
        } // end class NoviceVillage 
    } // end namespace Scene
} // end namespace Custom
/*******************************************************************
 * FileName: IScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.View;
using Framework.Interface.UI;
using Framework.FSM.Interface;
using Solider.Character.Interface;
using System;

namespace Framework {
    namespace Interface {
        namespace Scene {
            public interface IScene : IDisposable {
                IFSM uiPanelFSM { get; }
                IMainCamera mainCamera { get; }
                IUICamera uiCamera { get; }
                ICanvas uiCanvas { get; }
                IMainCharacter mainCharacter { get; }
                string sceneName { get; }
                void Initialize();
                void Update();
                void LateUpdate();
            } // end interface IScene 
        } // end namespace Scene
    } // end namespace Interface
} // end namespace Framework
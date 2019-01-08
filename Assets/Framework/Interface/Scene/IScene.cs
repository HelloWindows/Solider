/*******************************************************************
 * FileName: IScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using Framework.Interface.View;
using Framework.Interface.UI;
using Framework.FSM.Interface;
using Framework.Interface.Audio;
using Solider.Character.Interface;

namespace Framework {
    namespace Interface {
        namespace Scene {
            public interface IScene : IDisposable {
                string sceneName { get; }
                IFSM uiPanelFSM { get; }
                IMainAudio mainAudio { get; }
                IMainCamera mainCamera { get; }
                IMainCanvas mainCanvas { get; }
                IMainCharacter mainCharacter { get; }
                ICharacterManager characterManager { get; }
                void Initialize();
                void Update();
                void LateUpdate();
            } // end interface IScene 
        } // end namespace Scene
    } // end namespace Interface
} // end namespace Framework
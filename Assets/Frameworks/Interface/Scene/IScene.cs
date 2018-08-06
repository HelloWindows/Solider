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

namespace Framework {
    namespace Interface {
        namespace Scene {
            public interface IScene {
                IFSM uiPanelFSM { get; }
                ICamera mainCamera { get; }
                ICanvas mainCanvas { get; }
                ICharacter mainCharacter { get; }
                string sceneName { get; }
                void Initialize();
                void Update(float deltaTime);
                void LateUpdate(float deltaTime);
                void Dispose();
            } // end interface IScene 
        } // end namespace Scene
    } // end namespace Interface
} // end namespace Framework
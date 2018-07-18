/*******************************************************************
 * FileName: IScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Framework {
    namespace Interface {
        public interface IScene {
            bool IsDispose { get; }
            ICamera mainCamera { get; }
            ICanvas mainCanvas { get; }
            string sceneName { get; }
            void Initialize();
            void Update(float deltaTime);
            void Dispose();
        } // end interface IScene 
    } // end namespace Interface
} // end namespace Framework
/*******************************************************************
 * FileName: MainCamera.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.View;
using UnityEngine;

namespace Framework {
    namespace Custom {
        public class MainCamera : ICamera {
            public Camera camera { get; private set; }

            public MainCamera() {
                GameObject Go = new GameObject("MainCamera");
                camera = Go.AddComponent<Camera>();
                camera.tag = "MainCamera";
                camera.clearFlags = CameraClearFlags.Skybox;
                camera.orthographic = false;
                camera.fieldOfView = 60f;
                camera.depth = -1;
                camera.renderingPath = RenderingPath.UsePlayerSettings;
                Go.AddComponent<GUILayer>();
                Go.AddComponent<FlareLayer>();
            } // end MainCamera

            public void Update(float deltaTime) {
            } // end Update
        } // end class MainCamera 
    } // end namespace Custom
} // end namespace Framework
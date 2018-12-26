﻿/*******************************************************************
 * FileName: UICamera.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Interface.View;
using UnityEngine;

namespace Framework {
    namespace Custom {
        namespace View {
            public class UICamera : IUICamera {
                public Camera camera { get; private set; }

                public UICamera() {
                    GameObject Go = new GameObject("UICamera");
                    camera = Go.AddComponent<Camera>();
                    camera.clearFlags = CameraClearFlags.Nothing;
                    camera.cullingMask = LayerMask.GetMask(LayerConfig.UI); // 显示UI层
                    camera.orthographic = true;
                    camera.orthographicSize = System.Convert.ToSingle(Screen.height) / 2f / 100;
                    camera.nearClipPlane = 0;
                    camera.farClipPlane = 20;
                    camera.depth = 0;
                    camera.renderingPath = RenderingPath.UsePlayerSettings;
                } // end UICamera
            } // end class UICamera 
        } // end namespace View 
    } // end namespace Custom
} // end namespace Framework
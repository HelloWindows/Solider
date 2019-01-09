/*******************************************************************
 * FileName: UICamera.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Interface.View;
using System;
using UnityEngine;

namespace Framework {
    namespace Custom {
        namespace View {
            public class UICamera : IUICamera, IDisposable {
                public Camera camera { get; private set; }

                public UICamera() {
                    GameObject Go = new GameObject("UICamera");
                    camera = Go.AddComponent<Camera>();
                    camera.clearFlags = CameraClearFlags.Nothing;
                    camera.cullingMask = LayerMask.GetMask(LayerConfig.UI); // 显示UI层
                    camera.orthographic = true;
                    camera.orthographicSize = Convert.ToSingle(Screen.height) / 2f / GameConfig.PIXEL_PER_UNIT;
                    camera.nearClipPlane = 0;
                    camera.farClipPlane = 20;
                    camera.depth = 0;
                    camera.renderingPath = RenderingPath.UsePlayerSettings;
                } // end UICamera

                public void Dispose() {
                    if (null != camera) UnityEngine.Object.Destroy(camera.gameObject);
                    // end if
                } // end Dispose
            } // end class UICamera 
        } // end namespace View 
    } // end namespace Custom
} // end namespace Framework
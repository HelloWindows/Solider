/*******************************************************************
 * FileName: MainCanvas.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Custom.View;
using Framework.Interface.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Framework {
    namespace Custom {
        namespace UI {
            public class MainCanvas : IMainCanvas, IDisposable {
                public Camera camera { get { return m_uiCamera.camera; } }
                public Canvas canvas { get; private set; }
                public RectTransform rectTransform { get; private set; }

                private UICamera m_uiCamera;

                public MainCanvas() {
                    m_uiCamera = new UICamera();
                    GameObject Go = new GameObject("UICanvas");
                    Go.layer = LayerMask.NameToLayer(LayerConfig.UI);
                    canvas = Go.AddComponent<Canvas>();
                    canvas.renderMode = RenderMode.ScreenSpaceCamera;
                    canvas.worldCamera = camera;
                    canvas.planeDistance = 10;
                    CanvasScaler scaler = Go.AddComponent<CanvasScaler>();
                    scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                    scaler.referenceResolution = new Vector2(GameConfig.STANDARD_WIDTH, GameConfig.STANDARD_HEIGHT);
                    scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                    GraphicRaycaster raycaster = Go.AddComponent<GraphicRaycaster>();
                    raycaster.ignoreReversedGraphics = true;
                    raycaster.blockingObjects = GraphicRaycaster.BlockingObjects.None;
                    scaler.matchWidthOrHeight = 1; // Height 权重
                    rectTransform = canvas.transform as RectTransform;
                    GameObject esGo = new GameObject("EventSystem");
                    esGo.AddComponent<EventSystem>();
                    esGo.AddComponent<StandaloneInputModule>();
                } // end MainCanvas

                /// <summary>
                /// 简单的适配一下
                /// </summary>
                /// <param name="scaler"></param>
                private void Adjusting(CanvasScaler scaler) {
                    float adjustor = 0f; //屏幕矫正比例
                    float device_width = Screen.width; //当前设备宽度
                    float device_height = Screen.height; //当前设备高度                
                    float standard_aspect = GameConfig.STANDARD_WIDTH / GameConfig.STANDARD_HEIGHT; //计算宽高比例
                    float device_aspect = device_width / device_height;
                    if (device_aspect < standard_aspect) //计算矫正比例
                        adjustor = standard_aspect / device_aspect;
                    // end if
                    if (adjustor == 0) 
                        scaler.matchWidthOrHeight = 1; // Height 权重
                    else
                        scaler.matchWidthOrHeight = 0; // Width 权重
                    // end if
                } // end Adjusting

                public void Dispose() {
                    if (null != m_uiCamera) m_uiCamera.Dispose();
                    // end if
                    if (null != canvas) UnityEngine.Object.Destroy(canvas.gameObject);
                    // end if
                } // end Dispose
            } // end class MainCanvas 
        } // end namespace UI
    } // end namespace Custom 
} // end namespace Framework
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
                public Canvas HUD_Canvas { get; private set; }
                public Vector2 sizeDelta { get; private set; }
                public RectTransform rectTransform { get; private set; }
                public RectTransform HUD_rectTRansform { get; private set; }

                private UICamera m_uiCamera;

                public MainCanvas() {
                    m_uiCamera = new UICamera();
                    GameObject Go = new GameObject("MainCanvas");
                    Go.layer = LayerConfig.UI;
                    canvas = Go.AddComponent<Canvas>();
                    canvas.renderMode = RenderMode.ScreenSpaceCamera;
                    canvas.worldCamera = camera;
                    canvas.planeDistance = 10;
                    CanvasScaler scaler = Go.AddComponent<CanvasScaler>();
                    scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                    scaler.referenceResolution = new Vector2(GameConfig.STANDARD_WIDTH, GameConfig.STANDARD_HEIGHT);
                    scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                    scaler.referencePixelsPerUnit = GameConfig.PIXEL_PER_UNIT;
                    sizeDelta = new Vector2(Convert.ToSingle(Screen.width) / Screen.height * GameConfig.STANDARD_HEIGHT, GameConfig.STANDARD_HEIGHT);
                    GraphicRaycaster raycaster = Go.AddComponent<GraphicRaycaster>();
                    raycaster.ignoreReversedGraphics = true;
                    raycaster.blockingObjects = GraphicRaycaster.BlockingObjects.None;
                    scaler.matchWidthOrHeight = 1; // Height 权重
                    rectTransform = canvas.transform as RectTransform;
                    GameObject esGo = new GameObject("EventSystem");
                    esGo.AddComponent<EventSystem>();
                    esGo.AddComponent<StandaloneInputModule>();

                    HUD_Canvas = new GameObject("HUDCanvas").AddComponent<Canvas>();
                    HUD_rectTRansform = HUD_Canvas.transform as RectTransform;
                    HUD_Canvas.transform.SetParent(canvas.transform);
                    HUD_rectTRansform.localPosition = Vector3.zero;
                    HUD_rectTRansform.localRotation = Quaternion.identity;
                    HUD_rectTRansform.localScale = Vector3.one;
                    HUD_rectTRansform.sizeDelta = sizeDelta;
                    HUD_Canvas.overridePixelPerfect = false;
                    HUD_Canvas.overrideSorting = true;
                    HUD_Canvas.sortingLayerName = SortingLayerConfig.HUD;
                } // end MainCanvas

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
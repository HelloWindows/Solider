/*******************************************************************
 * FileName: MainCanvas.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Framework {
    namespace Custom {
        public class MainCanvas : ICanvas {
            public Canvas canvas { get; private set; }
            public RectTransform rectTransform { get; private set; }

            public MainCanvas(Camera camera) {
                GameObject Go = new GameObject("MainCanvas");
                canvas = Go.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = camera;
                canvas.planeDistance = 5;
                CanvasScaler scaler = Go.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(ConstConfig.STANDARD_WIDTH, ConstConfig.STANDARD_HEIGHT);
                scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                GraphicRaycaster raycaster = Go.AddComponent<GraphicRaycaster>();
                raycaster.ignoreReversedGraphics = true;
                raycaster.blockingObjects = GraphicRaycaster.BlockingObjects.None;
                Adjusting(scaler);
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
                float adjustor = 0f;         //屏幕矫正比例
                float device_width = Screen.width;      //当前设备宽度
                float device_height = Screen.height;   //当前设备高度
                //计算宽高比例
                float standard_aspect = ConstConfig.STANDARD_WIDTH / ConstConfig.STANDARD_HEIGHT;
                float device_aspect = device_width / device_height;

                if (device_aspect < standard_aspect) {    //计算矫正比例
                    adjustor = standard_aspect / device_aspect;
                } // end if

                if (adjustor == 0) {
                    scaler.matchWidthOrHeight = 1; // Height 权重
                } else {
                    scaler.matchWidthOrHeight = 0; // Width 权重
                } // end if
            } // end Adjusting
        } // end class MainCanvas 
    } // end namespace Custom 
} // end namespace Custom
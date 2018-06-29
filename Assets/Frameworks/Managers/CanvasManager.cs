/*******************************************************************
 * FileName: CanvasManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine;
using UnityEngine.UI;
using Framework.Config;

namespace Framework {
    namespace Manager {
        public class CanvasManager {
            private static RectTransform mainCanvasTrans;
            public static RectTransform MainCanvasTrans {
                get {
                    if (null == mainCanvasTrans) {
                        try {
                            mainCanvasTrans = GameObject.Find("Canvas").transform as RectTransform;
                        } catch {
                            Debug.LogError("MainCanvasTrans don't find!");
                        } // end try
                    } // end if
                    return mainCanvasTrans;
                } // end get
            } // end MainCanvasTrans

            public static void ConfigureText(Text text, string fontName, TextAnchor textAnchor, VerticalWrapMode verticalWrapMode, HorizontalWrapMode horizontalWrapMode) {
                text.raycastTarget = false;
                text.alignment = textAnchor;
                text.verticalOverflow = verticalWrapMode;
                text.horizontalOverflow = horizontalWrapMode;
                text.material = new Material(Shader.Find("Sprites/Default"));
                try {
                    text.font = FontConfig.FontDict[fontName];
                } catch (Exception ex) {
                    Debug.LogError("ConfigureText error fontName is: " + fontName + " Reason: " + ex.Message);
                } // end try
            } // end ConfigureText

            public static void ConfigureBasicText(Text text, string fontName, TextAnchor textAnchor, int fontSize, Color color) {
                text.raycastTarget = false;
                text.alignment = textAnchor;
                text.fontSize = fontSize;
                text.color = color;
                try {
                    text.font = FontConfig.FontDict[fontName];
                } catch (Exception ex) {
                    Debug.LogError("ConfigureBasicText error fontName is: " + fontName + " Reason: " + ex.Message);
                } // end try
            } // end ConfigureBasicText
        } // end class CanvasManager
    } // end namespace Manager 
} // end namespace Framework
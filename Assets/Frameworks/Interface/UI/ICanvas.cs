﻿/*******************************************************************
 * FileName: ICanvas.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Framework {
    namespace Interface {
        namespace UI {
            public interface ICanvas {
                Canvas canvas { get; }
                RectTransform rectTransform { get; }
                #region /******** 有些游戏需要把屏幕打开什么的 ********/
                ///// <summary>
                ///// 开幕式
                ///// </summary>
                //void OpeningCeremony();
                ///// <summary>
                ///// 闭幕式，...
                ///// </summary>
                //void ClosingCeremony();
                #endregion
            } // end interface ICanvas 
        } // end namespace UI
    } // end namespace Interface
} // end namespace Framework
/*******************************************************************
 * FileName: IInputCenter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine;

namespace Framework {
    namespace Interface {
        namespace Input {
            public enum ClickEvent : int {
                NULL = 0,
                /// <summary>
                /// 点击攻击按钮
                /// </summary>
                ClickAttack = 1
            } // end enum ClickEvent

            public interface IInputCenter {
                Vector2 joystickDir { get; }
                /// <summary>
                /// 监听广播
                /// </summary>
                /// <param name="action"></param>
                void AddListener(Action<ClickEvent> action);
                /// <summary>
                /// 移除监听
                /// </summary>
                /// <param name="action"></param>
                void RemoveListener(Action<ClickEvent> action);
                /// <summary>
                /// 广播
                /// </summary>
                /// <param name="content"></param>
                void Broadcast(ClickEvent content);
            } // end class IInputCenter
        } // end namespace Input
    } // end namespace Interface
} // end namespace Custom 

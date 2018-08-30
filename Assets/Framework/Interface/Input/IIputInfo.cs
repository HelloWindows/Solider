/*******************************************************************
 * FileName: IIputInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Framework {
    namespace Interface {
        namespace Input {
            public enum ButtonCode : int {
                ATTACK = 0,
                SKILL_1 = 1,
                SKILL_2 = 2,
                SKILL_3 = 3,
            } // end enum ButtonCode

            public interface IIputInfo {
                Vector2 joystickDir { get; }
                bool OnButtonDown(ButtonCode btn);
                bool OnButtonClick(ButtonCode btn);
            } // end class IIputInfo
        } // end namespace Input
    } // end namespace Interface
} // end namespace Custom 

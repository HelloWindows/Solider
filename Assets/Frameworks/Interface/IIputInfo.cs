/*******************************************************************
 * FileName: IIputInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Interface {
        public enum ButtonCode : int {
            SKILL_1 = 1,
            SKILL_2 = 2,
            SKILL_3 = 3,
        } // end enum ButtonCode

        public interface IIputInfo {
            Vector2 joystickDir { get; }
            void Update(float deltaTime);
            bool OnButtonDown(ButtonCode btn);
            bool OnButtonClick(ButtonCode btn);
        } // end class IIputInfo
    } // end namespace Interface
} // end namespace Custom 

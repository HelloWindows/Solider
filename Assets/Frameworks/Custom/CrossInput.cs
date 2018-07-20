/*******************************************************************
 * FileName: CrossInput.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Custom {
        public class CrossInput : IIputInfo {
            public Vector2 joystickDir { get; set; }
            private Dictionary<ButtonCode, KeyCode> keymap;

            public CrossInput() {
                keymap = new Dictionary<ButtonCode, KeyCode>();
                keymap[ButtonCode.SKILL_1] = KeyCode.J;
                keymap[ButtonCode.SKILL_2] = KeyCode.K;
                keymap[ButtonCode.SKILL_3] = KeyCode.L;
            } // end CrossInput

            public void Update(float deltaTime) {
#if UNITY_EDITOR
                float x = 0;
                float y = 0;
                if (Input.GetKey(KeyCode.A)) {
                    x = -1;
                } else if(Input.GetKey(KeyCode.D)) {
                    x = 1;
                } // end if

                if (Input.GetKey(KeyCode.S)) {
                    y = -1;
                } else if(Input.GetKey(KeyCode.W)) {
                    y = 1;
                } // end if
                joystickDir = new Vector2(x, y).normalized;
#endif
            } // end Update

            public bool OnButtonDown(ButtonCode btn) {
#if UNITY_EDITOR
                return Input.GetKey(keymap[btn]);
# else
                return false;
#endif

            } // end OnButtonDown

            public bool OnButtonClick(ButtonCode btn) {
#if UNITY_EDITOR
                return Input.GetKeyUp(keymap[btn]);
#else
                return false;
#endif
            } // end OnButtonClick
        } // end class CrossInput
    } // end namespace Custom 
} // end namespace Framework 

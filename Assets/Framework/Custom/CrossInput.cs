/*******************************************************************
 * FileName: CrossInput.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.UI.Custom;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Custom {
        public class CrossInput : IIputInfo {
            public Vector2 joystickDir {
                get {
#if UNITY_EDITOR
                    float x = 0;
                    float y = 0;
                    if (Input.GetKey(KeyCode.A)) {
                        x = -1;
                    } else if (Input.GetKey(KeyCode.D)) {
                        x = 1;
                    } // end if

                    if (Input.GetKey(KeyCode.S)) {
                        y = -1;
                    } else if (Input.GetKey(KeyCode.W)) {
                        y = 1;
                    } // end if
                    return new Vector2(x, y).normalized;
#else
                    return UIJoystick.dir;
#endif
                } // end get
            } // end joystickDir
            private Dictionary<ButtonCode, KeyCode> keymap;

            public CrossInput() {
                keymap = new Dictionary<ButtonCode, KeyCode>();
                keymap[ButtonCode.ATTACK] = KeyCode.J;
                keymap[ButtonCode.SKILL_1] = KeyCode.K;
                keymap[ButtonCode.SKILL_2] = KeyCode.L;
                keymap[ButtonCode.SKILL_3] = KeyCode.P;
            } // end CrossInput

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

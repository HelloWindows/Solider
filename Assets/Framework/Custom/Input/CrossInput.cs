/*******************************************************************
 * FileName: CrossInput.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Framework.Manager;
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
                    Vector2 dir = new Vector2(x, y).normalized;
                    return dir == Vector2.zero ? UIJoystick.dir : dir;
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

            public bool GetButton(ButtonCode btn) {
#if UNITY_EDITOR
                return Input.GetKey(keymap[btn]) || InstanceMgr.GetButtonInput().GetButton(btn);
#else
                return InstanceMgr.GetButtonInput().GetButton(btn);
#endif

            } // end GetButton

            public bool GetButtonUp(ButtonCode btn) {
#if UNITY_EDITOR            
                return Input.GetKeyUp(keymap[btn]) || InstanceMgr.GetButtonInput().GetButtonUp(btn);
#else
                return InstanceMgr.GetButtonInput().GetButtonUp(btn);
#endif
            } // end GetButtonUp

            public bool GetButtonDown(ButtonCode btn) {
#if UNITY_EDITOR 
                return Input.GetKeyDown(keymap[btn]) || InstanceMgr.GetButtonInput().GetButtonDown(btn);
#else
                return InstanceMgr.GetButtonInput().GetButtonDown(btn);
#endif
            } // end GetButtonDown
        } // end class CrossInput
    } // end namespace Custom 
} // end namespace Framework 

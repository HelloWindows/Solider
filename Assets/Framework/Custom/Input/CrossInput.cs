/*******************************************************************
 * FileName: CrossInput.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using Framework.Interface.Input;
using Solider.UI.Custom;
using UnityEngine;

namespace Framework {
    namespace Custom {
        namespace Input {
            public class CrossInput : IInputCenter, IDisposable {
                public Vector2 joystickDir {
                    get {
#if UNITY_EDITOR
                        float x = 0;
                        float y = 0;
                        if (UnityEngine.Input.GetKey(KeyCode.A)) {
                            x = -1;
                        } else if (UnityEngine.Input.GetKey(KeyCode.D)) {
                            x = 1;
                        } // end if

                        if (UnityEngine.Input.GetKey(KeyCode.S)) {
                            y = -1;
                        } else if (UnityEngine.Input.GetKey(KeyCode.W)) {
                            y = 1;
                        } // end if
                        Vector2 dir = new Vector2(x, y).normalized;
                        return dir == Vector2.zero ? UIJoystick.dir : dir;
#else
                    return UIJoystick.dir;
#endif
                    } // end get
                } // end joystickDir
                private Action<ClickEvent> m_action;

                public CrossInput() {
                } // end CrossInput

                public void AddListener(Action<ClickEvent> action) {
                    m_action += action;
                } // end AddListener

                public void RemoveListener(Action<ClickEvent> action) {
                    if (null == m_action) return;
                    // end if
                } // end RemoveListener

                public void Broadcast(ClickEvent content) {
                } // end Broadcast

                public void Dispose() {
                    m_action = null;
                } // end 
            } // end class CrossInput
        } // end namespace Input   
    } // end namespace Custom 
} // end namespace Framework 

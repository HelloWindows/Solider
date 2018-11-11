/*******************************************************************
 * FileName: ButtonInput.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using System.Collections.Generic;

namespace Framework {
    namespace Middleware {
        public class ButtonInput {
            private static ButtonInput singleton;
            public static ButtonInput instance {
                get {
                    if (null == singleton) singleton = new ButtonInput();
                    // end if
                    return singleton;
                } // end get
            } // end instance
            private bool upSign;
            private bool downSign;
            private Dictionary<ButtonCode, bool> signDict;

            private ButtonInput() {
                signDict = new Dictionary<ButtonCode, bool>();
                Reset();
            } // end ButtonInput

            public bool GetButtonDown() {
                if (false == downSign) return false;
                // end if
                downSign = true;
                return true;
            } // end GetButtonDown

            public bool GetButtonUp(ButtonCode btn) {
                if (false == upSign) return false;
                // end if
                upSign = true;
                return true;
            } // end GetButtonUp

            public bool GetButton(ButtonCode btn) {
                return signDict[btn];
            } // end GetButton

            /// <summary>
            /// 设置按钮状态
            /// </summary>
            /// <param name="btn"> 按钮 </param>
            /// <param name="sign"> 状态，按下 true, 松开 false </param>
            public void SetButtonSign(ButtonCode btn, bool sign) {
                upSign = !sign;
                downSign = sign;
                signDict[btn] = sign;
            } // end SetButtonSign

            public void Reset() {
                upSign = false;
                downSign = false;
                ButtonCode[] btnArr = { ButtonCode.ATTACK, ButtonCode.SKILL_1, ButtonCode.SKILL_2, ButtonCode.SKILL_3 };
                for (int i = 0; i < btnArr.Length; i++) {
                    ButtonCode btn = btnArr[i];
                    signDict[btn] = false;
                } // end for
            } // end Reset
        } // end class ButtonInput
    } // end namespace Middleware
} // end namespace Custom 

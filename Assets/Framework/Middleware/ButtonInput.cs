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
            private Dictionary<ButtonCode, bool> upDict;
            private Dictionary<ButtonCode, bool> downDict;
            private Dictionary<ButtonCode, bool> signDict;

            private ButtonInput() {
                upDict = new Dictionary<ButtonCode, bool>();
                downDict = new Dictionary<ButtonCode, bool>();
                signDict = new Dictionary<ButtonCode, bool>();
                Reset();
            } // end ButtonInput

            public bool GetButtonDown(ButtonCode btn) {
                if (false == downDict[btn]) return false;
                // end if
                downDict[btn] = false;
                return true;
            } // end GetButtonDown

            public bool GetButtonUp(ButtonCode btn) {
                if (false == upDict[btn]) return false;
                // end if
                upDict[btn] = false;
                return true;
            } // end GetButtonUp

            public bool GetButton(ButtonCode btn) {
                return signDict[btn];
            } // end GetButton

            public void PressButton(ButtonCode btn) {
                upDict[btn] = false;
                downDict[btn] = true;
                signDict[btn] = true;
            } // end PressButton

            public void ReleaseButton(ButtonCode btn) {
                upDict[btn] = true;
                downDict[btn] = false;
                signDict[btn] = false;
            } // end ReleaseButton

            public void Reset() {
                ButtonCode[] btnArr = { ButtonCode.ATTACK, ButtonCode.SKILL_1, ButtonCode.SKILL_2, ButtonCode.SKILL_3 };
                for (int i = 0; i < btnArr.Length; i++) {
                    ButtonCode btn = btnArr[i];
                    upDict[btn] = false;
                    downDict[btn] = false;
                    signDict[btn] = false;
                } // end for
            } // end Reset
        } // end class ButtonInput
    } // end namespace Middleware
} // end namespace Custom 

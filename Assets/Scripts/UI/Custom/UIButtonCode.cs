/*******************************************************************
 * FileName: UIButton.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.EventSystems;
using Framework.Interface.Input;
using Framework.Manager;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIButtonCode : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
                private ButtonCode btn;

                public void SetButtonCode(ButtonCode btn) {
                    this.btn = btn;
                } // end SetButtonCode

                public void OnPointerDown(PointerEventData eventData) {
                    InstanceMgr.GetButtonInput().PressButton(btn);
                } // end OnPointerDown

                public void OnPointerUp(PointerEventData eventData) {
                    InstanceMgr.GetButtonInput().ReleaseButton(btn);
                } // end OnPointerUp
            } // end class UIButtonCode 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider
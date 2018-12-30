/*******************************************************************
 * FileName: UIButton.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIButton : UIBehaviour, IPointerClickHandler {
                private UnityAction action;

                public void OnPointerClick(PointerEventData eventData) {
                    if (null == action) return;
                    // end if
                    action();
                } // end OnPointerClick

                public void AddListener(UnityAction call) {
                    action += call;
                } // end AddListener

                public void RemoveListener(UnityAction call) {
                    action -= call;
                } // end RemoveListener

                public void ClearAllListener() {
                    action = null;
                } // end ClearAllListener
            } // end class UIButton 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider
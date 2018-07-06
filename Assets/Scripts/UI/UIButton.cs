/*******************************************************************
 * FileName: UIButton.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solider {
	public class UIButton : MonoBehaviour, IPointerClickHandler {

        private Action action;

        public void OnPointerClick(PointerEventData eventData) {

            if (null == action) return;
            // end if
            action();
        } // end OnPointerClick

        public void AddAction(Action call) {
            action += call;
        } // end AddAction

        public void RemoveAction(Action call) {
            action -= call;
        } // end RemoveAction

        public void ClearAllAction() {
            action = null;
        } // end RemoveAllAction
    } // end class UIButton 
} // end namespace Solider
/*******************************************************************
 * FileName: Joystick.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Solider {
	public class UIJoystick : EventTrigger {

        private float radius;

        private Vector2 downPos;

        private Transform pointTrans;
        private Transform joystickTrans;

        private void Start() {
            radius = 50f;
            joystickTrans = transform.Find("Joystick");
            pointTrans = joystickTrans.Find("Point");
        } // end Start

        public override void OnDrag(PointerEventData data) {
            Vector3 dir = data.position - downPos;
            float dis = Vector3.Distance(data.position, downPos);
            pointTrans.localPosition = dir.normalized * Mathf.Clamp(dis, 0, radius);
        } // end OnDrag

        public override void OnPointerDown(PointerEventData data) {
            downPos = data.position;
        } // end OnPointerDown

        public override void OnPointerUp(PointerEventData data) {
            pointTrans.localPosition = Vector3.zero;
        } // end OnPointerUp
    } // end class UIJoystick 
} // end namespace Solider
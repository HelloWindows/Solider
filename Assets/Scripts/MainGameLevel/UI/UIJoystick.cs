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
	public class UIJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {

        public static Vector2 dir { get; private set; }

        private float radius;
        private Vector2 downPos;

        private Transform pointTrans;
        private Transform joystickTrans;

        private void Start() {
            radius = 50f;
            joystickTrans = transform.Find("Joystick");
            pointTrans = joystickTrans.Find("Point");
        } // end Start

        public void OnDrag(PointerEventData data) {
            dir = (data.position - downPos).normalized;
            float dis = Vector2.Distance(data.position, downPos);
            pointTrans.localPosition = dir.normalized * Mathf.Clamp(dis, 0, radius);
        } // end OnDrag

        public void OnPointerDown(PointerEventData data) {
            downPos = data.position;
        } // end OnPointerDown

        public void OnPointerUp(PointerEventData data) {
            dir = Vector3.zero;
            pointTrans.localPosition = Vector3.zero;
        } // end OnPointerUp
    } // end class UIJoystick 
} // end namespace Solider
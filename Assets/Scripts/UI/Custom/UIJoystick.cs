/*******************************************************************
 * FileName: Joystick.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.EventSystems;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIJoystick : UIBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {
                public static Vector2 dir { get; private set; }

                private float radius;
                private Vector2 downPos;

                private Transform pointTrans;
                private Transform joystickTrans;

                protected override void Start() {
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

                protected override void OnDisable() {
                    dir = Vector2.zero;
                } // end OnDisable
            } // end class UIJoystick 
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider
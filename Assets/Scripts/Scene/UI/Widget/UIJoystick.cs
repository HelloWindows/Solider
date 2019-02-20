/*******************************************************************
 * FileName: Joystick.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.EventSystems;

namespace Solider {
    namespace Scene {
        namespace UI {
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
                    joystickTrans.gameObject.SetActive(false);
                } // end Start

                public void OnDrag(PointerEventData data) {
                    dir = data.position - downPos;
                    pointTrans.localPosition = dir.normalized * Mathf.Clamp(dir.magnitude, 0, radius);
                } // end OnDrag

                public void OnPointerDown(PointerEventData data) {
                    downPos = data.position;
                    Vector2 pos;
                    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform,
                        downPos, data.pressEventCamera, out pos))
                        joystickTrans.localPosition = pos;
                    // end if 
                    joystickTrans.gameObject.SetActive(true);
                } // end OnPointerDown

                public void OnPointerUp(PointerEventData data) {
                    dir = Vector3.zero;
                    pointTrans.localPosition = Vector3.zero;
                    joystickTrans.gameObject.SetActive(false);
                } // end OnPointerUp

                protected override void OnDisable() {
                    dir = Vector2.zero;
                } // end OnDisable
            } // end class UIJoystick 
        } // end namespace UI
    } // end namespace Scene 
} // end namespace Solider
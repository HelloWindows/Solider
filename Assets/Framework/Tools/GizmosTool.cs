/*******************************************************************
 * FileName: GizmosTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace Framework {
    namespace Tools {
        public class GizmosTool : MonoBehaviour {
#if UNITY_EDITOR
            private void Start() {
                DontDestroyOnLoad(gameObject);
            } // end Start

            private static Vector3[] fourCorners = new Vector3[4];

            private void OnDrawGizmos() {
                DrawRaycastTargetUI();
            } // end OnDrawGizmos

            private void DrawRaycastTargetUI() {
                foreach (MaskableGraphic graphic in FindObjectsOfType<MaskableGraphic>()) {
                    if (false == graphic.raycastTarget) continue;
                    // end if
                    graphic.rectTransform.GetWorldCorners(fourCorners);
                    Gizmos.color = Color.red;
                    for (int i = 0; i < 4; i++) {
                        Gizmos.DrawLine(fourCorners[i], fourCorners[(i + 1) % 4]);
                    } // end for
                } // end foreach
            } // end DrawRaycastTargetUI
#endif
        } // end class GizmosTool 
    } // end namespace Tools
} // end namespace Framework
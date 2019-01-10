/*******************************************************************
 * FileName: RayTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Framework {
    namespace Tools {
        public static class RayTool {

            private static Ray pointerRay;
            private static RaycastHit pointerHit;

            public static bool PointerRaycastNPC(out string name) {
                if (Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
#if UNITY_EDITOR || UNITY_STANDALONE
                    if (false == EventSystem.current.IsPointerOverGameObject()) {
                        pointerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
#elif UNITY_ANDROID || UNITY_IPHONE
                    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) {
                        pointerRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
#endif
                        if (Physics.Raycast(pointerRay, out pointerHit, LayerConfig.Mask_NPC)) {
                            name = pointerHit.collider.name;
                            return true;
                        } // end if
                    } // end if
                } // end if
                name = string.Empty;
                return false;
            } // end PointerRaycast

        } // end class RayTool
    } // end namespace Tools
} // end namespace Framework

/*******************************************************************
 * FileName: MainPanelUI.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.UI.Custom;
using UnityEngine;

namespace Solider {
    namespace UI {
        namespace Common {
            public class UIMainPanel : MonoBehaviour {

                // Use this for initialization
                void Start() {
                    transform.Find("JoystickUI").gameObject.AddComponent<UIJoystick>();
                } // end Start
            } // end class UIMainPanel 
        } // end namespace Common
    } // end namespace UI 
} // end namespace Solider
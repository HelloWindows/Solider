/*******************************************************************
 * FileName: MainPanelUI.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
	public class UIMainPanel : MonoBehaviour {

		// Use this for initialization
		void Start () {
            transform.Find("JoystickUI").gameObject.AddComponent<UIJoystick>();
		} // end Start
    } // end class UIMainPanel 
} // end namespace Solider
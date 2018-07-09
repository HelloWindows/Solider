/*******************************************************************
 * FileName: UIInfoPanel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class UIInfoPanel : MonoBehaviour {

		// Use this for initialization
		private void Start () {
            transform.Find("InfoText").GetComponent<Text>();
            DisplayRaw display = transform.Find("DisplayRaw").gameObject.AddComponent<DisplayRaw>();
            display.ReplaceDisplayCurrentRole("Shooter");
            transform.Find("CloseBtn").gameObject.AddComponent<UIButton>().AddAction(delegate () { OnClickCloseBtn(); });
        } // end Start

        private void OnClickCloseBtn() {
            if (null == gameObject) return;
            //end if
            Destroy(gameObject);
        } // end OnClickInfoBtn
    } // end class UIInfoPanel 
} // end namespace Solider
/*******************************************************************
 * FileName: UIMessageBox.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIMessageBox : UIBehaviour {
                private Action action;
                private Text msgText;

                // Use this for initialization
                protected override void Awake() {
                    msgText = transform.Find("MsgText").GetComponent<Text>();
                    transform.Find("BackBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickBackBtn);
                } // end Start

                public void SetMessage(string msg) {
                    if (null == msgText) return;
                    // end if
                    msgText.text = msg;
                } // end SetMessage

                public void SetMessage(string msg, Action call) {
                    if (null == msgText) return;
                    // end if
                    action += call;
                    msgText.text = msg;
                } // end SetMessage

                private void OnClickBackBtn() {
                    if (null != action) action();
                    // end if
                    if (null == gameObject) return;
                    // end if
                    Destroy(gameObject);
                } // end OnClickBackBtn
            } // end class UIMessageBox
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider 

/*******************************************************************
 * FileName: UIDialogBox.cs
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
            public class UIDialogBox : UIBehaviour {
                private Text msgText;
                private Action action;

                // Use this for initialization
                protected override void Awake() {
                    msgText = transform.Find("MsgText").GetComponent<Text>();
                    transform.Find("CancelBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickCancelBtn);
                    transform.Find("ConfirmBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickConfirmBtn);
                } // end Start

                public void SetMessage(string msg) {
                    if (null == msgText) return;
                    // end if
                    msgText.text = msg;
                } // end SetMessage

                public void AddAction(Action call) {
                    action += call;
                } // end AddAction

                public void RemoveAction(Action call) {
                    action -= call;
                } // end RemoveAction

                public void ClearAllAction() {
                    action = null;
                } // end RemoveAllAction

                private void OnClickConfirmBtn() {
                    if (null != action) action();
                    // end if
                    OnClickCancelBtn();
                } // end OnClickConfirmBtn

                private void OnClickCancelBtn() {
                    if (null != action) action = null;
                    // end if
                    if (null == gameObject) return;
                    // end if
                    Destroy(gameObject);
                } // end OnClickBackBtn
            } // end class UIDialogBox
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider 

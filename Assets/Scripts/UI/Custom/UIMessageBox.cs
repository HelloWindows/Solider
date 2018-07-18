/*******************************************************************
 * FileName: UIMessageBox.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIMessageBox : MonoBehaviour {
                private Text msgText;

                // Use this for initialization
                void Awake() {
                    msgText = transform.Find("MsgText").GetComponent<Text>();
                    transform.Find("BackBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickBackBtn);
                } // end Start

                public void SetMessage(string msg) {
                    if (null == msgText) return;
                    // end if
                    msgText.text = msg;
                } // end SetMessage

                private void OnClickBackBtn() {
                    if (null == gameObject) return;
                    // end if
                    Destroy(gameObject);
                } // end OnClickBackBtn
            } // end class UIMessageBox
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider 

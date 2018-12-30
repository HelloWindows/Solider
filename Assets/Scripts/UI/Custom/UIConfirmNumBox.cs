/*******************************************************************
 * FileName: UIConfirmNumBox.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Solider {
    namespace UI {
        namespace Custom {
            public class UIConfirmNumBox : UIBehaviour {
                private int value;
                private int maxValue;
                private Text msgText;
                private UnityAction<int> action;
                private InputField input;

                // Use this for initialization
                protected override void Awake() {
                    msgText = transform.Find("MsgText").GetComponent<Text>();
                    transform.Find("MaxValueBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickMaxValueBtn);
                    transform.Find("CancelBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickCancelBtn);
                    transform.Find("ConfirmBtn").gameObject.AddComponent<UIButtonNormal>().AddListener(OnClickConfirmBtn);
                    input = transform.Find("InputField").GetComponent<InputField>();
                    input.onValueChanged.AddListener(OnValueChanged);
                } // end Start

                public void InitInfo(string msg) {
                    input.gameObject.SetActive(false);
                    transform.Find("MaxValueBtn").gameObject.SetActive(false);
                    msgText.text = msg;
                    value = 1;
                } // end InitInfo

                public void InitInfo(string msg, int maxValue) {
                    this.maxValue = maxValue;
                    if (null == msgText) return;
                    // end if
                    msgText.text = msg;
                } // end InitInfo

                public void AddAction(UnityAction<int> call) {
                    action += call;
                } // end AddAction

                public void RemoveAction(UnityAction<int> call) {
                    action -= call;
                } // end RemoveAction

                public void ClearAllAction() {
                    action = null;
                } // end RemoveAllAction

                private void OnValueChanged(string str) {
                    value = 0;
                    int.TryParse(str, out value);
                    if (value > maxValue) value = maxValue;
                    // end if
                    input.text = value.ToString();
                } // end OnValueChanged

                private void OnClickMaxValueBtn() {
                    value = maxValue;
                    input.text = value.ToString();
                } // end OnClickMaxValueBtn

                private void OnClickConfirmBtn() {
                    if (null != action) action(value);
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
            } // end class UIConfirmNumBox
        } // end namespace Custom
    } // end namespace UI 
} // end namespace Solider 

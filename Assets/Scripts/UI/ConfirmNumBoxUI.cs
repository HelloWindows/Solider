/*******************************************************************
 * FileName: ConfirmNumBoxUI.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Solider {
	public class ConfirmNumBoxUI : MonoBehaviour {
        private int value;
        private int maxValue;
        private Text msgText;
        private Action<int> action;
        private InputField input;

        // Use this for initialization
        void Awake() {
            msgText = transform.Find("MsgText").GetComponent<Text>();
            transform.Find("MaxValueBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickMaxValueBtn);
            transform.Find("CancelBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickCancelBtn);
            transform.Find("ConfirmBtn").gameObject.AddComponent<UIButton>().AddAction(OnClickConfirmBtn);
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

        public void AddAction(Action<int> call) {
            action += call;
        } // end AddAction

        public void RemoveAction(Action<int> call) {
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
            if (null != action)  action(value);
            // end if
            OnClickCancelBtn();
        } // end OnClickConfirmBtn

        private void OnClickCancelBtn() {
            if (null == gameObject) return;
            // end if
            Destroy(gameObject);
        } // end OnClickBackBtn
	} // end class ConfirmNumBoxUI
} // end namespace Solider 

/*******************************************************************
 * FileName: Test.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Solider.Config;
using Solider.Model;
using Framework.Manager;
using Framework.Custom.UI;

namespace Test {
    public class Test : MonoBehaviour {

        public LinkImageText text;

        private void Start() {
            text.onHrefClick.AddListener(OnClick);
        } // end Start

        private void Update() {

        } // end Update

        public void OnClick(string name) {
            Debug.Log(name);
        } // end OnClick

        public void OnDestroy()
        {
            text.onHrefClick.RemoveListener(OnClick);
        }
    } // end class Test 
} // end namespace Test
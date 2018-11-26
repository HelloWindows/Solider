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
using Solider.UI.Custom;
using UnityEngine.UI;
using Solider.Scene.UI;
using Framework.FSM.Interface;

namespace Test {

    public class TypeTest {
        public string name { get; private set; }

        public TypeTest(string name) {
            this.name = name;
        } // end TypeTest

        public TypeTest(TypeTest type) {
            name = type.name;
        } // end TypeTest

        public void Log() {
            Debug.Log(name);
        } // end Log
    } // end TypeTest

    public class Test : MonoBehaviour {

        public RectTransform parent;

        private void Start() {
            Type type = typeof(UITownPanel);
            object[] constructParms = new object[] { parent };
            IFSMState tmp = (IFSMState)Activator.CreateInstance(type, constructParms);
            tmp.DoBeforeEntering();
        } // end Start

        private void Update() {

        } // end Update

        public void OnClick(string name) {
            Debug.Log(name);
        } // end OnClick

        public void OnDestroy()
        {

        }
    } // end class Test 
} // end namespace Test
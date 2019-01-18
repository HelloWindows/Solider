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
using Framework.Interface.Input;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.Character.Skill;
using Framework.Tools;

namespace Test {

    public class Test : MonoBehaviour {

        private enum TestT : int {
            Null = 0,
            NN = 1
        }

        private void Start() {
            Dictionary<TestT, string> dict = new Dictionary<TestT, string>();
            dict[TestT.Null] = "null";
            dict[TestT.NN] = "nn";
            Debug.Log((TestT)10);
            Debug.Log(dict.ContainsKey(0));
            Debug.Log(dict.ContainsKey((TestT)10));
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
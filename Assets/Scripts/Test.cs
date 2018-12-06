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

    public class SS : MonoBehaviour {
        public TT tt { get { return _tt; } }

        private TT _tt;

        private void Awake() {
            _tt = new TT();
        }

        private void OnDestroy()
        {
            _tt = null;
        }
    } // end class SS 

    public class TT {
        public int i { get { return 1; } }
    } // end class TT

    public class Test : MonoBehaviour {

        public SS ss;
        public TT tt;
        public SS ssss;

        private void Start() {
            ss = new GameObject().AddComponent<SS>();
            tt = ss.tt;
            ssss = ss;
            Destroy(ss.gameObject);
        } // end Start

        private void Update() {
            Debug.Log(ss);
            Debug.Log(tt);
            Debug.Log(ssss.tt);
        } // end Update

        public void OnClick(string name) {
            Debug.Log(name);
        } // end OnClick

        public void OnDestroy()
        {

        }
    } // end class Test 
} // end namespace Test
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


        private void Start() {

        } // end Start

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                if(true == EventSystem.current.IsPointerOverGameObject()) return;
                Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit mHit;
                //射线检验  
                if (Physics.Raycast(mRay, out mHit)) {
                    Debug.Log(mHit.collider.name);
                }
            }
        } // end Update

        public void OnClick(string name) {
            Debug.Log(name);
        } // end OnClick

        public void OnDestroy()
        {

        }
    } // end class Test 
} // end namespace Test
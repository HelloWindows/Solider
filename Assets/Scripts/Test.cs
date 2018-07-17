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

namespace Custom {
    public class Test : MonoBehaviour {
        private void Start() {
            string[] names = QualitySettings.names;
            for (int i = 0; i < names.Length; i++) {
                Debug.Log(names[i]);
            } // end for
            QualitySettings.SetQualityLevel(0, true);
            
        }
    } // end class Test 
} // end namespace Custom
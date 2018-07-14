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
            AttributeInfo info = new AttributeInfo();
            info.SetHP(100);
            info.SetMinATk(10);
            info.SetMaxATK(100);
            AttackInfo att = new AttackInfo(info);
            info += att;
            Debug.Log(info.HP);
        }
    } // end class Test 
} // end namespace Custom
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

namespace Test {

    public class Test : MonoBehaviour {

        public delegate ICharacterState CreateInstance(ICharacter character, ISkillInfo skillInfo);

        private static Dictionary<string, CreateInstance> dict;

        private void Start() {
            dict = new Dictionary<string, CreateInstance>();
            dict["123"] = ArcherSkill1.CreateInstance;
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
﻿/*******************************************************************
 * FileName: AwakeScene.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Middleware;
using System.Collections;
using UnityEngine;

namespace Solider {
    namespace Scene {
        public class AwakeScene : MonoBehaviour {
            private IEnumerator Start() {
                InstanceMgr.Init();
                SqliteManager.Init();
                Application.targetFrameRate = 30;
                Resources.Load<ShaderVariantCollection>("Shader/ShaderVariants").WarmUp();
                yield return null;
                LoaderScene.LoadNextLevel(new LoginScene());
            } // end Start
        } // end class AwakeScene 
    } // end namespace Scene
} // end namespace Solider
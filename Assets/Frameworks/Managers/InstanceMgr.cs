﻿/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Manager;
using Framework.Instance;

namespace Framework {
    namespace Manager {
        public class InstanceMgr {
            public static int CurrentID { get; private set; }
            private static ObjectPool _ObjectPool;
            private static ShareSDKManager _ShareSDKManager;

            private InstanceMgr() {} // end InstanceMgr

            public static void Init() {
                GameManager.Init();
                _ObjectPool = new ObjectPool();
                _ShareSDKManager = ShareSDKManager.instance;
            } // end GetInstance

            public static ObjectPool GetObjectPool() { return _ObjectPool; } // end GetObjectPool

            public static ShareSDKManager GetShareSDKManager() { return _ShareSDKManager; } // end GetShareSDKManager
        } // end class InstanceMgr
    } // end namespace Manager
} // end namespace Framework
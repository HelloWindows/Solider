/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Manager;

namespace Framework {
    namespace Manager {
        public class InstanceMgr {
            public static int CurrentID { get; private set; }
            private static ObjectManager _ObjectManager;
            private static ShareSDKManager _ShareSDKManager;

            private InstanceMgr() {} // end InstanceMgr

            public static void Init() {
                GameManager.Init();
                _ObjectManager = new ObjectManager();
                _ShareSDKManager = ShareSDKManager.instance;
            } // end GetInstance

            public static ObjectManager GetObjectManager() { return _ObjectManager; } // end GetObjectManager

            public static ShareSDKManager GetShareSDKManager() { return _ShareSDKManager; } // end GetShareSDKManager
        } // end class InstanceMgr
    } // end namespace Manager
} // end namespace Framework
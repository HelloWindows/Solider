/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Broadcast;
using Solider.Manager;

namespace Framework {
    namespace Manager {
        public class InstanceMgr {
            public static int CurrentID { get; private set; }
            private static ObjectManager _ObjectManager;
            private static ShareSDKManager _ShareSDKManager;
            private static BroadcastCenter _BroadcastCenter;

            private InstanceMgr() {} // end InstanceMgr

            public static void Init() {
                GameManager.Init();
                _ObjectManager = new ObjectManager();
                _BroadcastCenter = new BroadcastCenter();
                _ShareSDKManager = ShareSDKManager.instance;
            } // end GetInstance

            public static ObjectManager GetObjectManager() { return _ObjectManager; } // end GetObjectManager
            public static BroadcastCenter GetBroadcastCenter() { return _BroadcastCenter; } // end BroadcastCenter
            public static ShareSDKManager GetShareSDKManager() { return _ShareSDKManager; } // end GetShareSDKManager

            public static void Update(float deltaTime) {
                if (null == _ObjectManager) return;
                // end if
                _ObjectManager.Update(deltaTime);
            } // end Update
        } // end class InstanceMgr
    } // end namespace Manager
} // end namespace Framework
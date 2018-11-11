/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Middleware;
using Solider.Manager;

namespace Framework {
    namespace Manager {
        public class InstanceMgr {
            public static int CurrentID { get; private set; }
            private static ButtonInput _ButtonInput;
            private static ObjectManager _ObjectManager;
            private static ShareSDKManager _ShareSDKManager;

            private InstanceMgr() {} // end InstanceMgr

            public static void Init() {
                GameManager.Init();
                _ButtonInput = ButtonInput.instance;
                _ObjectManager = new ObjectManager();
                _ShareSDKManager = ShareSDKManager.instance;
            } // end GetInstance

            public static ButtonInput GetButtonInput() { return _ButtonInput; } // end ButtonInput
            public static ObjectManager GetObjectManager() { return _ObjectManager; } // end GetObjectManager
            public static ShareSDKManager GetShareSDKManager() { return _ShareSDKManager; } // end GetShareSDKManager

            public static void Update(float deltaTime) {
                if (null == _ObjectManager) return;
                // end if
                _ObjectManager.Update(deltaTime);
            } // end Update
        } // end class InstanceMgr
    } // end namespace Manager
} // end namespace Framework
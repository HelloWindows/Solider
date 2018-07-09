/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Instances;

namespace Framework {
    namespace Manager {
        public class InstanceMgr {
            private static ObjectPool _ObjectPool;
            private static AudioManager _AudioManager;
            private static ShareSDKManager _ShareSDKManager;

            private InstanceMgr() {} // end InstanceMgr

            public static void Init() {          
                _ObjectPool = new ObjectPool();
                _AudioManager = new AudioManager();
                _ShareSDKManager = ShareSDKManager.instance;
            } // end GetInstance

            public static AudioManager GetAudioManager() { return _AudioManager; }

            public static ObjectPool GetObjectPool() { return _ObjectPool; }

            public static ShareSDKManager GetShareSDKManager() { return _ShareSDKManager; }
        } // end class InstanceMgr
    } // end namespace Manager
} // end namespace Framework
/*******************************************************************
 * FileName: ObjectPool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Framework.Manager;

namespace Framework {
    namespace Tools {
        public class ObjectTimer {
            private float time;
            private string name;
            private GameObject Go;

            public ObjectTimer(string name, GameObject Go, float time) {
                this.name = name;
                this.Go = Go;
                this.time = time;
            } // end ObjectTimer

            public bool IsOverTime(float deltaTime) {
                time -= deltaTime;
                if (time > 0) return false;
                // end if
                InstanceMgr.GetObjectManager().Recycling(name, Go);
                Go = null;
                return true;
            } // end IsOverTime
        } // end class ObjectTimer
    } // end namespace Tools
} // end namespace Framework
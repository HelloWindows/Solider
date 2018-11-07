/*******************************************************************
 * FileName: BroadcastManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using System.Collections.Generic;

namespace Framework {
    namespace Broadcast {
        public enum BroadcastType : int {
            NULL = 0,
            /// <summary>
            /// 更换装备
            /// </summary>
            ReloadEquip = 1,
        } // end enum BroadcastType
        public static class BroadcastCenter {
            private static Dictionary<BroadcastType, Action> actionMap = new Dictionary<BroadcastType, Action>();

            public static void AddListener(BroadcastType type, Action action) {
                if (!actionMap.ContainsKey(type)) {
                    actionMap[type] = action;
                } else {
                    actionMap[type] += action;
                } // end 
            } // end AddListener  

            public static void RemoveListener(BroadcastType type, Action action) {
                if (!actionMap.ContainsKey(type)) return;
                // end if
                actionMap[type] -= action;
                if (null == actionMap[type]) actionMap.Remove(type);
                // end if
            } // end RemoveListener

            public static void Broadcast(BroadcastType type) {
                Action action;
                if (actionMap.TryGetValue(type, out action)) {
                    if (null == action) return;
                    // end if
                    action();
                } // end if
            } // end Broadcast
        } // end class BroadcastCenter 
    } // end namespace Broadcast
} // end namespace Framework
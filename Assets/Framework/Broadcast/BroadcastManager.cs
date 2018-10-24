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

        } // end enum BroadcastType
        public class BroadcastCenter {
            private Dictionary<BroadcastType, Action> actionMap;

            public BroadcastCenter() {
                actionMap = new Dictionary<BroadcastType, Action>();
            } // end BroadcastCenter

            public void AddListener(BroadcastType type, Action action) {
                if (!actionMap.ContainsKey(type)) {
                    actionMap[type] = action;
                } else {
                    actionMap[type] += action;
                } // end 
            } // end AddListener  

            public void RemoveListener(BroadcastType type, Action action) {
                if (!actionMap.ContainsKey(type)) return;
                // end if
                actionMap[type] -= action;
                if (null == actionMap[type]) actionMap.Remove(type);
                // end if
            } // end RemoveListener

            public void Broadcast(BroadcastType type) {
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
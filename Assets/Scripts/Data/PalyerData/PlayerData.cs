/*******************************************************************
 * FileName: PlayerData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Data {
        public class PlayerData {
            public PlayerInfo info { get; private set; }
            public PlayerPack pack { get; private set; }

            private static PlayerData instance;
            public static PlayerData GetInstance() {
                if (null == instance) instance = new PlayerData();
                // end if
                return instance;
            } // end GetInstance

            private PlayerData() {
                info = new PlayerInfo();
                pack = new PlayerPack();
            } // end PlayerData
        } // end class PlayerData 
    } // end namespace Data
} // end namespace Solider
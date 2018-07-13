/*******************************************************************
 * FileName: PlayerData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Solider.Data;

namespace Solider {
    namespace Manager {
        public static class PlayerManager {
            public static string name { get; private set; }
            public static string roleType { get; private set; }
            public static string playerID { get; private set; }
            public static void SetPlayerID(string id) { playerID = id; } // end SetPlayerID

            public static PlayerInfo info { get; private set; }
            public static PlayerPack pack { get; private set; }

            public static void InitPlayerManager(string playerID, string name, string roleType) {
                if (null == pack) {
                    info = new PlayerInfo();
                    pack = new PlayerPack(playerID);
                    PlayerManager.name = name;
                    PlayerManager.roleType = roleType;
                } // end if
            } // end InitPlayerManager
        } // end class PlayerData 
    } // end namespace Data
} // end namespace Solider
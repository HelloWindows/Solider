/*******************************************************************
 * FileName: PlayerData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model;

namespace Solider {
    namespace Manager {
        public static class PlayerManager {
            public static string name { get; private set; }
            public static string roleType { get; private set; }
            public static string playerID { get; private set; }

            public static PlayerInfo info { get; private set; }
            public static PlayerPack pack { get; private set; }

            public static void InitPlayerManager(string playerID, string name, string roleType) {
                if (null == pack) {
                    info = new PlayerInfo();
                    PlayerManager.name = name;
                    PlayerManager.roleType = roleType;
                    PlayerManager.playerID = playerID;
                    pack = PlayerPack.GetInstance(playerID);
                } // end if
            } // end InitPlayerManager
        } // end class PlayerData 
    } // end namespace Data
} // end namespace Solider
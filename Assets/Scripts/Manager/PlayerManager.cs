/*******************************************************************
 * FileName: PlayerManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model;
using Solider.Interface;

namespace Solider {
    namespace Manager {
        public static class PlayerManager {
            public static string name { get; private set; }
            public static string playerID { get; private set; }
            public static string roleType { get; private set; }
            public static string roleID { get; private set; }

            public static IPackInfo pack { get; private set; }

            public static void InitPlayerManager(string roleID, string name, string roleType) {
                if (null == pack) {
                    PlayerManager.name = name;
                    PlayerManager.roleType = roleType;
                    PlayerManager.roleID = roleID;
                    pack = PackInfo.GetInstance(roleID, name, roleType);
                } // end if
            } // end InitPlayerManager
        } // end class PlayerManager 
    } // end namespace Data
} // end namespace Solider
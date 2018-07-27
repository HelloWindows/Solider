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
            public static int roleindex { get; private set; }
            public static string rolename { get; private set; }
            public static string roleType { get; private set; }
            public static string username { get; private set; }

            public static IPackInfo pack { get; private set; }

            public static void LoginGame(string username) {
                PlayerManager.username = username;
            } // end LoginGame

            public static void SelectedRole(int roleindex, string rolename, string roleType) {
                PlayerManager.rolename = rolename;
                PlayerManager.roleType = roleType;
                PlayerManager.roleindex = roleindex;
                pack = PackInfo.GetInstance(username, roleindex, rolename, roleType);
            } // end InitPlayerManager
        } // end class PlayerManager 
    } // end namespace Data
} // end namespace Solider
/*******************************************************************
 * FileName: RoleManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model;

namespace Solider {
    namespace Manager {
        public static class RoleManager {
            public static string name { get; private set; }
            public static string roleType { get; private set; }
            public static string roleID { get; private set; }

            public static RoleInfo info { get; private set; }
            public static RolePack pack { get; private set; }

            public static void InitRoleManager(string roleID, string name, string roleType) {
                if (null == info) {
                    RoleManager.name = name;
                    RoleManager.roleType = roleType;
                    RoleManager.roleID = roleID;
                    info = RoleInfo.GetInstance(roleID, name, roleType);
                    pack = RolePack.GetInstance(roleID);
                } // end if
            } // end InitPlayerManager
        } // end class RoleManager 
    } // end namespace Data
} // end namespace Solider
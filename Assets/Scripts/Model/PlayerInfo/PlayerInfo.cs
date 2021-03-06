﻿/*******************************************************************
 * FileName: PlayerInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model.Interface;

namespace Solider {
    namespace Model {
        public class PlayerInfo : IPlayerInfo {
            public int roleindex { get; private set; }
            public string rolename { get; private set; }
            public string roletype { get; private set; }
            public string username { get; private set; }

            public PlayerInfo() {
                roleindex = -1;
                rolename = "";
                roletype = "";
                username = "";
            } // end PlayerInfo

            public void LoginGame(string username) {
                this.username = username;
            } // end LoginGame

            public void SelectedRole(int roleindex, string rolename, string roleType) {
                this.rolename = rolename;
                this.roletype = roleType;
                this.roleindex = roleindex;
            } // end SelectedRole
        } // end class PlayerInfo 
    } // end namespace Model
} // end namespace Solider
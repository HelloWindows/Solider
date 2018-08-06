/*******************************************************************
 * FileName: IPlayerInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Solider {
    namespace Interface {
        public interface IPlayerInfo {
            int roleindex { get; }
            string rolename { get; }
            string roleType { get; }
            string username { get; }
            IPackInfo pack { get; }
            void LoginGame(string username);
            void SelectedRole(int roleindex, string rolename, string roleType);
        } // end class IPlayerInfo 
    } // end namespace Interface
} // end namespace Solider
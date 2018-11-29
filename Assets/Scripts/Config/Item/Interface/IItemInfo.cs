/*******************************************************************
 * FileName: IItemInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface IItemInfo {
                string id { get;}
                string name { get; }
                string grade { get; }
                int maximum { get; }
                string spritepath { get; }
                string intro { get; }
            } // end interface IItemInfo
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider
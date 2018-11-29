/*******************************************************************
 * FileName: ItemInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;

namespace Solider {
    namespace Config {
        namespace Item {
            public abstract class ItemInfo : InfoString, IItemInfo {
                public string id { get; protected set; }
                public string name { get; protected set; }
                public string grade { get; protected set; }
                public int maximum { get; protected set; }
                public string spritepath { get; protected set; }
                public string intro { get; protected set; }
            } // end class ItemInfo
        } // end namespace Item
    } // end namespace Config
} // end namespace Solider 

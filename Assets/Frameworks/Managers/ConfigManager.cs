/*******************************************************************
 * FileName: ConfigManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config;
using Framework.Config;

namespace Framework {
    namespace Manager {
        public static class ConfigManager {
            public static readonly ItemConfig itemConfig = ItemConfig.instance;
            public static readonly string[] equipTypeList = { "weapon", "armor", "shoes" };
            public static readonly string[] packTypeList = { "equip", "consume", "stuff" };
        } // end class ConfigManager 
    } // end  namespace Manager
} // end namespace Framework
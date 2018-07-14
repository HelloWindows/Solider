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
        public class ConfigManager {
            public static readonly ItemConfig itemConfig = ItemConfig.instance;
        } // end class ConfigManager 
    } // end  namespace Manager
} // end namespace Framework
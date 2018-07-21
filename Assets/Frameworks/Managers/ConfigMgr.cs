/*******************************************************************
 * FileName: ConfigManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config;
using Framework.Config.Audio;

namespace Framework {
    namespace Manager {
        public static class ConfigMgr {
            public static readonly ItemConfig itemConfig = ItemConfig.instance;
            public static readonly AudioConfig aduioConfig = AudioConfig.instance;
        } // end class ConfigMgr 
    } // end  namespace Manager
} // end namespace Framework
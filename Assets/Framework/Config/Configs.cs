/*******************************************************************
 * FileName: ConfigManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Material;
using Solider.Config.Item;
using Solider.Config.Icon;
using Framework.Config.Interface;
using Solider.Config.Interface;
using Solider.Config.Character;

namespace Framework {
    namespace Config {
        public static class Configs {
            public static readonly IIconConfig iconConfig = IconConfig.instance;
            public static readonly IItemConfig itemConfig = ItemConfig.instance;
            public static readonly ICharacterConfigMgr characterConfig = CharacterConfigMgr.instance;
        } // end class Configs 
    } // end  namespace Config
} // end namespace Framework
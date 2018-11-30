/*******************************************************************
 * FileName: ConfigManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Audio;
using Framework.Config.Effect;
using Framework.Config.Prefab;
using Framework.Config.Material;
using Solider.Config.Item;
using Solider.Config.Icon;
using Framework.Config.FSM;
using Framework.Config.Interface;
using Solider.Config.Interface;
using Solider.Config.Character;

namespace Framework {
    namespace Config {
        public static class Configs {
            public static readonly IIconConfig iconConfig = IconConfig.instance;
            public static readonly IItemConfig itemConfig = ItemConfig.instance;
            public static readonly IPathConfig soundConfig = SoundConfig.instance;
            public static readonly IPathConfig effectConfig = EffectConfig.instance;
            public static readonly IPathConfig prefabConfig = PrefabConfig.instance;
            public static readonly IPathConfig materialConfig = MaterialConfig.instance;
            public static readonly FSMStateConfig fsmStateConfig = FSMStateConfig.instance;
            public static readonly ICharacterConfigMgr characterConfig = CharacterConfigMgr.instance;
        } // end class Configs 
    } // end  namespace Config
} // end namespace Framework
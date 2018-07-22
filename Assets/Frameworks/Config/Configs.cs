/*******************************************************************
 * FileName: ConfigManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config;
using Framework.Config.Audio;
using Framework.Config.Effect;
using Framework.Config.Prefab;
using Framework.Config.Material;

namespace Framework {
    namespace Config {
        public static class Configs {
            public static readonly ItemConfig itemConfig = ItemConfig.instance;
            public static readonly SoundConfig aduioConfig = SoundConfig.instance;
            public static readonly EffectConfig effectConfig = EffectConfig.instance;
            public static readonly PrefabConfig prefabConfig = PrefabConfig.instance;
            public static readonly MaterialConfig materialConfig = MaterialConfig.instance;
        } // end class Configs 
    } // end  namespace Config
} // end namespace Framework
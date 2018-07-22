/*******************************************************************
 * FileName: EffectConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections.Generic;

namespace Framework {
    namespace Config {
        namespace Effect {
            public class EffectConfig : PathConfig {
                private static EffectConfig config;
                public static EffectConfig instance {
                    get {
                        if (null == config) config = new EffectConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance

                private EffectConfig() : base() {
                    string prefix = "Character/Hero/Effect/";
                    pathDict["runEffect"] = prefix + "runEffect";
                } // end AudioConfig
            } // end class EffectConfig
        } // end namespace Effect
    } // end namespace Config 
} // end namespace Framework
/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;

namespace Framework {
    namespace Config {
        namespace Material {
            public class MaterialConfig : PathConfig {
                private static MaterialConfig config;
                public static MaterialConfig instance {
                    get {
                        if (null == config) config = new MaterialConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance

                private MaterialConfig() : base() {
                } // end AudioConfig
            } // end class SoundConfig
        } // end namespace Audio
    } // end namespace Config 
} // end namespace HiiGo
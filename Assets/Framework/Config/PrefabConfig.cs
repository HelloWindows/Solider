/*******************************************************************
 * FileName: PrefabConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Framework {
    namespace Config {
        namespace Prefab {
            public class PrefabConfig : PathConfig {
                private static PrefabConfig config;
                public static PrefabConfig instance {
                    get {
                        if (null == config) config = new PrefabConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance

                private PrefabConfig() : base() {
                } // end PrefabConfig
            } // end class PrefabConfig
        } // end namespace Prefab 
    } // end namespace Config 
} // end namespace Framework 

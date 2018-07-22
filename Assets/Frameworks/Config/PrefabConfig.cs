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
                    string prefix = "Character/Hero/Weapon/";
                    pathDict["sword1"] = prefix + "sword1";
                    pathDict["sword2"] = prefix + "sword2";
                    pathDict["sword3"] = prefix + "sword3";
                    pathDict["sword4"] = prefix + "sword4";
                    pathDict["sword5"] = prefix + "sword5";
                    pathDict["sword6"] = prefix + "sword6";
                } // end PrefabConfig
            } // end class PrefabConfig
        } // end namespace Prefab 
    } // end namespace Config 
} // end namespace Framework 

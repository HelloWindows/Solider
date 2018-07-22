/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
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
                    string prefix = "Character/Hero/Skin/";
                    pathDict["swordmanArmor1"] = prefix + "swordmanArmor1";
                    pathDict["swordmanArmor2"] = prefix + "swordmanArmor2";
                    pathDict["swordmanArmor3"] = prefix + "swordmanArmor3";
                    pathDict["swordmanArmor4"] = prefix + "swordmanArmor4";
                    pathDict["swordmanArmor5"] = prefix + "swordmanArmor5";
                    pathDict["swordmanArmor6"] = prefix + "swordmanArmor6";
                } // end AudioConfig
            } // end class SoundConfig
        } // end namespace Audio
    } // end namespace Config 
} // end namespace HiiGo
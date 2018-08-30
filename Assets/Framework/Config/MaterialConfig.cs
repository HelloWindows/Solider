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
                    string prefix = "Character/Hero/Swordman/Skin/";
                    pathDict["swordmanArmor1"] = prefix + "swordmanArmor1";
                    pathDict["swordmanArmor2"] = prefix + "swordmanArmor2";
                    pathDict["swordmanArmor3"] = prefix + "swordmanArmor3";
                    pathDict["swordmanArmor4"] = prefix + "swordmanArmor4";
                    pathDict["swordmanArmor5"] = prefix + "swordmanArmor5";
                    pathDict["swordmanArmor6"] = prefix + "swordmanArmor6";

                    prefix = "Character/Hero/Archer/Skin/";
                    pathDict["archerArmor1"] = prefix + "archerArmor1";
                    pathDict["archerArmor2"] = prefix + "archerArmor2";
                    pathDict["archerArmor3"] = prefix + "archerArmor3";
                    pathDict["archerArmor4"] = prefix + "archerArmor4";
                    pathDict["archerArmor5"] = prefix + "archerArmor5";
                    pathDict["archerArmor6"] = prefix + "archerArmor6";

                    prefix = "Character/Hero/Magician/Skin/";
                    pathDict["magicianArmor1"] = prefix + "magicianArmor1";
                    pathDict["magicianArmor2"] = prefix + "magicianArmor2";
                    pathDict["magicianArmor3"] = prefix + "magicianArmor3";
                    pathDict["magicianArmor4"] = prefix + "magicianArmor4";
                    pathDict["magicianArmor5"] = prefix + "magicianArmor5";
                    pathDict["magicianArmor6"] = prefix + "magicianArmor6";
                } // end AudioConfig
            } // end class SoundConfig
        } // end namespace Audio
    } // end namespace Config 
} // end namespace HiiGo
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
                    string prefix = "Character/Hero/Swordman/Skin/";
                    pathDict[ConstConfig.SWORDMAN + "0"] = prefix + "swordmanArmor0";
                    pathDict[ConstConfig.SWORDMAN + "103001"] = prefix + "swordmanArmor1";
                    pathDict[ConstConfig.SWORDMAN + "103002"] = prefix + "swordmanArmor2";
                    pathDict[ConstConfig.SWORDMAN + "103003"] = prefix + "swordmanArmor3";
                    pathDict[ConstConfig.SWORDMAN + "103004"] = prefix + "swordmanArmor4";
                    pathDict[ConstConfig.SWORDMAN + "103005"] = prefix + "swordmanArmor5";

                    prefix = "Character/Hero/Archer/Skin/";
                    pathDict[ConstConfig.ARCHER + "0"] = prefix + "archerArmor0";
                    pathDict[ConstConfig.ARCHER + "103001"] = prefix + "archerArmor1";
                    pathDict[ConstConfig.ARCHER + "103002"] = prefix + "archerArmor2";
                    pathDict[ConstConfig.ARCHER + "103003"] = prefix + "archerArmor3";
                    pathDict[ConstConfig.ARCHER + "103004"] = prefix + "archerArmor4";
                    pathDict[ConstConfig.ARCHER + "103005"] = prefix + "archerArmor5";

                    prefix = "Character/Hero/Magician/Skin/";
                    pathDict[ConstConfig.MAGICIAN + "0"] = prefix + "magicianArmor0";
                    pathDict[ConstConfig.MAGICIAN + "103001"] = prefix + "magicianArmor1";
                    pathDict[ConstConfig.MAGICIAN + "103002"] = prefix + "magicianArmor2";
                    pathDict[ConstConfig.MAGICIAN + "103003"] = prefix + "magicianArmor3";
                    pathDict[ConstConfig.MAGICIAN + "103004"] = prefix + "magicianArmor4";
                    pathDict[ConstConfig.MAGICIAN + "103005"] = prefix + "magicianArmor5";
                } // end AudioConfig
            } // end class SoundConfig
        } // end namespace Audio
    } // end namespace Config 
} // end namespace HiiGo
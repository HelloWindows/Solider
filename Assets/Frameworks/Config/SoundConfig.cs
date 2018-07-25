/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Framework {
    namespace Config {
        namespace Audio {
            public class SoundConfig : PathConfig {
                private static SoundConfig config;
                public static SoundConfig instance {
                    get {
                        if (null == config) config = new SoundConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance


                private SoundConfig() : base() {
                    string prefix = "Character/Hero/Common/Sound/";
                    pathDict["heroRun"] = prefix + "heroRun";
                    prefix = "Character/Hero/Swordman/Sound/";
                    pathDict["swordman_attack_1"] = prefix + "swordman_attack_1";
                    pathDict["swordman_attack_2"] = prefix + "swordman_attack_2";
                    pathDict["swordman_attack_3"] = prefix + "swordman_attack_3";
                    pathDict["swordman_attack_4"] = prefix + "swordman_attack_4";
                    pathDict["swordman_skill_1"] = prefix + "swordman_skill_1";
                    pathDict["swordman_skill_2"] = prefix + "swordman_skill_2";
                    pathDict["swordman_skill_3"] = prefix + "swordman_skill_3";
                    pathDict["swordman_die"] = prefix + "swordman_die";
                    pathDict["swordman_hurt"] = prefix + "swordman_hurt";

                    prefix = "Character/Hero/Archer/Sound/";
                    pathDict["archer_attack"] = prefix + "archer_attack";
                    pathDict["archer_crit"] = prefix + "archer_crit";
                    pathDict["skill1"] = prefix + "skill1";
                    pathDict["skill2"] = prefix + "skill2";
                    pathDict["skill3"] = prefix + "skill3";
                    pathDict["archer_die"] = prefix + "archer_die";
                    pathDict["archer_hurt"] = prefix + "archer_hurt";
                } // end AudioConfig
            } // end class SoundConfig
        } // end namespace Audio
    } // end namespace Config 
} // end namespace HiiGo
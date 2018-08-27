/*******************************************************************
 * FileName: PrefabConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;

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
                    pathDict["bow1"] = prefix + "bow1";
                    pathDict["bow2"] = prefix + "bow2";
                    pathDict["bow3"] = prefix + "bow3";
                    pathDict["bow4"] = prefix + "bow4";
                    pathDict["bow5"] = prefix + "bow5";
                    pathDict["bow6"] = prefix + "bow6";
                    pathDict["staff1"] = prefix + "staff1";
                    pathDict["staff2"] = prefix + "staff2";
                    pathDict["staff3"] = prefix + "staff3";
                    pathDict["staff4"] = prefix + "staff4";
                    pathDict["staff5"] = prefix + "staff5";
                    pathDict["staff6"] = prefix + "staff6";

                    prefix = "Character/Hero/";
                    pathDict[ConstConfig.SWORDMAN] = prefix + "Swordman/" + ConstConfig.SWORDMAN;
                    pathDict[ConstConfig.ARCHER] = prefix + "Archer/" + ConstConfig.ARCHER;
                    pathDict[ConstConfig.MAGICIAN] = prefix + "Magician/" + ConstConfig.MAGICIAN;

                    prefix = "Character/NPC/";
                    pathDict["npc_grocery"] = prefix + "npc_grocery";
                } // end PrefabConfig
            } // end class PrefabConfig
        } // end namespace Prefab 
    } // end namespace Config 
} // end namespace Framework 

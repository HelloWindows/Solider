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
                    pathDict[ConstConfig.SWORDMAN + "0"] = prefix + "sword0";
                    pathDict["100001"] = prefix + "sword1";
                    pathDict["100002"] = prefix + "sword2";
                    pathDict["100003"] = prefix + "sword3";
                    pathDict["100004"] = prefix + "sword4";
                    pathDict["100005"] = prefix + "sword5";
                    pathDict[ConstConfig.ARCHER + "0"] = prefix + "bow0";
                    pathDict["100006"] = prefix + "bow1";
                    pathDict["100007"] = prefix + "bow2";
                    pathDict["100008"] = prefix + "bow3";
                    pathDict["100009"] = prefix + "bow4";
                    pathDict["100010"] = prefix + "bow5";
                    pathDict[ConstConfig.MAGICIAN + "0"] = prefix + "staff0";
                    pathDict["100011"] = prefix + "staff1";
                    pathDict["100012"] = prefix + "staff2";
                    pathDict["100013"] = prefix + "staff3";
                    pathDict["100014"] = prefix + "staff4";
                    pathDict["100015"] = prefix + "staff5";

                    prefix = "Character/Hero/Wing/";
                    pathDict["106001"] = prefix + "wing0";
                    pathDict["106002"] = prefix + "wing1";
                    pathDict["106003"] = prefix + "wing2";
                    pathDict["106004"] = prefix + "wing3";
                    pathDict["106005"] = prefix + "wing4";

                    prefix = "Character/Hero/";
                    pathDict[ConstConfig.SWORDMAN] = prefix + "Swordman/" + ConstConfig.SWORDMAN;
                    pathDict[ConstConfig.ARCHER] = prefix + "Archer/" + ConstConfig.ARCHER;
                    pathDict[ConstConfig.MAGICIAN] = prefix + "Magician/" + ConstConfig.MAGICIAN;

                    prefix = "Character/NPC/"; 
                    pathDict["npc_grocery"] = prefix + "npc_grocery";
                    pathDict["npc_forge"] = prefix + "npc_forge";
                    pathDict["npc_transmitter"] = prefix + "npc_transmitter";
                } // end PrefabConfig
            } // end class PrefabConfig
        } // end namespace Prefab 
    } // end namespace Config 
} // end namespace Framework 

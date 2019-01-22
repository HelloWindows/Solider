/*******************************************************************
 * FileName: CommonConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.NPC;
using System.Collections.Generic;

namespace Solider {
    namespace Config {
        namespace Common {
            public static class NPCStateID {
                /// <summary>
                /// 待机
                /// </summary>
                public const string Idle = "idle";
                /// <summary>
                /// 行走
                /// </summary>
                public const string Walk = "walk";
                /// <summary>
                /// 追逐
                /// </summary>
                public const string Chase = "chase";
                /// <summary>
                /// 躲避
                /// </summary>
                public const string Escape = "escape";
                /// <summary>
                /// 死亡
                /// </summary>
                public const string Die = "die";
                /// <summary>
                /// 第一种攻击
                /// </summary>
                public const string Attack_1 = "attack_1";
            } // end clase NPCStateID

            public static class ParamConfig {
                private static Dictionary<NPCType, float> m_npcReachDict;
                private static Dictionary<NPCType, float> npcReachDict {
                    get {
                        if (null == m_npcReachDict) {
                            m_npcReachDict = new Dictionary<NPCType, float>();
                            m_npcReachDict[NPCType.Null] = 1;
                            m_npcReachDict[NPCType.Peace] = 1;
                            m_npcReachDict[NPCType.Melee_Neutral] = 1f;
                            m_npcReachDict[NPCType.Range_Neutral] = 10f;
                            m_npcReachDict[NPCType.Melee_Enemy] = 1f;
                            m_npcReachDict[NPCType.Range_Enemy] = 10f;

                            m_npcReachDict[NPCType.Sfix] = 2f;
                        } // end if
                        return m_npcReachDict;
                    } // end get
                } // end npcReachDict

                public static bool TryGetNPCReach(NPCType type, out float reach) {
                    return npcReachDict.TryGetValue(type, out reach);
                } // end TryGetNPCReach
            } // end class ParamConfig 
        } // end namespace Common 
    } // end namespace Config
} // end namespace Solider
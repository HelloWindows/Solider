/*******************************************************************
 * FileName: NPCharacterProxy.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Tools;
using Solider.Character.NPC;
using Solider.Config.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Factory {
        namespace Proxy {
            public static class NPCharacterProxy {
                private enum NPCType : int {
                    Null = 0,
                    Peace = 1,
                    Neutral = 2
                } // end enum NPCType
                private delegate Character.Character NPCharacterFunc(string id, Vector3 position);
                private static Dictionary<NPCType, NPCharacterFunc> m_proxyDict;
                private static Dictionary<NPCType, NPCharacterFunc> proxyDict {
                    get {
                        if (null != m_proxyDict) return m_proxyDict;
                        // end if
                        m_proxyDict = new Dictionary<NPCType, NPCharacterFunc>();
                        m_proxyDict[NPCType.Peace] = PeaceNPC.CreateInstance;
                        m_proxyDict[NPCType.Neutral] = NeutralNPC.CreateInstance;
                        return m_proxyDict;
                    } // end if
                } // end ProxyDict

                public static Character.Character CreateNPCharacter(string id, Vector3 position) {
                    ICharacterConfig config = Configs.characterConfig.GetCharacterConfig(id);
                    if (null == config) return null;
                    // end if
                    NPCharacterFunc proxy;
                    if (false == proxyDict.TryGetValue((NPCType)config.npc_type, out proxy)) {
                        DebugTool.ThrowException("NPCharacterProxy CreateNPCharacter id is don't configure!! id:" + id + " NPCType:" + config.npc_type);
                        return null;
                    } // end if
                    if (null == proxy) {
                        DebugTool.ThrowException("NPCharacterProxy CreateNPCharacter id was configure Error!! id:" + id);
                        return null;
                    } // end if
                    return proxy(id, position);
                } // end CreateNPCharacter
            } // end class NPCharacterProxy 
        } // end namespace Proxy
    } // end namespace Factory
} // end namespace Solider
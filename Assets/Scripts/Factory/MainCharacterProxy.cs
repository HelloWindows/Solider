/*******************************************************************
 * FileName: MainCharacterProxy.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.Tools;
using Solider.Character.MainCharacter;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Factory {
        namespace Proxy {
            public static class MainCharacterProxy {
                private delegate MainCharacter MainCharacterFunc(string name, Vector3 position);
                private static Dictionary<string, MainCharacterFunc> m_proxyDict;
                private static Dictionary<string, MainCharacterFunc> proxyDict {
                    get {
                        if (null != m_proxyDict) return m_proxyDict;
                        // end if
                        m_proxyDict = new Dictionary<string, MainCharacterFunc>();
                        m_proxyDict[ConstConfig.ARCHER] = ArcherCharacter.CreateInstance;
                        m_proxyDict[ConstConfig.MAGICIAN] = MagicianCharacter.CreateInstance;
                        m_proxyDict[ConstConfig.SWORDMAN] = SwordmanCharacter.CreateInstance;
                        return m_proxyDict;
                    } // end if
                } // end ProxyDict

                public static MainCharacter CreateMainCharacter(string id, string name, Vector3 position) {
                    MainCharacterFunc proxy;
                    if (false == proxyDict.TryGetValue(id, out proxy)) {
                        DebugTool.ThrowException("MainCharacterProxy CreateMainCharacter id is don't configure!! id:" + id);
                        return null;
                    } // end if
                    if (null == proxy) {
                        DebugTool.ThrowException("MainCharacterProxy CreateMainCharacter id was configure Error!! id:" + id);
                        return null;
                    } // end if
                    return proxy(name, position);
                } // end CreateMainCharacter
            } // end class MainCharacterProxy 
        } // end namespace Proxy
    } // end namespace Factory
} // end namespace Solider
/*******************************************************************
 * FileName: CharacterStateProxy.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Character.Skill;
using Solider.Config.Interface;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        namespace FSM {
            public delegate ICharacterState SkillStateProxy(ICharacter character, ISkillInfo skillInfo);
            public static class CharacterStateProxy {
                private static Dictionary<string, SkillStateProxy> proxyDict;
                private static Dictionary<string, SkillStateProxy> ProxyDict {
                    get {
                        if (null != proxyDict) return proxyDict;
                        // end if
                        proxyDict = new Dictionary<string, SkillStateProxy>();
                        proxyDict[ArcherSkill1.ID] = ArcherSkill1.CreateInstance;
                        proxyDict[ArcherSkill2.ID] = ArcherSkill2.CreateInstance;
                        proxyDict[ArcherSkill3.ID] = ArcherSkill3.CreateInstance;
                        proxyDict[MagicianSkill1.ID] = MagicianSkill1.CreateInstance;
                        proxyDict[MagicianSkill2.ID] = MagicianSkill2.CreateInstance;
                        proxyDict[MagicianSkill3.ID] = MagicianSkill3.CreateInstance;
                        proxyDict[SwordmanSkill1.ID] = SwordmanSkill1.CreateInstance;
                        proxyDict[SwordmanSkill2.ID] = SwordmanSkill2.CreateInstance;
                        proxyDict[SwordmanSkill3.ID] = SwordmanSkill3.CreateInstance;
                        return proxyDict;
                    } // end if
                } // end ProxyDict

                public static ICharacterState CreateSkillState(string id, ICharacter character, ISkillInfo skillInfo) {
                    SkillStateProxy proxy;
                    if (ProxyDict.TryGetValue(id, out proxy)) {
                        return proxy(character, skillInfo);
                    } else {
                        DebugTool.ThrowException("CharacterStateProxy CreateSkillState id is don't exist!! id:" + id);
                        return null;
                    }// end if
                } // end CreateSkillState

                public static SkillStateProxy GetSkillStateProxy(string id) {
                    SkillStateProxy proxy;
                    if (ProxyDict.TryGetValue(id, out proxy)) {
                        return proxy;
                    } // end if
                    DebugTool.ThrowException("CharacterStateProxy GetSkillStateProxy id is don't exist!! id:" + id);
                    return null;
                } // end GetSkillStateProxy
            } // end class CharacterStateProxy 
        } // end namespace FSM
    } // end namespace Character
} // end namespace Solider
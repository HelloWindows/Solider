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
            public static class CharacterStateProxy {
                private delegate ICharacterState SkillStateFunc(ICharacter character, ISkillInfo skillInfo);
                private static Dictionary<string, SkillStateFunc> m_proxyDict;
                private static Dictionary<string, SkillStateFunc> proxyDict {
                    get {
                        if (null != m_proxyDict) return m_proxyDict;
                        // end if
                        m_proxyDict = new Dictionary<string, SkillStateFunc>();
                        m_proxyDict[ArcherSkill1.ID] = ArcherSkill1.CreateInstance;
                        m_proxyDict[ArcherSkill2.ID] = ArcherSkill2.CreateInstance;
                        m_proxyDict[ArcherSkill3.ID] = ArcherSkill3.CreateInstance;
                        m_proxyDict[MagicianSkill1.ID] = MagicianSkill1.CreateInstance;
                        m_proxyDict[MagicianSkill2.ID] = MagicianSkill2.CreateInstance;
                        m_proxyDict[MagicianSkill3.ID] = MagicianSkill3.CreateInstance;
                        m_proxyDict[SwordmanSkill1.ID] = SwordmanSkill1.CreateInstance;
                        m_proxyDict[SwordmanSkill2.ID] = SwordmanSkill2.CreateInstance;
                        m_proxyDict[SwordmanSkill3.ID] = SwordmanSkill3.CreateInstance;
                        return m_proxyDict;
                    } // end if
                } // end ProxyDict

                public static ICharacterState CreateSkillState(string id, ICharacter character, ISkillInfo info) {
                    SkillStateFunc proxy;
                    if (false == proxyDict.TryGetValue(id, out proxy)) {
                        DebugTool.ThrowException("CharacterStateProxy CreateSkillState id is don't configure!! id:" + id);
                        return null;
                    } // end if         
                    if (null == proxy) {
                        DebugTool.ThrowException("CharacterStateProxy CreateSkillState id was configure Error!! id:" + id);
                        return null;
                    } // end if
                    return proxy(character, info);
                } // end CreateSkillState
            } // end class CharacterStateProxy 
        } // end namespace FSM
    } // end namespace Character
} // end namespace Solider
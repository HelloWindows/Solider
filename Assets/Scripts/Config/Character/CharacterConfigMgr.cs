/*******************************************************************
 * FileName: CharacterConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;
using System.Collections.Generic;

namespace Solider {
    namespace Config {
        namespace Character {
            public class CharacterConfigMgr : ICharacterConfigMgr {
                private static CharacterConfigMgr config;
                private Dictionary<string, ICharacterConfig> characterConfig;

                public static CharacterConfigMgr instance {
                    get {
                        if (null == config) config = new CharacterConfigMgr();
                        // end if
                        return config;
                    } // end get
                } // end instance

                private CharacterConfigMgr() {
                    characterConfig = new Dictionary<string, ICharacterConfig>();
                } // end CharacterConfigMgr

                public bool TryGetCharacterConfig(string id, out ICharacterConfig config) {
                    if (characterConfig.TryGetValue(id, out config)) return true;
                    // end if
                    return false;
                } // end GetCharacterConfig
            } // end interface ICharacterConfigMgr
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider 

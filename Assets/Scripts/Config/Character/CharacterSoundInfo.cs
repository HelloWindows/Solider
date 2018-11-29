/*******************************************************************
 * FileName: CharacterSoundInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Config.Interface;
using System.Collections.Generic;

namespace Solider {
    namespace Config {
        namespace Character {
            public class CharacterSoundInfo : ICharacterSoundInfo {
                private Dictionary<string, string> characterSoundConfig;

                public CharacterSoundInfo(JsonData data) {
                    characterSoundConfig = new Dictionary<string, string>();
                    characterSoundConfig["attack"] = JsonTool.TryGetJsonData_String(data, "attack");
                    characterSoundConfig["hurt"] = JsonTool.TryGetJsonData_String(data, "hurt");
                    characterSoundConfig["die"] = JsonTool.TryGetJsonData_String(data, "die");
                } // end CharacterSoundInfo

                public bool TryGetSoundPath(string name, out string path) {
                    if (characterSoundConfig.TryGetValue(name, out path)) return true;
                    // end if
                    path = "";
                    return false;
                } // end GetSoundInfo
            } // end class CharacterSoundInfo 
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider
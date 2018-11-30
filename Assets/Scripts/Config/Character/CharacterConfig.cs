/*******************************************************************
 * FileName: CharacterConfig.cs
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
            public class CharacterConfig : ICharacterConfig {
                public string id { get; private set; }
                public string name { get; private set; }
                public IAttributeInfo initAttribute { get; private set; }
                private Dictionary<string, string> characterSoundConfig;

                public CharacterConfig(JsonData data) {
                    initAttribute = new AttributeInfo(data);
                    characterSoundConfig = new Dictionary<string, string>();
                    characterSoundConfig["attack"] = JsonTool.GetJsonData_String(data, "attack");
                    characterSoundConfig["hurt"] = JsonTool.GetJsonData_String(data, "hurt");
                    characterSoundConfig["die"] = JsonTool.GetJsonData_String(data, "die");
                } // end CharacterConfig

                public bool TryGetSoundPath(string name, out string path) {
                    if (characterSoundConfig.TryGetValue(name, out path)) return true;
                    // end if
                    path = "";
                    return false;
                } // end GetSoundInfo
            } // end class CharacterConfig 
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider
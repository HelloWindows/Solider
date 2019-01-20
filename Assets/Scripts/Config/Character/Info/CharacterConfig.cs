/*******************************************************************
 * FileName: CharacterConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using Framework.Tools;
using Solider.Config.Interface;
using System.Collections.Generic;

namespace Solider {
    namespace Config {
        namespace Character {
            public class CharacterConfig : ICharacterConfig {
                public string id { get; private set; }
                public string name { get; private set; }
                public int npc_type { get; private set; }
                public IAttributeInfo initAttribute { get; private set; }
                private Dictionary<string, string> characterSoundConfig;
                private Dictionary<string, string> characterEffectConfig;

                public CharacterConfig(JsonData data) {
                    id = JsonTool.GetJsonData_String(data, "id");
                    name = JsonTool.GetJsonData_String(data, "name");
                    npc_type = JsonTool.GetJsonData_Int(data, "npc_type");
                    InitAttribute(data["attribute"]);
                    InitCharacterSoundConfig(data["sound"]);
                    InitCharacterEffectConfig(data["effect"]);
                } // end CharacterConfig

                private void InitAttribute(JsonData data) {
                    initAttribute = new AttributeInfo(data);
                } // end InitAttribute

                private void InitCharacterSoundConfig(JsonData data) {
                    characterSoundConfig = new Dictionary<string, string>();
                    string[] keys = new string[] { "attack1", "attack2", "attack3", "attack4", "hurt", "die", "run" };
                    for (int i = 0; i < keys.Length; i++) {
                        string key = keys[i];
                        string value = JsonTool.GetJsonData_String(data, key);
                        if (string.IsNullOrEmpty(value)) continue;
                        // end if
                        characterSoundConfig[key] = value;
                    } // end if
                } // end InitCharacterSoundConfig

                private void InitCharacterEffectConfig(JsonData data) {
                    characterEffectConfig = new Dictionary<string, string>();
                    string[] keys = new string[] { "attack1", "attack2", "attack3", "attack4", "hurt", "die", "run" };
                    for (int i = 0; i < keys.Length; i++) {
                        string key = keys[i];
                        string value = JsonTool.GetJsonData_String(data, key);
                        if (string.IsNullOrEmpty(value)) continue;
                        // end if
                        characterEffectConfig[key] = value;
                    } // end if
                } // end InitCharacterEffectConfig

                public bool TryGetSoundPath(string name, out string path) {
                    if (characterSoundConfig.TryGetValue(name, out path)) {
                        if (false == string.IsNullOrEmpty(path)) return true;
                        // end if
                        DebugTool.LoaWarning(GetType() + "TryGetSoundPath path is null or empty! Name:" + name);
                    } // end if
                    path = "";
                    DebugTool.LoaWarning(GetType() + "TryGetSoundPath name is don't configure! Name:" + name);
                    return false;
                } // end TryGetSoundPath

                public bool TryGetEffectPath(string name, out string path) {
                    if (characterEffectConfig.TryGetValue(name, out path)) {
                        if (false == string.IsNullOrEmpty(path)) return true;
                        // end if
                        DebugTool.LoaWarning(GetType() + "TryGetEffectPath path is null or empty! Name:" + name);
                    } // end if
                    path = "";
                    DebugTool.LoaWarning(GetType() + "TryGetEffectPath name is don't configure! Name:" + name);
                    return false;
                } // end TryGetEffectPath
            } // end class CharacterConfig 
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider
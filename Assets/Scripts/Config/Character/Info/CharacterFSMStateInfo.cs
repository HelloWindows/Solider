/*******************************************************************
 * FileName: CharacterFSMStateInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Config.Interface;

namespace Solider {
    namespace Config {
        namespace Character {
            public class CharacterFSMStateInfo : ICharacterFSMStateInfo {
                public string id { get; private set; }
                public string soundPath { get; private set; }

                public CharacterFSMStateInfo(JsonData data) {
                    id = JsonTool.GetJsonData_String(data, "id");
                    soundPath = JsonTool.GetJsonData_String(data, "soundPath");
                } // end CharacterFSMStateInfo
            } // end class CharacterFSMStateInfo
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider 

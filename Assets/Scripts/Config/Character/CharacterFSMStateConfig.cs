/*******************************************************************
 * FileName: CharacterFSMStateConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Character.FSMState;
using Solider.Config.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        namespace Character {
            public class CharacterFSMStateConfig : ICharacterFSMStateConfig {
                private static CharacterFSMStateConfig config;
                public static CharacterFSMStateConfig instance {
                    get {
                        if(config == null) {
                            config = new CharacterFSMStateConfig();
                        } // end if
                        return config;
                    } // end get
                } // end instance
                private Dictionary<string, ICharacterFSMStateInfo> infoDict;

                private CharacterFSMStateConfig() {
                    infoDict = new Dictionary<string, ICharacterFSMStateInfo>();
                    AssetBundle assetbundle = PlatformTool.LoadFromStreamingAssets("config/res_config.unity3d");
                    string jsonInfo = assetbundle.LoadAsset<TextAsset>("assets/config/charcter_state_config.json").text;
                    assetbundle.Unload(false);
                    JsonData data = JsonMapper.ToObject(jsonInfo);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        string id = (string)list[i]["id"];
                        infoDict.Add(id, new CharacterFSMStateInfo(list[i]));
                    } // end for
                } // end CharacterFSMStateConfig

                public ICharacterFSMStateInfo GetCharacterFSMStateInfo(string id) {
                    if (infoDict.ContainsKey(id)) return infoDict[id];
                    DebugTool.ThrowException("CharacterFSMStateConfig CharacterFSMState was configure error!!! ID:" + id);
                    return null;
                } // end GetCharacterFSMStateInfo
            } // end class CharacterFSMStateConfig
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider 

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
using UnityEngine;

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
                #region ******** 初始化角色配置信息 ********
                private CharacterConfigMgr() {
                    characterConfig = new Dictionary<string, ICharacterConfig>();
                    AssetBundle assetbundle = PlatformTool.LoadFromStreamingAssets("config/res_config.unity3d");
                    string jsonInfo = assetbundle.LoadAsset<TextAsset>("assets/config/character_config.json").text;
                    assetbundle.Unload(false);
                    JsonData data = JsonMapper.ToObject(jsonInfo);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        characterConfig.Add((string)list[i]["id"], new CharacterConfig(list[i]));
                    } // end for
                } // end CharacterConfigMgr
                #endregion

                public ICharacterConfig GetCharacterConfig(string id) {
                    if (characterConfig.ContainsKey(id)) return characterConfig[id];
                    // end if
                    DebugTool.ThrowException("CharacterConfigMgr character was configure error!!! ID:" + id);
                    return null;
                } // end GetCharacterConfig
            } // end interface ICharacterConfigMgr
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider 

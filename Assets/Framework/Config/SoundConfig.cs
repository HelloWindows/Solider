/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Character.FSMState;
using UnityEngine;

namespace Framework {
    namespace Config {
        namespace Audio {
            public class SoundConfig : PathConfig {
                private static SoundConfig config;
                public static SoundConfig instance {
                    get {
                        if (null == config) config = new SoundConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance


                private SoundConfig() : base() {
                    AssetBundle assetbundle = PlatformTool.LoadFromStreamingAssets("config/res_config.unity3d");
                    string soundJson = assetbundle.LoadAsset<TextAsset>("assets/config/charcter_state_config.json").text;
                    assetbundle.Unload(false);
                    JsonData data = JsonMapper.ToObject(soundJson);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        string id = (string)list[i]["id"];
                        pathDict.Add(id, JsonTool.GetJsonData_String(list[i], "soundPath"));
                    } // end for
                } // end AudioConfig
            } // end class SoundConfig
        } // end namespace Audio
    } // end namespace Config 
} // end namespace Framework
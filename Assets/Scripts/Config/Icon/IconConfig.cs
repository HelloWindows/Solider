/*******************************************************************
 * FileName: IconConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        namespace Icon {
            public class IconConfig {
                private static IconConfig config;
                private Dictionary<string, SkillInfo> skillConfig;

                public static IconConfig instance {
                    get {
                        if (null == config) config = new IconConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance

                private IconConfig() {
                    skillConfig = new Dictionary<string, SkillInfo>();
                    AssetBundle assetbundle = PlatformTool.LoadFromStreamingAssets("config/res_config.unity3d");
                    string skillJson = assetbundle.LoadAsset<TextAsset>("assets/config/skill_info_config.json").text;
                    InitBuffAndSkillConfig(skillJson);
                    assetbundle.Unload(false);
                } // end IconConfig

                private void InitBuffAndSkillConfig(string jsonInfo) {
                    JsonData data = JsonMapper.ToObject(jsonInfo);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        skillConfig.Add((string)list[i]["id"], new SkillInfo(list[i]));
                    } // end for
                } // end InitStuffConfig

                public SkillInfo GetSkillInfo(string id) {
                    if (skillConfig.ContainsKey(id)) return skillConfig[id];
                    // end if
                    return null;
                } // end GetSkillInfo
            } // end class IconConfig 
        } // end namespace Icon
    } // end namespace Config
} // end namespace Solider
/*******************************************************************
 * FileName: IconConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Config.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        namespace Icon {
            public class IconConfig : IIconConfig {
                private static IconConfig config;
                private Dictionary<string, ISkillInfo> skillConfig;

                public static IconConfig instance {
                    get {
                        if (null == config) config = new IconConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance
                #region ******** 初始化配置信息 ********
                private IconConfig() {
                    skillConfig = new Dictionary<string, ISkillInfo>();
                    AssetBundle assetbundle = PlatformTool.LoadFromStreamingAssets("config/res_config.unity3d");
                    string skillJson = assetbundle.LoadAsset<TextAsset>("skill_info_config.json").text;
                    assetbundle.Unload(false);
                    InitSkillConfig(skillJson);
                } // end IconConfig

                private void InitSkillConfig(string jsonInfo) {
                    JsonData data = JsonMapper.ToObject(jsonInfo);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        skillConfig.Add((string)list[i]["id"], new SkillInfo(list[i]));
                    } // end for
                } // end InitSkillConfig
                #endregion

                public bool TryGetSkillInfo(string id, out ISkillInfo info) {
                    if (skillConfig.TryGetValue(id, out info)) return true;
                    // end if
                    info = null;
                    DebugTool.LogError("IconConfig TryGetSkillInfo ISkillInfo is null!!! ID:" + id);
                    return false;
                } // end TryGetSkillInfo
            } // end class IconConfig 
        } // end namespace Icon
    } // end namespace Config
} // end namespace Solider
/*******************************************************************
 * FileName: EquipConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Solider {
    namespace Config {
        public class EquipConfig {
            public Dictionary<string, EquipInfo> dict { get; private set; }

            public EquipConfig() {
                dict = new Dictionary<string, EquipInfo>();
                string path = "";
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IPHONE
                path = Application.streamingAssetsPath + "/config/res_config.unity3d";
#elif UNITY_ANDROID
                path = Application.dataPath + "!assets" + "/config/res_config.unity3d";	     
#endif
                AssetBundle assetbundle = AssetBundle.LoadFromFile(path);
                string jsonStr = assetbundle.LoadAsset<TextAsset>("assets/config/equipment_res_config.json").text;
                JsonData data = JsonMapper.ToObject(jsonStr);
                JsonData list = data["itemlist"];

                for (int i = 0; i < list.Count; i++) {
                    EquipInfo info = new EquipInfo();
                    info.SetID((string)list[i]["id"]);
                    info.SetName((string)list[i]["name"]);
                    info.SetRole((string)list[i]["role"]);
                    info.SetSpritepath((string)list[i]["spritepath"]);
                    info.SetIntro((string)list[i]["intro"]);
                    JsonData property = list[i]["property"];
                    info.SetAttmin((int)property["attmin"]);
                    info.SetAttmax((int)property["attmax"]);
                    info.SetDef((int)property["def"]);
                    info.SetAttspeed((float)property["attspeed"]);
                    info.SetMovspeed((float)property["movspeed"]);
                    info.SetCrit((float)property["crit"]);
                    info.SetClip((float)property["clip"]);
                    dict.Add((string)list[i]["id"], info);
                } // end for
            } // end EquipConfig

            public bool CheckIsEquipWithID(string id) {
                if (dict.ContainsKey(id)) return true;
                // end if
                return false;
            } // end CheckIsEquipWithID

            public EquipInfo GetEquipInfoWithID(string id) {
                if (CheckIsEquipWithID(id)) return dict[id];
                // end if
                return null;
            } // end GetEquipInfoWithID

            public EquipProperty GetEquipPropertyWithID(string id) {
                if (CheckIsEquipWithID(id)) return dict[id].property;
                // end if
                return null;
            } // end GetEquipPropertyWithID
        } // end class EquipConfig 
    } // end namespace Config
} // end namespace Custom
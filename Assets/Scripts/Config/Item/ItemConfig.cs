/*******************************************************************
 * FileName: ItemConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using LitJson;
using Solider.Model;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        public class ItemConfig {
            private static ItemConfig config;
            private readonly Dictionary<string, ItemInfo> stuffInfo;
            private readonly Dictionary<string, ItemInfo> equipInfo;
            private readonly Dictionary<string, ItemInfo> consumeInfo;

            public static ItemConfig instance {
                get {
                    if (null == config) config = new ItemConfig();
                    // end if
                    return config;
                } // end get
            } // end instance
            #region ******** 初始化物品配置信息 ********
            private ItemConfig() {
                stuffInfo = new Dictionary<string, ItemInfo>();
                equipInfo = new Dictionary<string, ItemInfo>();
                consumeInfo = new Dictionary<string, ItemInfo>();
                AssetBundle assetbundle = PlatformManager.LoadFromStreamingAssets("config/res_config.unity3d");
                string stuffJson = assetbundle.LoadAsset<TextAsset>("assets/config/stuff_res_config.json").text;
                string equipJson = assetbundle.LoadAsset<TextAsset>("assets/config/equipment_res_config.json").text;
                string consumeJson = assetbundle.LoadAsset<TextAsset>("assets/config/consumable_res_config.json").text;
                InitStuffConfig(stuffJson);
                InitEquipConfig(equipJson);
                InitConsumeConfig(consumeJson);
                assetbundle.Unload(false);
            } // end ItemConfig

            private void InitStuffConfig(string jsonInfo ) {
                JsonData data = JsonMapper.ToObject(jsonInfo);
                JsonData list = data["itemlist"];
                for (int i = 0; i < list.Count; i++) {
                    StuffInfo info = new StuffInfo(list[i]);
                    stuffInfo.Add((string)list[i]["id"], info);
                } // end for
            } // end InitStuffConfig

            private void InitEquipConfig(string jsonInfo) {
                JsonData data = JsonMapper.ToObject(jsonInfo);
                JsonData list = data["itemlist"];
                for (int i = 0; i < list.Count; i++) {
                    EquipInfo info = new EquipInfo(list[i]);
                    equipInfo.Add((string)list[i]["id"], info);
                } // end for
            } // end InitEquipConfig

            private void InitConsumeConfig(string jsonInfo) {
                JsonData data = JsonMapper.ToObject(jsonInfo);
                JsonData list = data["itemlist"];
                for (int i = 0; i < list.Count; i++) {
                    ConsumeInfo info = new ConsumeInfo(list[i]);
                    consumeInfo.Add((string)list[i]["id"], info);
                } // end for
            } // end InitConsumeConfig
            #endregion

            public ItemInfo GetItemInfo(string id) {
                if (stuffInfo.ContainsKey(id)) return stuffInfo[id];
                // end if
                if (equipInfo.ContainsKey(id)) return equipInfo[id];
                // end if
                if (consumeInfo.ContainsKey(id)) return consumeInfo[id];
                // end if
                return null;
            } // end GetItemInfo

            public string GetItemGrade(string id) {
                if (stuffInfo.ContainsKey(id)) return stuffInfo[id].grade;
                // end if
                if (equipInfo.ContainsKey(id)) return equipInfo[id].grade;
                // end if
                if (consumeInfo.ContainsKey(id)) return consumeInfo[id].grade;
                // end if
                return "Z";
            } // end GetItemGradeWithID

            public string GetItemType(string id) {
                if (stuffInfo.ContainsKey(id)) return "stuff";
                // end if
                if (equipInfo.ContainsKey(id)) return "equip";
                // end if
                if (consumeInfo.ContainsKey(id)) return "consume";
                // end if
                return "null";
            } // end GetItemTypeWithID
        } // end class ItemConfig
    } // end namespace Config
} // end namespace Custom 

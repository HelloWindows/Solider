/*******************************************************************
 * FileName: ItemConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.Tools;
using LitJson;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        public class ItemConfig {
            private static ItemConfig config;
            private readonly Dictionary<string, ItemInfo> stuffConfig;
            private readonly Dictionary<string, ItemInfo> equipConfig;
            private readonly Dictionary<string, ItemInfo> consumeConfig;
            private readonly Dictionary<string, ItemInfo> bluePrintConfig;

            public static ItemConfig instance {
                get {
                    if (null == config) config = new ItemConfig();
                    // end if
                    return config;
                } // end get
            } // end instance
            #region ******** 初始化物品配置信息 ********
            private ItemConfig() {
                stuffConfig = new Dictionary<string, ItemInfo>();
                equipConfig = new Dictionary<string, ItemInfo>();
                consumeConfig = new Dictionary<string, ItemInfo>();
                bluePrintConfig = new Dictionary<string, ItemInfo>();
                AssetBundle assetbundle = PlatformTool.LoadFromStreamingAssets("config/res_config.unity3d");
                string stuffJson = assetbundle.LoadAsset<TextAsset>("assets/config/stuff_res_config.json").text;
                string equipJson = assetbundle.LoadAsset<TextAsset>("assets/config/equipment_res_config.json").text;
                string consumeJson = assetbundle.LoadAsset<TextAsset>("assets/config/consumable_res_config.json").text;
                string bluePrintJson = assetbundle.LoadAsset<TextAsset>("assets/config/blueprint_res_config.json").text;
                InitStuffConfig(stuffJson);
                InitEquipConfig(equipJson);
                InitConsumeConfig(consumeJson);
                InitBluePrintConfig(bluePrintJson);
                assetbundle.Unload(false);
            } // end ItemConfig

            private void InitStuffConfig(string jsonInfo ) {
                JsonData data = JsonMapper.ToObject(jsonInfo);
                JsonData list = data["itemlist"];
                for (int i = 0; i < list.Count; i++) {
                    stuffConfig.Add((string)list[i]["id"], new StuffInfo(list[i]));
                } // end for
            } // end InitStuffConfig

            private void InitEquipConfig(string jsonInfo) {
                JsonData data = JsonMapper.ToObject(jsonInfo);
                JsonData list = data["itemlist"];
                for (int i = 0; i < list.Count; i++) {
                    equipConfig.Add((string)list[i]["id"], new EquipInfo(list[i]));
                } // end for
            } // end InitEquipConfig

            private void InitConsumeConfig(string jsonInfo) {
                JsonData data = JsonMapper.ToObject(jsonInfo);
                JsonData list = data["itemlist"];
                for (int i = 0; i < list.Count; i++) {
                    consumeConfig.Add((string)list[i]["id"], new ConsumeInfo(list[i]));
                } // end for
            } // end InitConsumeConfig

            private void InitBluePrintConfig(string jsonInfo) {
                JsonData data = JsonMapper.ToObject(jsonInfo);
                JsonData list = data["itemlist"];
                for (int i = 0; i < list.Count; i++) {
                    bluePrintConfig.Add((string)list[i]["id"], new BluePrintInfo(list[i]));
                } // end for
            } // end InitConsumeConfig
            #endregion

            public ItemInfo GetItemInfo(string id) {
                if (stuffConfig.ContainsKey(id)) return stuffConfig[id];
                // end if
                if (equipConfig.ContainsKey(id)) return equipConfig[id];
                // end if
                if (consumeConfig.ContainsKey(id)) return consumeConfig[id];
                // end if
                if (bluePrintConfig.ContainsKey(id)) return bluePrintConfig[id];
                // end if
                return null;
            } // end GetItemInfo

            public string GetItemGrade(string id) {
                if (stuffConfig.ContainsKey(id)) return stuffConfig[id].grade;
                // end if
                if (equipConfig.ContainsKey(id)) return equipConfig[id].grade;
                // end if
                if (consumeConfig.ContainsKey(id)) return consumeConfig[id].grade;
                // end if
                if (bluePrintConfig.ContainsKey(id)) return bluePrintConfig[id].grade;
                // end if
                return "Z";
            } // end GetItemGradeWithID

            public string GetItemType(string id) {
                if (stuffConfig.ContainsKey(id)) return ConstConfig.STUFF;
                // end if
                if (equipConfig.ContainsKey(id)) return ConstConfig.EQUIP;
                // end if
                if (consumeConfig.ContainsKey(id)) return ConstConfig.CONSUME;
                // end if
                if (bluePrintConfig.ContainsKey(id)) return ConstConfig.PRINT;
                // end if
                return "null";
            } // end GetItemTypeWithID
        } // end class ItemConfig
    } // end namespace Config
} // end namespace Custom 

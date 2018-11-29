/*******************************************************************
 * FileName: ItemConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.Tools;
using LitJson;
using Solider.Config.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        namespace Item {
            public class ItemConfig : IItemConfig {
                private static ItemConfig config;
                private readonly Dictionary<string, Dictionary<string, IItemInfo>> itemConfig;

                public static ItemConfig instance {
                    get {
                        if (null == config) config = new ItemConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance
                #region ******** 初始化物品配置信息 ********
                private ItemConfig() {
                    itemConfig = new Dictionary<string, Dictionary<string, IItemInfo>>();
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

                private void InitStuffConfig(string jsonInfo) {
                    Dictionary<string, IItemInfo> stuffConfig = new Dictionary<string, IItemInfo>();
                    JsonData data = JsonMapper.ToObject(jsonInfo);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        string id = (string)list[i]["id"];
                        if (ConstConfig.STUFF != GetItemType(id)) {
                            DebugTool.ThrowException("ItemConfig InitStuffConfig id is error!!! ID:" + id);
                            continue;
                        } // end if
                        stuffConfig.Add(id, new StuffInfo(list[i]));
                    } // end for
                    itemConfig[ConstConfig.STUFF] = stuffConfig;
                } // end InitStuffConfig

                private void InitEquipConfig(string jsonInfo) {
                    Dictionary<string, IItemInfo> equipConfig = new Dictionary<string, IItemInfo>();
                    JsonData data = JsonMapper.ToObject(jsonInfo);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        string id = (string)list[i]["id"];
                        if (ConstConfig.EQUIP != GetItemType(id)) {
                            DebugTool.ThrowException("ItemConfig InitEquipConfig id is error!!! ID:" + id);
                            continue;
                        } // end if
                        equipConfig.Add(id, new EquipInfo(list[i]));
                    } // end for
                    itemConfig[ConstConfig.EQUIP] = equipConfig;
                } // end InitEquipConfig

                private void InitConsumeConfig(string jsonInfo) {
                    Dictionary<string, IItemInfo> consumeConfig = new Dictionary<string, IItemInfo>();
                    JsonData data = JsonMapper.ToObject(jsonInfo);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        string id = (string)list[i]["id"];
                        if (ConstConfig.CONSUME != GetItemType(id)) {
                            DebugTool.ThrowException("ItemConfig InitConsumeConfig id is error!!! ID:" + id);
                            continue;
                        } // end if
                        consumeConfig.Add(id, new ConsumeInfo(list[i]));
                    } // end for
                    itemConfig[ConstConfig.CONSUME] = consumeConfig;
                } // end InitConsumeConfig

                private void InitBluePrintConfig(string jsonInfo) {
                    Dictionary<string, IItemInfo> bluePrintConfig = new Dictionary<string, IItemInfo>();
                    JsonData data = JsonMapper.ToObject(jsonInfo);
                    JsonData list = data["itemlist"];
                    for (int i = 0; i < list.Count; i++) {
                        string id = (string)list[i]["id"];
                        if (ConstConfig.PRINT != GetItemType(id)) {
                            DebugTool.ThrowException("ItemConfig InitBluePrintConfig id is error!!! ID:" + id);
                            continue;
                        } // end if
                        bluePrintConfig.Add(id, new BluePrintInfo(list[i]));
                    } // end for
                    itemConfig[ConstConfig.PRINT] = bluePrintConfig;
                } // end InitConsumeConfig
                #endregion

                public IItemInfo GetItemInfo(string id) {
                    string type = GetItemType(id);
                    if (type == "null") return null;
                    // end if
                    IItemInfo info;
                    if (itemConfig[type].TryGetValue(id, out info)) return info;
                    // end if
                    return null;
                } // end GetItemInfo

                public string GetItemGrade(string id) {
                    string type = GetItemType(id);
                    if (type == "null") return "Z";
                    // end if
                    IItemInfo info;
                    if (itemConfig[type].TryGetValue(id, out info)) return info.grade;
                    // end if
                    return "Z";
                } // end GetItemGradeWithID

                public string GetItemType(string id) {
                    if (id.Length < 2) return "null";
                    // end if
                    string prefix = id.Substring(0, 2);
                    switch (prefix) {
                        default:
                            DebugTool.ThrowException("ItemConfig GetItemType id error!!!" + " id:" + id);
                            return "null";
                        case "10": return ConstConfig.EQUIP;
                        case "20": return ConstConfig.CONSUME;
                        case "30": return ConstConfig.STUFF;
                        case "40": return ConstConfig.PRINT;
                    } // end switch
                } // end GetItemTypeWithID
            } // end class ItemConfig
        } // end namespace Item 
    } // end namespace Config
} // end namespace Custom 

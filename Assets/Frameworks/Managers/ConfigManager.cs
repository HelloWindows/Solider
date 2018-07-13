/*******************************************************************
 * FileName: ConfigManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Manager {
        public class ConfigManager {
            private StuffConfig stuffConfig;
            private EquipConfig equipConfig;
            private ConsumeConfig consumeConfig;
            private static ConfigManager instance;

            public static ConfigManager GetInstance() {
                if (null == instance) instance = new ConfigManager();
                // end if
                return instance;
            } // end GetInstance

            private ConfigManager() {
                AssetBundle assetbundle = PlatformManager.LoadFromStreamingAssets("config/res_config.unity3d");
                string stuffJson = assetbundle.LoadAsset<TextAsset>("assets/config/stuff_res_config.json").text;
                string equipJson = assetbundle.LoadAsset<TextAsset>("assets/config/equipment_res_config.json").text;
                string consumeJson = assetbundle.LoadAsset<TextAsset>("assets/config/consumable_res_config.json").text;
                stuffConfig = new StuffConfig(stuffJson);
                equipConfig = new EquipConfig(equipJson);
                consumeConfig = new ConsumeConfig(consumeJson);
                assetbundle.Unload(false);
            } // end ConfigManager

            public StuffInfo GetStuffInfoWithID(string id) {
                return stuffConfig.GetStuffInfoWithID(id);
            } // end GetConsumeInfoWithID

            public ConsumeInfo GetConsumeInfoWithID(string id) {
                return consumeConfig.GetConsumeInfoWithID(id);
            } // end GetConsumeInfoWithID

            public ConsumeProperty GetConsumePropertyWithID(string id) {
                return consumeConfig.GetConsumePropertyWithID(id);
            } // end GetConsumePropertyWithID

            public EquipInfo GetEquipInfoWithID(string id) {
                return equipConfig.GetEquipInfoWithID(id);
            } // end GetEquipInfoWithID

            public EquipProperty GetEquipPropertyWithID(string id) {
                return equipConfig.GetEquipPropertyWithID(id);
            } // end GetEquipPropertyWithID

            public string GetItemGradeWithID(string id) {
                string grade = null;
                if (equipConfig.GetEquipGradeWithID(id, out grade)) return grade;
                // end if
                if (consumeConfig.GetConsumeGradeWithID(id, out grade)) return grade;
                // end if
                if (stuffConfig.GetStuffGradeWithID(id, out grade)) return grade;
                // end if
                return "Z";
            } // end GetItemGradeWithID

            public string GetItemTypeWithID(string id) {
                if (equipConfig.CheckIsEquipWithID(id)) return "equip";
                // end if
                if (consumeConfig.CheckIsConsumeWithID(id)) return "consume";
                // end if
                return "null";
            } // end GetItemTypeWithID
        } // end class ConfigManager 
    } // end  namespace Manager
} // end namespace Framework
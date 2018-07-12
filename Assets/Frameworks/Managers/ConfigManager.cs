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
            private EquipConfig equipConfig;
            private static ConfigManager instance;

            public static ConfigManager GetInstance() {
                if (null == instance) instance = new ConfigManager();
                // end if
                return instance;
            } // end GetInstance

            private ConfigManager() {
                equipConfig = new EquipConfig();
            } // end ConfigManager

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
                return "Z";
            } // end GetItemGradeWithID

            public string GetItemTypeWithID(string id) {
                if (equipConfig.CheckIsEquipWithID(id)) return "equip";
                // end if
                return "null";
            } // end GetItemTypeWithID
        } // end class ConfigManager 
    } // end  namespace Manager
} // end namespace Framework
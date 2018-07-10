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

            private ConfigManager() {
                equipConfig = new EquipConfig();
            } // end ConfigManager

            public EquipInfo GetEquipInfoWithID(string id) {
                return equipConfig.GetEquipInfoWithID(id);
            } // end GetEquipInfoWithID

            public EquipProperty GetEquipPropertyWithID(string id) {
                return equipConfig.GetEquipPropertyWithID(id);
            } // end GetEquipPropertyWithID
        } // end class ConfigManager 
    } // end  namespace Manager
} // end namespace Framework
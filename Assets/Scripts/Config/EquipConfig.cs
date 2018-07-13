/*******************************************************************
 * FileName: EquipConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        public class EquipConfig {
            private Dictionary<string, EquipInfo> dict;

            public EquipConfig(string jsonStr) {
                dict = new Dictionary<string, EquipInfo>();
                JsonData data = JsonMapper.ToObject(jsonStr);
                JsonData list = data["itemlist"];
      
                for (int i = 0; i < list.Count; i++) {
                    EquipInfo info = new EquipInfo(list[i]);
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

            public bool GetEquipGradeWithID(string id, out string grade) {
                if (CheckIsEquipWithID(id)) {
                    grade = dict[id].grade;
                    return true;
                } // end if
                grade = null;
                return false;
            } // end GetEquipGradeWithID
        } // end class EquipConfig 
    } // end namespace Config
} // end namespace Custom
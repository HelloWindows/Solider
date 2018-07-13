/*******************************************************************
 * FileName: ConsumeConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using LitJson;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        public class ConsumeConfig {
            private Dictionary<string, ConsumeInfo> dict;

            public ConsumeConfig(string jsonStr) {
                dict = new Dictionary<string, ConsumeInfo>();
                JsonData data = JsonMapper.ToObject(jsonStr);
                JsonData list = data["itemlist"];

                for (int i = 0; i < list.Count; i++) {
                    ConsumeInfo info = new ConsumeInfo(list[i]);            
                    dict.Add((string)list[i]["id"], info);
                } // end for
            } // end EquipConfig

            public bool CheckIsConsumeWithID(string id) {
                if (dict.ContainsKey(id)) return true;
                // end if
                return false;
            } // end CheckIsEquipWithID

            public ConsumeInfo GetConsumeInfoWithID(string id) {
                if (CheckIsConsumeWithID(id)) return dict[id];
                // end if
                return null;
            } // end GetEquipInfoWithID

            public ConsumeProperty GetConsumePropertyWithID(string id) {
                if (CheckIsConsumeWithID(id)) return dict[id].property;
                // end if
                return null;
            } // end GetEquipPropertyWithID

            public bool GetConsumeGradeWithID(string id, out string grade) {
                if (CheckIsConsumeWithID(id)) {
                    grade = dict[id].grade;
                    return true;
                } // end if
                grade = null;
                return false;
            } // end GetEquipGradeWithID
        } // end class ConsumeConfig 
    } // end namespace Config 
} // end namespace Solider
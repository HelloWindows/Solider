/*******************************************************************
 * FileName: StuffConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using System.Collections.Generic;

namespace Solider {
    namespace Config {
        public class StuffConfig {
            private Dictionary<string, StuffInfo> dict;

            public StuffConfig(string jsonStr) {
                dict = new Dictionary<string, StuffInfo>();
                JsonData data = JsonMapper.ToObject(jsonStr);
                JsonData list = data["itemlist"];
      
                for (int i = 0; i < list.Count; i++) {
                    StuffInfo info = new StuffInfo(list[i]);
                    dict.Add((string)list[i]["id"], info);
                } // end for
            } // end EquipConfig
      
            public bool CheckIsStuffWithID(string id) {
                if (dict.ContainsKey(id)) return true;
                // end if
                return false;
            } // end CheckIsEquipWithID

            public StuffInfo GetStuffInfoWithID(string id) {
                if (CheckIsStuffWithID(id)) return dict[id];
                // end if
                return null;
            } // end GetEquipInfoWithID

            public bool GetStuffGradeWithID(string id, out string grade) {
                if (CheckIsStuffWithID(id)) {
                    grade = dict[id].grade;
                    return true;
                } // end if
                grade = null;
                return false;
            } // end GetEquipGradeWithID
        } // end class StuffConfig 
    } // end namespace Config
} // end namespace Solider
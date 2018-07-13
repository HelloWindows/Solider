/*******************************************************************
 * FileName: ConsumeInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using Solider.Manager;
using System.Text;
using UnityEngine;

namespace Solider {
    namespace Config {
        public class ConsumeInfo {
            private static readonly StringBuilder infoBuilder = new StringBuilder();
            public string id { get; private set; }
            public string name { get; private set; }
            public string grade { get; private set; }
            public string role { get; private set; }
            public string spritepath { get; private set; }
            public string intro { get; private set; }
            public ConsumeProperty property { get; private set; }

            public ConsumeInfo(JsonData data) {
                id = (string)data["id"];
                name = (string)data["name"];
                grade = (string)data["grade"];
                role = (string)data["role"];
                spritepath = (string)data["spritepath"];
                intro = (string)data["intro"];
                property = new ConsumeProperty(data["property"]);
            } // end EquipInfo

            public override string ToString() {
                infoBuilder.Length = 0;
                infoBuilder.Append("<size=24>");
                switch (grade) {
                    case "A":
                        infoBuilder.Append("<color=#FFD700FF>");
                        infoBuilder.Append(name);
                        break;

                    case "B":
                        infoBuilder.Append("<color=#ADFF2FFF>");
                        infoBuilder.Append(name);
                        break;

                    case "C":
                        infoBuilder.Append("<color=#0000FFFF>");
                        infoBuilder.Append(name);
                        break;

                    default:
                        infoBuilder.Append("<color=#FFFFFFFF>");
                        infoBuilder.Append(name);
                        break;
                } // end switch
                infoBuilder.Append("</color>");
                infoBuilder.Append("</size>");
                infoBuilder.Append('\n');
                infoBuilder.Append('\n');
                infoBuilder.Append("<size=18>");
                infoBuilder.Append("消耗品");
                infoBuilder.Append("                                     ");
                if (role != "all" && role != PlayerManager.roleType) {
                    infoBuilder.Append("<color=#FF0000FF>");

                } else {
                    infoBuilder.Append("<color=#FFFFFFFF>");
                }// end 

                switch (role) {
                    case "Shooter":
                        infoBuilder.Append("射手");
                        break;

                    case "Solider":
                        infoBuilder.Append("战士");
                        break;

                    default:
                        infoBuilder.Append("全部");
                        break;
                } // end switch
                infoBuilder.Append("</color>");
                infoBuilder.Append("</size>");
                infoBuilder.Append('\n');
                infoBuilder.Append('\n');

                infoBuilder.Append("<size=20>");
                AppendValue("Hp:", property.hp);
                AppendValue("Mp:", property.mp);
                AppendValue("每秒Hp:", property.lasthp);
                AppendValue("每秒Mp:", property.lastmp);
                AppendValue("持续时间:", property.time);
                AppendValue("攻击力:", property.att);
                AppendValue("攻速:", property.attspeed);
                AppendValue("移速:", property.movspeed);
                AppendValue("暴击率:", property.crit);
                AppendValue("冷却时间:", property.cooling);
                infoBuilder.Append("</size>");
                infoBuilder.Append('\n');
                infoBuilder.Append('\n');

                infoBuilder.Append("<size=16>");
                infoBuilder.Append("<color=#90EE90FF>");
                infoBuilder.Append(intro);
                infoBuilder.Append("</color>");
                infoBuilder.Append("</size>");
                return infoBuilder.ToString();
            } // end ToString

            private void AppendValue(string prefix, float value) {
                if (0 == value) return;
                // end if
                infoBuilder.Append(prefix);
                infoBuilder.Append(value);
                infoBuilder.Append('\n');
            } // end AppendValue
        } // end class ConsumeInfo 

        public class ConsumeProperty {
            public int hp { get; private set; }
            public int mp { get; private set; }
            public int lasthp { get; private set; }
            public int lastmp { get; private set; }
            public float time { get; private set; }
            public int att { get; private set; }
            public float attspeed { get; private set; }
            public float movspeed { get; private set; }
            public float crit { get; private set; }
            public float cooling { get; private set; }

            public ConsumeProperty(JsonData data) {
                hp = (int)data["hp"];
                mp = (int)data["mp"];
                lasthp = (int)data["lasthp"];
                lastmp = (int)data["lastmp"];
                time = (float)data["time"];
                att = (int)data["att"];
                attspeed = (float)data["attspeed"];
                movspeed = (float)data["movspeed"];
                crit = (float)data["crit"];
                cooling = (float)data["cooling"];
            } // end ConsumeProperty
        } // end class EquipProperty
    } // end namespace Config 
} // end namespace Solider
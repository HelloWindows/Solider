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
    namespace Model {
        public class ConsumeInfo : ItemInfo {
            public string role { get; private set; }

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

            public ConsumeInfo(JsonData data) {
                id = (string)data["id"];
                name = (string)data["name"];
                grade = (string)data["grade"];
                role = (string)data["role"];
                spritepath = (string)data["spritepath"];
                intro = (string)data["intro"];
                JsonData property = data["property"];

                hp = (int)property["hp"];
                mp = (int)property["mp"];
                lasthp = (int)property["lasthp"];
                lastmp = (int)property["lastmp"];
                time = (float)property["time"];
                att = (int)property["att"];
                attspeed = (float)property["attspeed"];
                movspeed = (float)property["movspeed"];
                crit = (float)property["crit"];
                cooling = (float)property["cooling"];
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
                AppendValue("Hp:", hp);
                AppendValue("Mp:", mp);
                AppendValue("每秒Hp:", lasthp);
                AppendValue("每秒Mp:", lastmp);
                AppendValue("持续时间:", time);
                AppendValue("攻击力:", att);
                AppendValue("攻速:", attspeed);
                AppendValue("移速:", movspeed);
                AppendValue("暴击率:", crit);
                AppendValue("冷却时间:", cooling);
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
        } // end class ConsumeInfo 
    } // end namespace Config 
} // end namespace Solider
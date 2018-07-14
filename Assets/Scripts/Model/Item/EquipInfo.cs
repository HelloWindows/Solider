/*******************************************************************
 * FileName: EquipmentConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using Solider.Manager;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Solider {
    namespace Model {
        public class EquipInfo : ItemInfo {
            public string type { get; private set; }
            public string role { get; private set; }

            public int attmin { get; private set; }
            public int attmax { get; private set; }
            public int def { get; private set; }
            public float attspeed { get; private set; }
            public float movspeed { get; private set; }
            public float crit { get; private set; }
            public float clip { get; private set; }

            public EquipInfo(JsonData data) {
                id = (string)data["id"];
                name = (string)data["name"];
                grade = (string)data["grade"];
                spritepath = (string)data["spritepath"];
                intro = (string)data["intro"];

                type = (string)data["type"];
                role = (string)data["role"];

                JsonData property = data["property"];
                attmin = (int)property["attmin"];
                attmax = (int)property["attmax"];
                def = (int)property["def"];
                attspeed = (float)property["attspeed"];
                movspeed = (float)property["movspeed"];
                crit = (float)property["crit"];
                clip = (float)property["clip"];
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

                switch (type) {
                    case "weapon":
                        infoBuilder.Append("武器");
                        break;
                    case "armor":
                        infoBuilder.Append("盔甲");
                        break;
                    case "shoes":
                        infoBuilder.Append("战靴");
                        break;
                    default:
                        infoBuilder.Append("无法使用");
                        break;
                } // end swtich
                infoBuilder.Append("                          ");

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

                if (attmin != 0 || attmax != 0) {
                    infoBuilder.Append("战斗力：");
                    infoBuilder.Append(attmin);
                    infoBuilder.Append(" - ");
                    infoBuilder.Append(attmax);
                    infoBuilder.Append('\n');
                } // end if
                AppendValue("防御力：", def);
                AppendValue("攻速：", attspeed);
                AppendValue("移速：", movspeed);
                AppendValue("暴击率：", crit);

                if (clip != 0) {
                    infoBuilder.Append("弹夹：");
                    infoBuilder.Append(clip);
                    infoBuilder.Append(" 发");
                    infoBuilder.Append('\n');
                } // end if
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
        } // end class EquipmentInfo 
    } // end namespace Config
} // end namespace Custom
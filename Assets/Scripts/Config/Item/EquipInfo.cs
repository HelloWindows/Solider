/*******************************************************************
 * FileName: EquipmentConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using Framework.Config;
using Solider.Manager;

namespace Solider {
    namespace Config {
        public class EquipInfo : ItemInfo {
            public string type { get; private set; }
            public string role { get; private set; }

            public int XHP { get; private set; }
            public int XMP { get; private set; }
            public int HOT { get; private set; }
            public int MOT { get; private set; }
            public int NATK { get; private set; }
            public int XATK { get; private set; }
            public int NMGK { get; private set; }
            public int XMGK { get; private set; }
            public int DEF { get; private set; }
            public int RGS { get; private set; }
            public float ASP { get; private set; }
            public float MSP { get; private set; }
            public float CRT { get; private set; }
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
                XHP = (int)property["XHP"];
                XMP = (int)property["XMP"];
                HOT = (int)property["HOT"];
                MOT = (int)property["MOT"];
                NATK = (int)property["NATK"];
                XATK = (int)property["XATK"];
                DEF = (int)property["DEF"];
                RGS = (int)property["RGS"];
                ASP = (float)property["ASP"];
                MSP = (float)property["MSP"];
                CRT = (float)property["CRT"];
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

                if (role != ConstConfig.ALLROLE && role != RoleManager.roleType) {
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
                AppendValue("MaxHp：", XHP);
                AppendValue("MaxMp：", XMP);
                AppendValue("每秒Hp：", HOT);
                AppendValue("每秒Mp：", MOT);

                if (NATK != 0 || XATK != 0) {
                    infoBuilder.Append("物理攻击：");
                    infoBuilder.Append(NATK);
                    infoBuilder.Append(" - ");
                    infoBuilder.Append(XATK);
                    infoBuilder.Append('\n');
                } // end if
                AppendValue("防御力：", DEF);
                AppendValue("攻速：", ASP);
                AppendValue("移速：", MSP);
                AppendValue("暴击率：", CRT);

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
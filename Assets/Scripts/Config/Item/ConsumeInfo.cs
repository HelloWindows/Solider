/*******************************************************************
 * FileName: ConsumeInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using Solider.Manager;
using Framework.Config.Const;

namespace Solider {
    namespace Config {
        public class ConsumeInfo : ItemInfo {
            public string role { get; private set; }

            public int HP { get; private set; }
            public int MP { get; private set; }
            public int HOT { get; private set; }
            public int MOT { get; private set; }
            public int ATK { get; private set; }
            public int MGK { get; private set; }
            public float ASP { get; private set; }
            public float MSP { get; private set; }
            public float CRT { get; private set; }

            public float LOT { get; private set; } // 持续时间
            public float CD { get; private set; } // 冷却时间

            public ConsumeInfo(JsonData data) {
                id = (string)data["id"];
                name = (string)data["name"];
                grade = (string)data["grade"];
                role = (string)data["role"];
                spritepath = (string)data["spritepath"];
                intro = (string)data["intro"];
                JsonData property = data["property"];
                HP = (int)property["HP"];
                MP = (int)property["MP"];
                HOT = (int)property["HOT"];
                MOT = (int)property["MOT"];
                ATK = (int)property["ATK"];
                ASP = (float)property["ASP"];
                MSP = (float)property["MSP"];
                CRT = (float)property["CRT"];
                LOT = (float)property["LOT"];
                CD = (float)property["CD"];
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
                if (role != ConstConfig.ALLROLE && role != GameManager.playerInfo.roleType) {
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
                AppendValue("Hp:", HP);
                AppendValue("Mp:", MP);
                AppendValue("每秒Hp:", HOT);
                AppendValue("每秒Mp:", MOT);
                AppendValue("持续时间:", LOT);
                AppendValue("攻击力:", ATK);
                AppendValue("攻速:", ASP);
                AppendValue("移速:", MSP);
                AppendValue("暴击率:", CRT);
                AppendValue("冷却时间:", CD);
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
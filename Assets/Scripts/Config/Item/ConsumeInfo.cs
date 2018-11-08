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
            public readonly string role;

            public readonly int HP;
            public readonly int MP;
            public readonly float HPR;
            public readonly float MPR;
            public readonly float XHR;
            public readonly float XMR;
            public readonly int HOT;
            public readonly int MOT;
            public readonly int ATK;
            public readonly int MGK;
            public readonly float ASP;
            public readonly float MSP;
            public readonly float CRT;

            public readonly float LOT; // 持续时间
            public readonly float CD; // 冷却时间

            public ConsumeInfo(JsonData data) {
                id = (string)data["id"];
                name = (string)data["name"];
                grade = (string)data["grade"];
                maximum = (int)data["maximum"];
                role = (string)data["role"];
                spritepath = (string)data["spritepath"];
                intro = (string)data["intro"];
                JsonData property = data["property"];
                HP = (int)property["HP"];
                MP = (int)property["MP"];
                HPR = (float)property["HPR"];
                MPR = (float)property["MPR"];
                XHR = (float)property["XHR"];
                XMR = (float)property["XMR"];
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
                        break;

                    case "B":
                        infoBuilder.Append("<color=#800080FF>");
                        break;

                    case "C":
                        infoBuilder.Append("<color=#ADFF2FFF>");
                        break;

                    case "D":
                        infoBuilder.Append("<color=#0000FFFF>");
                        break;

                    default:
                        infoBuilder.Append("<color=#FFFFFFFF>");
                        break;
                } // end switch
                infoBuilder.Append(name);
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
/*******************************************************************
 * FileName: BluePrintInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;

namespace Solider {
    namespace Config {
        public class BluePrintInfo : ItemInfo {

            public readonly string[] stuffIDArr;
            public readonly int[] stuffCountArr;

            public BluePrintInfo(JsonData data) {
                id = (string)data["id"];
                name = (string)data["name"];
                grade = (string)data["grade"];
                spritepath = (string)data["spritepath"];
                intro = (string)data["intro"];
                JsonData property = data["property"];
                int num = (int)property["NUM"];
                stuffIDArr = new string[num];
                stuffCountArr = new int[num];
                for (int i = 0; i < num; i++) {
                    stuffIDArr[i] = (string)property["ID_" + i];
                    stuffCountArr[i] = (int)property["COUNT_" + i];
                } // end for
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
                infoBuilder.Append("制作图");
                infoBuilder.Append('\n');
                infoBuilder.Append('\n');
                infoBuilder.Append("</size>");
                infoBuilder.Append("<size=16>");
                infoBuilder.Append("<color=#90EE90FF>");
                infoBuilder.Append(intro);
                infoBuilder.Append("</color>");
                infoBuilder.Append("</size>");
                return infoBuilder.ToString();
            } // end ToString
        } // end class BluePrintInfo 
    } // end namespace Config 
} // end namespace Solider
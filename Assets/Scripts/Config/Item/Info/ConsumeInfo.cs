/*******************************************************************
 * FileName: ConsumeInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Config.Icon;
using Solider.Config.Interface;

namespace Solider {
    namespace Config {
        namespace Item {
            public class ConsumeInfo : ItemInfo, IConsumeInfo {
                public int HP { get; private set; }
                public int MP { get; private set; }
                public float HPR { get; private set; }
                public float MPR { get; private set; }
                public float XHR { get; private set; }
                public float XMR { get; private set; }
                public int CD { get; private set; }
                public IBuffInfo buff { get; private set; }

                public ConsumeInfo(JsonData data) {
                    buff = null;
                    id = (string)data["id"];
                    name = (string)data["name"];
                    grade = (string)data["grade"];
                    maximum = (int)data["maximum"];
                    spritepath = (string)data["spritepath"];
                    intro = (string)data["intro"];
                    JsonData property = data["property"];
                    HP = JsonTool.GetJsonData_Int(property, "HP");
                    MP = JsonTool.GetJsonData_Int(property, "MP");
                    HPR = JsonTool.GetJsonData_Float(property, "HPR");
                    MPR = JsonTool.GetJsonData_Float(property, "MPR");
                    XHR = JsonTool.GetJsonData_Float(property, "XHR");
                    XMR = JsonTool.GetJsonData_Float(property, "XMR");
                    CD = (int)property["CD"];
                    if ((bool)data["buff"]) buff = new BuffInfo(data);
                    // end if
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
                    infoBuilder.Append("</size>");
                    infoBuilder.Append('\n');
                    infoBuilder.Append('\n');
                    infoBuilder.Append("<size=20>");
                    AppendValue("恢复", HP, "HP");
                    AppendValue("恢复:", MP, "MP");
                    if (null != buff) {
                        AppendValue("每秒Hp:", buff.HOT);
                        AppendValue("每秒Mp:", buff.MOT);
                        AppendValue("每秒恢复", buff.HPR, "%已损失HP");
                        AppendValue("每秒恢复", buff.MPR, "%已损失MP");
                        AppendValue("每秒恢复", buff.XHR, "%最大HP");
                        AppendValue("每秒恢复", buff.XMR, "%最大MP");
                        AppendValue("提高", buff.ATKR, "%物理攻击力");
                        AppendValue("提高", buff.MGKR, "%魔法攻击力");
                        AppendValue("提高", buff.DEFR, "%物理防御力");
                        AppendValue("提高", buff.RGSR, "%魔法防御力");
                        AppendValue("提高", buff.ASPR, "%攻击速度");
                        AppendValue("提高", buff.MSPR, "%移动速度");
                        AppendValue("提高", buff.HIT, "%命中率");
                        AppendValue("提高", buff.AVD, "%闪避率");
                        AppendValue("提高", buff.CRT, "%暴击率");
                        AppendValue("持续", buff.LOT, "秒");
                    } // end if
                    AppendValue("冷却时间:", CD, "秒");
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
        } // end namespace Item
    } // end namespace Config 
} // end namespace Solider
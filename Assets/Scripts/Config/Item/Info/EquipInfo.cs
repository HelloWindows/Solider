/*******************************************************************
 * FileName: EquipmentConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using Framework.Config.Const;
using Solider.Manager;
using Solider.Config.Character;
using Solider.Config.Interface;

namespace Solider {
    namespace Config {
        namespace Item {
            public class EquipInfo : ItemInfo, IEquipInfo {
                public string type { get; private set; }
                public string role { get; private set; }
                public IAttributeInfo attributeInfo { get; private set; }

                public EquipInfo(JsonData data) {
                    id = (string)data["id"];
                    name = (string)data["name"];
                    grade = (string)data["grade"];
                    maximum = (int)data["maximum"];
                    spritepath = (string)data["spritepath"];
                    intro = (string)data["intro"];

                    type = (string)data["type"];
                    role = (string)data["role"];

                    JsonData property = data["property"];
                    attributeInfo = new AttributeInfo(property);
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
                    switch (type) {
                        case ConstConfig.WEAPON:
                            infoBuilder.Append("武器");
                            break;
                        case ConstConfig.NECKLACE:
                            infoBuilder.Append("项链");
                            break;
                        case ConstConfig.RING:
                            infoBuilder.Append("戒指");
                            break;
                        case ConstConfig.WING:
                            infoBuilder.Append("翅膀");
                            break;
                        case ConstConfig.ARMOR:
                            infoBuilder.Append("盔甲");
                            break;
                        case ConstConfig.PANTS:
                            infoBuilder.Append("裤子");
                            break;
                        case ConstConfig.SHOES:
                            infoBuilder.Append("鞋子");
                            break;
                        default:
                            infoBuilder.Append("无法使用");
                            break;
                    } // end swtich
                    infoBuilder.Append("                          ");
                    if (role != ConstConfig.ALLROLE && role != GameManager.playerInfo.roletype) {
                        infoBuilder.Append("<color=#FF0000FF>");
                    } else {
                        infoBuilder.Append("<color=#FFFFFFFF>");
                    }// end 
                    switch (role) {
                        case ConstConfig.SWORDMAN:
                            infoBuilder.Append("狂战士");
                            break;

                        case ConstConfig.ARCHER:
                            infoBuilder.Append("弓箭手");
                            break;

                        case ConstConfig.MAGICIAN:
                            infoBuilder.Append("魔法师");
                            break;

                        case ConstConfig.ALLROLE:
                            infoBuilder.Append("全部");
                            break;

                        default:
                            infoBuilder.Append("Bug!!!");
                            break;
                    } // end switch
                    infoBuilder.Append("</color>");
                    infoBuilder.Append("</size>");
                    infoBuilder.Append('\n');
                    infoBuilder.Append('\n');
                    infoBuilder.Append("<size=20>");
                    AppendValue("MaxHp：", attributeInfo.XHP);
                    AppendValue("MaxMp：", attributeInfo.XMP);
                    AppendValue("每秒Hp：", attributeInfo.HOT);
                    AppendValue("每秒Mp：", attributeInfo.MOT);
                    if (attributeInfo.NATK != 0 || attributeInfo.XATK != 0) {
                        infoBuilder.Append("物理攻击：");
                        infoBuilder.Append(attributeInfo.NATK);
                        infoBuilder.Append(" - ");
                        infoBuilder.Append(attributeInfo.XATK);
                        infoBuilder.Append('\n');
                    } // end if
                    if (attributeInfo.NMGK != 0 || attributeInfo.XMGK != 0) {
                        infoBuilder.Append("魔法攻击：");
                        infoBuilder.Append(attributeInfo.NMGK);
                        infoBuilder.Append(" - ");
                        infoBuilder.Append(attributeInfo.XMGK);
                        infoBuilder.Append('\n');
                    } // end if
                    AppendValue("防御力：", attributeInfo.DEF);
                    AppendValue("攻速：", attributeInfo.ASP, "%");
                    AppendValue("移速：", attributeInfo.MSP, "%");
                    AppendValue("命中率：", attributeInfo.HIT);
                    AppendValue("闪避率：", attributeInfo.AVD);
                    AppendValue("暴击率：", attributeInfo.CRT);
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
        } // end namespace Item 
    } // end namespace Config
} // end namespace Custom
/*******************************************************************
 * FileName: CharacterAttribute.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Text;
using Solider.Config;
using Solider.Model.Data;
using Framework.Config.Const;

namespace Solider {
    namespace Character {
        namespace Model {
            public class CharacterAttribute : AttributeData {
                private static readonly StringBuilder infoBuilder = new StringBuilder();
                private string roleType;

                public CharacterAttribute(int id, string name, string roleType) {
                    this.id = id;
                    this.name = name;
                    this.roleType = roleType;
                } // end RoleAttribute

                /// <summary>
                /// 初始化角色数据
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="init"> 初始数据 </param>
                /// <returns> 结果数据 </returns>
                public static CharacterAttribute operator +(CharacterAttribute role, CharacterInitAttribute init) {
                    role.XHP = init.XHP;
                    role.XMP = init.XMP;
                    role.NATK = init.NATK;
                    role.XATK = init.XATK;
                    role.NMGK = init.NMGK;
                    role.XMGK = init.XMGK;
                    role.HOT = init.HOT;
                    role.MOT = init.MOT;
                    role.DEF = init.DEF;
                    role.RGS = init.RGS;
                    role.ASP = init.ASP;
                    role.MSP = init.MSP;
                    role.CRT = init.CRT;
                    return role;
                } // end operator +

                /// <summary>
                /// 置换临时数据角色数据
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="temp"> 临时数据 </param>
                /// <returns> 结果数据 </returns>
                public static CharacterAttribute operator +(CharacterAttribute role, CharacterAttribute temp) {
                    role.XHP = temp.XHP;
                    role.XMP = temp.XMP;
                    role.NATK = temp.NATK;
                    role.XATK = temp.XATK;
                    role.NMGK = temp.NMGK;
                    role.XMGK = temp.XMGK;
                    role.HOT = temp.HOT;
                    role.MOT = temp.MOT;
                    role.DEF = temp.DEF;
                    role.RGS = temp.RGS;
                    role.ASP = temp.ASP;
                    role.MSP = temp.MSP;
                    role.CRT = temp.CRT;
                    return role;
                } // end operator +

                /// <summary>
                /// 受到攻击
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="att"> 攻击数据 </param>
                /// <returns> 结果数据 </returns>
                public static CharacterAttribute operator +(CharacterAttribute role, AttackData att) {
                    if (att.ismiss) return role;
                    // end if
                    int atk = att.ATK - role.DEF;
                    if (atk < 0) atk = 0;
                    // end if
                    int mgk = att.MGK - role.RGS;
                    if (mgk < 0) mgk = 0;
                    // end if
                    int value = atk + mgk;
                    if (value < 1) value = 1;
                    // end if
                    role.HP -= value;
                    if (role.HP < 0) role.HP = 0;
                    // end if
                    return role;
                } // end operator +

                /// <summary>
                /// HP 和 MP 增益
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="data"> HP 与 MP 数据 </param>
                /// <returns> 结果数据 </returns>
                public static CharacterAttribute operator +(CharacterAttribute role, FairData data) {
                    role.HP += data.HP;
                    role.MP += data.MP;

                    if (data.HPP > 0) {
                        int value = role.XHP - role.HP;
                        value = (int)(value * data.HPP / 100f);
                        role.HP += value;
                    } // end if

                    if (data.MPP > 0) {
                        int value = role.XMP - role.MP;
                        value = (int)(value * data.MPP / 100f);
                        role.MP += value;
                    } // end if

                    if (data.XHPP > 0) {
                        role.HP += (int)(role.XHP * data.XHPP / 100f);
                    } // end if

                    if (data.XMPP > 0) {
                        role.MP += (int)(role.XMP * data.XMPP / 100f);
                    } // end if

                    if (role.HP < 0) role.HP = 0;
                    // end if
                    if (role.HP > role.XHP) role.HP = role.XHP;
                    // end if
                    if (role.MP < 0) role.MP = 0;
                    // end if
                    if (role.MP > role.XMP) role.MP = role.XMP;
                    // end if
                    return role;
                } // end operator +

                /// <summary>
                /// 穿戴装备
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="info"> 装备数据 </param>
                /// <returns> 结果数据 </returns>
                public static CharacterAttribute operator +(CharacterAttribute role, EquipInfo info) {
                    role.XHP += info.XHP;
                    role.XMP += info.XMP;
                    role.NATK += info.NATK;
                    role.XATK += info.XATK;
                    role.NMGK += info.NMGK;
                    role.XMGK += info.XMGK;
                    role.HOT += info.HOT;
                    role.MOT += info.MOT;
                    role.DEF += info.DEF;
                    role.RGS += info.RGS;
                    role.ASP += info.ASP;
                    role.MSP += info.MSP;
                    role.CRT += info.CRT;
                    return role;
                } // end operator +

                /// <summary>
                /// 卸下装备
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="info"> 装备数据 </param>
                /// <returns> 结果数据 </returns>
                public static CharacterAttribute operator -(CharacterAttribute role, EquipInfo info) {
                    role.XHP -= info.XHP;
                    role.XMP -= info.XMP;
                    role.NATK -= info.NATK;
                    role.XATK -= info.XATK;
                    role.NMGK -= info.NMGK;
                    role.XMGK -= info.XMGK;
                    role.HOT -= info.HOT;
                    role.MOT -= info.MOT;
                    role.DEF -= info.DEF;
                    role.RGS -= info.RGS;
                    role.ASP -= info.ASP;
                    role.MSP -= info.MSP;
                    role.CRT -= info.CRT;
                    return role;
                } // end operator -

                public override string ToString() {
                    infoBuilder.Length = 0;
                    infoBuilder.Append("<size=24>");
                    infoBuilder.Append("名字：");
                    infoBuilder.Append(name);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("角色：");
                    switch (roleType) {
                        case ConstConfig.ARCHER:
                            infoBuilder.Append("射手");
                        break;

                        case ConstConfig.MAGICIAN:
                            infoBuilder.Append("法师");
                        break;

                        case ConstConfig.SWORDMAN:
                            infoBuilder.Append("剑客");
                            break;

                        default:
                            infoBuilder.Append("全部");
                        break;
                    } // end switch
                    infoBuilder.Append('\n');

                    infoBuilder.Append("HP：");
                    infoBuilder.Append(HP);
                    infoBuilder.Append(" / ");
                    infoBuilder.Append(XHP);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("MP：");
                    infoBuilder.Append(MP);
                    infoBuilder.Append(" / ");
                    infoBuilder.Append(XMP);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("物理攻击：");
                    infoBuilder.Append(NATK);
                    infoBuilder.Append(" - ");
                    infoBuilder.Append(XATK);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("魔法攻击：");
                    infoBuilder.Append(NMGK);
                    infoBuilder.Append(" - ");
                    infoBuilder.Append(XMGK);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("hp恢复：");
                    infoBuilder.Append(HOT);
                    infoBuilder.Append("/s");
                    infoBuilder.Append('\n');

                    infoBuilder.Append("mp恢复：");
                    infoBuilder.Append(MOT);
                    infoBuilder.Append("/s");
                    infoBuilder.Append('\n');

                    infoBuilder.Append("物理防御：");
                    infoBuilder.Append(DEF);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("魔法防御：");
                    infoBuilder.Append(RGS);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("攻击速度：");
                    infoBuilder.Append(ASP);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("移动速度：");
                    infoBuilder.Append(MSP);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("暴击率：");
                    infoBuilder.Append(CRT);
                    infoBuilder.Append('\n');
                    infoBuilder.Append("</size>");
                    return infoBuilder.ToString();
                } // end ToString        
            } // end class CharacterAttribute
        } // end namespace Data
    } // end namespace Model
} // end namespace Solider 

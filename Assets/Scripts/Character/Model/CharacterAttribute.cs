﻿/*******************************************************************
 * FileName: CharacterAttribute.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model.Data;
using Framework.Config.Const;
using Solider.Config.Interface;

namespace Solider {
    namespace Character {
        namespace Model {
            public class CharacterAttribute : AttributeData {
                public string name { get; private set; }
                public int HP { get; private set; }
                public int MP { get; private set; }
                private string roleType;

                public CharacterAttribute(string name, string roleType) {
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
                    role.HP = temp.HP;
                    role.MP = temp.MP;
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
                public static CharacterAttribute operator +(CharacterAttribute role, RealData data) {
                    if (role.HP == role.XHP && role.MP == role.XMP) return role;
                    // end if
                    role.HP += data.HP;
                    role.MP += data.MP;
                    if (data.HPR > 0) {
                        int value = role.XHP - role.HP;
                        value = (int)(value * data.HPR / 100f);
                        role.HP += value;
                    } // end if
                    if (data.MPR > 0) {
                        int value = role.XMP - role.MP;
                        value = (int)(value * data.MPR / 100f);
                        role.MP += value;
                    } // end if
                    if (data.XHR > 0) {
                        role.HP += (int)(role.XHP * data.XHR / 100f);
                    } // end if
                    if (data.XMR > 0) {
                        role.MP += (int)(role.XMP * data.XMR / 100f);
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
                public static CharacterAttribute operator +(CharacterAttribute role, IEquipInfo info) {
                    role.XHP += info.attributeInfo.XHP;
                    role.XMP += info.attributeInfo.XMP;
                    role.NATK += info.attributeInfo.NATK;
                    role.XATK += info.attributeInfo.XATK;
                    role.NMGK += info.attributeInfo.NMGK;
                    role.XMGK += info.attributeInfo.XMGK;
                    role.HOT += info.attributeInfo.HOT;
                    role.MOT += info.attributeInfo.MOT;
                    role.DEF += info.attributeInfo.DEF;
                    role.RGS += info.attributeInfo.RGS;
                    role.ASP += info.attributeInfo.ASP;
                    role.MSP += info.attributeInfo.MSP;
                    role.HIT += info.attributeInfo.HIT;
                    role.AVD += info.attributeInfo.AVD;
                    role.CRT += info.attributeInfo.CRT;
                    return role;
                } // end operator +

                /// <summary>
                /// 卸下装备
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="info"> 装备数据 </param>
                /// <returns> 结果数据 </returns>
                public static CharacterAttribute operator -(CharacterAttribute role, IEquipInfo info) {
                    role.XHP -= info.attributeInfo.XHP;
                    role.XMP -= info.attributeInfo.XMP;
                    role.NATK -= info.attributeInfo.NATK;
                    role.XATK -= info.attributeInfo.XATK;
                    role.NMGK -= info.attributeInfo.NMGK;
                    role.XMGK -= info.attributeInfo.XMGK;
                    role.HOT -= info.attributeInfo.HOT;
                    role.MOT -= info.attributeInfo.MOT;
                    role.DEF -= info.attributeInfo.DEF;
                    role.RGS -= info.attributeInfo.RGS;
                    role.ASP -= info.attributeInfo.ASP;
                    role.MSP -= info.attributeInfo.MSP;
                    role.HIT -= info.attributeInfo.HIT;
                    role.AVD -= info.attributeInfo.AVD;
                    role.CRT -= info.attributeInfo.CRT;
                    return role;
                } // end operator -

                public override string ToString() {
                    infoBuilder.Length = 0;
                    infoBuilder.Append("<size=22>");
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

                    infoBuilder.Append("命中率：");
                    infoBuilder.Append(HIT);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("闪避率：");
                    infoBuilder.Append(AVD);
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

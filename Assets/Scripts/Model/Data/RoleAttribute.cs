/*******************************************************************
 * FileName: RoleAttribute.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections.Generic;
using System.Text;

namespace Solider {
    namespace Model {
        namespace Data {
            public class RoleAttribute : AttributeData {
                private static readonly StringBuilder infoBuilder = new StringBuilder();
                private string roleType;

                public RoleAttribute(string roleID, string name, string roleType) {
                    this.name = name;
                    this.roleType = roleType;
                    Dictionary<string, float> dict = new Dictionary<string, float>();
                    SqliteManager.GetRoleInfoWithID(roleID, ref dict);
                    XHP = (int)dict["xhp"];
                    XMP = (int)dict["xmp"];
                    NATK = (int)dict["natk"];
                    XATK = (int)dict["xatk"];
                    NMGK = (int)dict["nmgk"];
                    XMGK = (int)dict["xmgk"];
                    HOT = (int)dict["hot"];
                    MOT = (int)dict["mot"];
                    DEF = (int)dict["def"];
                    RGS = (int)dict["rgs"];
                    ASP = dict["asp"];
                    MSP = dict["msp"];
                    CRT = dict["crt"];
                    HP = XHP;
                    MP = XMP;
                } // end RoleAttribute

                /// <summary>
                /// 受到攻击
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="att"> 攻击数据 </param>
                /// <returns> 结果数据 </returns>
                public static RoleAttribute operator +(RoleAttribute role, AttackData att) {
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
                    return role;
                } // end operator +

                /// <summary>
                /// HP 和 MP 增益
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="data"> HP 与 MP 数据 </param>
                /// <returns> 结果数据 </returns>
                public static RoleAttribute operator +(RoleAttribute role, TreatData data) {
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

                    if (data.XHPR > 0) {
                        role.HP += (int)(role.XHP * data.XHPR / 100f);
                    } // end if

                    if (data.XMPR > 0) {
                        role.MP += (int)(role.XMP * data.XMPR / 100f);
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
                /// HP 和 MP 损失
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="data"> HP 与 MP 数据 </param>
                /// <returns> 结果数据 </returns>
                public static RoleAttribute operator -(RoleAttribute role, TreatData data) {
                    role.HP -= data.HP;
                    role.MP -= data.MP;

                    if (data.HPR > 0) {
                        int value = role.XHP - role.HP;
                        value = (int)(value * data.HPR / 100f);
                        role.HP -= value;
                    } // end if

                    if (data.MPR > 0) {
                        int value = role.XMP - role.MP;
                        value = (int)(value * data.MPR / 100f);
                        role.MP -= value;
                    } // end if

                    if (data.XHPR > 0) {
                        role.HP -= (int)(role.XHP * data.XHPR / 100f);
                    } // end if

                    if (data.XMPR > 0) {
                        role.MP -= (int)(role.XMP * data.XMPR / 100f);
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
                } // end operator -

                /// <summary>
                /// 穿戴装备
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="info"> 装备数据 </param>
                /// <returns> 结果数据 </returns>
                public static RoleAttribute operator +(RoleAttribute role, EquipInfo info) {
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
                public static RoleAttribute operator -(RoleAttribute role, EquipInfo info) {
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
            } // end class RoleAttribute
        } // end namespace Data
    } // end namespace Model
} // end namespace Solider 

/*******************************************************************
 * FileName: CharacterAttribute.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Solider.Config.Interface;
using Solider.ModelData.Data;
using Solider.ModelData.Interface;
using System.Text;

namespace Solider {
    namespace ModelData {
        namespace Character {
            public class CharacterAttribute : ICharacterAttribute {
                protected static readonly StringBuilder infoBuilder = new StringBuilder();
                public string name { get; private set; }
                public string roleType { get; private set; }
                public int HP { get; private set; }
                public int MP { get; private set; }
                public int XHP { get; private set; }
                public int XMP { get; private set; }
                public int NATK { get; private set; }
                public int XATK { get; private set; }
                public int NMGK { get; private set; }
                public int XMGK { get; private set; }
                public int HOT { get; private set; }
                public int MOT { get; private set; }
                public int DEF { get; private set; }
                public int RGS { get; private set; }
                public float ASP { get; private set; }
                public float MSP { get; private set; }
                public float HIT { get; private set; }
                public float AVD { get; private set; }
                public float CRT { get; private set; }

                public CharacterAttribute(string name, string roleType) {
                    this.name = name;
                    this.roleType = roleType;
                } // end RoleAttribute

                /// <summary>
                /// 初始化角色数据
                /// </summary>
                /// <param name="initAttribute"> 角色初始信息 </param>
                public void Init(IAttributeInfo initAttribute) {
                    XHP = initAttribute.XHP;
                    XMP = initAttribute.XMP;
                    NATK = initAttribute.NATK;
                    XATK = initAttribute.XATK;
                    NMGK = initAttribute.NMGK;
                    XMGK = initAttribute.XMGK;
                    HOT = initAttribute.HOT;
                    MOT = initAttribute.MOT;
                    DEF = initAttribute.DEF;
                    RGS = initAttribute.RGS;
                    ASP = initAttribute.ASP;
                    MSP = initAttribute.MSP;
                    HIT = initAttribute.HIT;
                    AVD = initAttribute.AVD;
                    CRT = initAttribute.CRT;
                } // end Init

                /// <summary>
                /// 拷贝属性数据
                /// </summary>
                /// <param name="attribute"> 属性数据 </param>
                public void Copy(IAttributeData attribute) {
                    XHP = attribute.XHP;
                    XMP = attribute.XMP;
                    NATK = attribute.NATK;
                    XATK = attribute.XATK;
                    NMGK = attribute.NMGK;
                    XMGK = attribute.XMGK;
                    HOT = attribute.HOT;
                    MOT = attribute.MOT;
                    DEF = attribute.DEF;
                    RGS = attribute.RGS;
                    ASP = attribute.ASP;
                    MSP = attribute.MSP;
                    HIT = attribute.HIT;
                    AVD = attribute.AVD;
                    CRT = attribute.CRT;
                } // end Copy

                public void Minus(AttackData data) {
                    if (data.ismiss) return;
                    // end if
                    int atk = data.ATK - DEF;
                    if (atk < 0) atk = 0;
                    // end if
                    int mgk = data.MGK - RGS;
                    if (mgk < 0) mgk = 0;
                    // end if
                    int value = atk + mgk;
                    if (value < 1) value = 1;
                    // end if
                    HP -= value;
                    if (HP < 0) HP = 0;
                    // end if
                } // end Minus

                /// <summary>
                /// 获得治疗的数据
                /// </summary>
                /// <param name="data"> 治疗数据 </param>
                public void Plus(IRealData data) {
                    if (HP == XHP && MP == XMP) return;
                    // end if
                    HP += data.HP;
                    MP += data.MP;
                    if (data.HPR > 0) {
                        int value = XHP - HP;
                        value = (int)(value * data.HPR / 100f);
                        HP += value;
                    } // end if
                    if (data.MPR > 0) {
                        int value = XMP - MP;
                        value = (int)(value * data.MPR / 100f);
                        MP += value;
                    } // end if
                    if (data.XHR > 0) HP += (int)(XHP * data.XHR / 100f);
                    // end if
                    if (data.XMR > 0) MP += (int)(XMP * data.XMR / 100f);
                    // end if
                    if (HP < 0) HP = 0;
                    // end if
                    if (HP > XHP) HP = XHP;
                    // end if
                    if (MP < 0) MP = 0;
                    // end if
                    if (MP > XMP) MP = XMP;
                    // end if
                } // end Plus

                /// <summary>
                /// 穿戴装备的数据
                /// </summary>
                /// <param name="info"> 装备信息 </param>
                public void Plus(IEquipInfo info) {
                    if (null == info) return;
                    // end if
                    XHP += info.attributeInfo.XHP;
                    XMP += info.attributeInfo.XMP;
                    NATK += info.attributeInfo.NATK;
                    XATK += info.attributeInfo.XATK;
                    NMGK += info.attributeInfo.NMGK;
                    XMGK += info.attributeInfo.XMGK;
                    HOT += info.attributeInfo.HOT;
                    MOT += info.attributeInfo.MOT;
                    DEF += info.attributeInfo.DEF;
                    RGS += info.attributeInfo.RGS;
                    ASP += info.attributeInfo.ASP;
                    MSP += info.attributeInfo.MSP;
                    HIT += info.attributeInfo.HIT;
                    AVD += info.attributeInfo.AVD;
                    CRT += info.attributeInfo.CRT;
                } // end Plus

                public override string ToString() {
                    infoBuilder.Length = 0;
                    infoBuilder.Append("<size=22>");
                    infoBuilder.Append("名字：");
                    infoBuilder.Append(name);
                    infoBuilder.Append('\n');

                    infoBuilder.Append("角色：");
                    switch (roleType) {
                        case ConstConfig.ARCHER:
                            infoBuilder.Append("弓箭手");
                        break;

                        case ConstConfig.MAGICIAN:
                            infoBuilder.Append("魔法师");
                        break;

                        case ConstConfig.SWORDMAN:
                            infoBuilder.Append("狂战士");
                            break;

                        default:
                            infoBuilder.Append("全部");
                        break;
                    } // end switch
                    infoBuilder.Append('\n');
                    AppendValue("HP：", HP, " / ", XHP);
                    AppendValue("MP：", MP, " / ", XMP);
                    AppendValue("物理攻击：", NATK, " - ", XATK);
                    AppendValue("魔法攻击：", NMGK, " - ", XMGK);
                    AppendValue("hp恢复：", HOT, "/s");
                    AppendValue("mp恢复：", MOT, "/s");
                    AppendValue("物理防御：", DEF);
                    AppendValue("魔法防御：", RGS);
                    AppendValue("攻击速度：", ASP);
                    AppendValue("移动速度：", MSP);
                    AppendValue("命中率：", HIT);
                    AppendValue("闪避率：", AVD);
                    AppendValue("暴击率：", CRT);
                    infoBuilder.Append("</size>");
                    return infoBuilder.ToString();
                } // end ToString    

                private void AppendValue(string prefix, float value) {
                    infoBuilder.Append(prefix);
                    infoBuilder.Append(value);
                    infoBuilder.Append('\n');
                } // end AppendValue

                private void AppendValue(string prefix, float value, string suffix) {
                    infoBuilder.Append(prefix);
                    infoBuilder.Append(value);
                    infoBuilder.Append('\n');
                } // end AppendValue

                private void AppendValue(string prefix, float value1, string sign, float value2) {
                    infoBuilder.Append(prefix);
                    infoBuilder.Append(value1);
                    infoBuilder.Append(sign);
                    infoBuilder.Append(value2);
                    infoBuilder.Append('\n');
                } // end AppendValue
            } // end class CharacterAttribute
        } // end namespace Character
    } // end namespace ModelData
} // end namespace Solider 

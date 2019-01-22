/*******************************************************************
 * FileName: CharacterData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.Tools;
using Solider.Config.Interface;
using Solider.ModelData.Interface;
using System.Text;

namespace Solider {
    namespace ModelData {
        namespace Character {
            public class CharacterData : ICharacterDataAction, ICharacterData {
                private bool isLive;
                public bool IsLive {
                    get {
                        if (!isLive) return false;
                        // end if
                        if (HP > 0) return true;
                        // end if
                        isLive = false;
                        return isLive;
                    } // end get
                } // end IsLive
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

                public CharacterData(string name) {
                    this.name = name;
                    Revive();
                } // end CharacterData

                public CharacterData(string name, string roleType) {
                    this.name = name;
                    this.roleType = roleType;
                    Revive();
                } // end CharacterData

                public void Revive() {
                    HP = 1;
                    isLive = true;
                } // end Revive

                public void Init(IAttributeInfo initAttribute) {
                    if (null == initAttribute) return;
                    // end if
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
                    HIT = MathTool.Clamp(initAttribute.HIT, 0, 100);
                    AVD = MathTool.Clamp(initAttribute.AVD, 0, 60);
                    CRT = MathTool.Clamp(initAttribute.CRT, 0, 100);
                } // end Init

                public void Minus(IRealData data) {
                    if (null == data || false == IsLive) return;
                    // end if
                    HP = HP - data.HP;
                    MP = MP - data.MP;
                    if (data.HPR > 0) HP = HP - MathTool.Percent(XHP - HP, data.HPR);
                    // end if
                    if (data.MPR > 0) MP = MP - MathTool.Percent(XMP - MP, data.MPR);
                    // end if
                    if (data.XHR > 0) HP = HP - MathTool.Percent(XHP, data.XHR);
                    // end if
                    if (data.XMR > 0) MP = MP - MathTool.Percent(XMP, data.XMR);
                    // end if
                    HP = MathTool.Clamp(HP, 0, XHP);
                    MP = MathTool.Clamp(MP, 0, XMP);
                } // end  Minus

                public void Plus(IRealData data) {
                    if (null == data || false == IsLive || HP == XHP && MP == XMP) return;
                    // end if
                    HP = HP + data.HP;
                    MP = MP + data.MP;
                    if (data.HPR > 0) HP = HP + MathTool.Percent(XHP - HP, data.HPR);
                    // end if
                    if (data.MPR > 0) MP = MP + MathTool.Percent(XMP - MP, data.MPR);
                    // end if
                    if (data.XHR > 0) HP = HP + MathTool.Percent(XHP, data.XHR);
                    // end if
                    if (data.XMR > 0) MP = MP + MathTool.Percent(XMP, data.XMR);
                    // end if
                    HP = MathTool.Clamp(HP, 0, XHP);
                    MP = MathTool.Clamp(MP, 0, XMP);
                } // end Plus

                public void Plus(IEquipInfo info) {
                    if (null == info) return;
                    // end if
                    XHP = XHP + info.attributeInfo.XHP;
                    XMP = XMP + info.attributeInfo.XMP;
                    NATK = NATK + info.attributeInfo.NATK;
                    XATK = XATK + info.attributeInfo.XATK;
                    NMGK = NMGK + info.attributeInfo.NMGK;
                    XMGK = XMGK + info.attributeInfo.XMGK;
                    HOT = HOT + info.attributeInfo.HOT;
                    MOT = MOT + info.attributeInfo.MOT;
                    DEF = DEF + info.attributeInfo.DEF;
                    RGS = RGS + info.attributeInfo.RGS;
                    if (info.attributeInfo.ASP != 0) ASP = MathTool.Clamp(ASP * (info.attributeInfo.ASP + 100f) / 100f, 0.2f, 2f);
                    if (info.attributeInfo.MSP != 0) MSP = MathTool.Clamp(MSP * (info.attributeInfo.MSP + 100f) / 100f, 0.2f, 5f);
                    HIT = MathTool.Clamp(HIT + info.attributeInfo.HIT, 0, 100);
                    AVD = MathTool.Clamp(AVD + info.attributeInfo.AVD, 0, 60);
                    CRT = MathTool.Clamp(CRT + info.attributeInfo.CRT, 0, 100);
                } // end Plus

                public override string ToString() {
                    infoBuilder.Length = 0;
                    infoBuilder.Append("<size=22>");
                    infoBuilder.Append("名字：");
                    infoBuilder.Append(name);
                    infoBuilder.Append('\n');

                    if (false == string.IsNullOrEmpty(roleType)) {
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
                    } // end if
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
            } // end class CharacterData
        } // end namespace Character
    } // end namespace ModelData
} // end namespace Solider 

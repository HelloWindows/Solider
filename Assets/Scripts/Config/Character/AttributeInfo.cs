/*******************************************************************
 * FileName: AttributeInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Config.Interface;
using System.Text;

namespace Solider {
    namespace Config {
        namespace Character {
            public class AttributeInfo : IAttributeInfo {
                protected static readonly StringBuilder infoBuilder = new StringBuilder();
                public int XHP { get; protected set; }
                public int XMP { get; protected set; }
                public int NATK { get; protected set; }
                public int XATK { get; protected set; }
                public int NMGK { get; protected set; }
                public int XMGK { get; protected set; }
                public int HOT { get; protected set; }
                public int MOT { get; protected set; }
                public int DEF { get; protected set; }
                public int RGS { get; protected set; }
                public float ASP { get; protected set; }
                public float MSP { get; protected set; }
                public float HIT { get; protected set; }
                public float AVD { get; protected set; }
                public float CRT { get; protected set; }

                public AttributeInfo(JsonData data) {
                    XHP = JsonTool.TryGetJsonData_Int(data, "XHP");
                    XMP = JsonTool.TryGetJsonData_Int(data, "XMP");
                    HOT = JsonTool.TryGetJsonData_Int(data, "HOT");
                    NATK = JsonTool.TryGetJsonData_Int(data, "NATK");
                    XATK = JsonTool.TryGetJsonData_Int(data, "XATK");
                    NMGK = JsonTool.TryGetJsonData_Int(data, "NMGK");
                    XMGK = JsonTool.TryGetJsonData_Int(data, "XMGK");
                    DEF = JsonTool.TryGetJsonData_Int(data, "DEF");
                    RGS = JsonTool.TryGetJsonData_Int(data, "RGS");

                    ASP = JsonTool.TryGetJsonData_Float(data, "ASP");
                    MSP = JsonTool.TryGetJsonData_Float(data, "MSP");
                    HIT = JsonTool.TryGetJsonData_Float(data, "HIT");
                    AVD = JsonTool.TryGetJsonData_Float(data, "AVD");
                    CRT = JsonTool.TryGetJsonData_Float(data, "CRT");
                } // end AttributeInfo

                protected void AppendValue(string prefix, float value) {
                    if (0 == value) return;
                    // end if
                    infoBuilder.Append(prefix);
                    infoBuilder.Append(value);
                    infoBuilder.Append('\n');
                } // end AppendValue

                protected void AppendValue(string prefix, float value, string suffix) {
                    if (0 == value) return;
                    // end if
                    infoBuilder.Append(prefix);
                    infoBuilder.Append(value);
                    infoBuilder.Append(suffix);
                    infoBuilder.Append('\n');
                } // end AppendValue

                public override string ToString() {
                    infoBuilder.Length = 0;
                    AppendValue("MaxHp：", XHP);
                    AppendValue("MaxMp：", XMP);
                    AppendValue("每秒Hp：", HOT);
                    AppendValue("每秒Mp：", MOT);
                    if (NATK != 0 || XATK != 0) {
                        infoBuilder.Append("物理攻击：");
                        infoBuilder.Append(NATK);
                        infoBuilder.Append(" - ");
                        infoBuilder.Append(XATK);
                        infoBuilder.Append('\n');
                    } // end if
                    if (NMGK != 0 || XMGK != 0) {
                        infoBuilder.Append("魔法攻击：");
                        infoBuilder.Append(NMGK);
                        infoBuilder.Append(" - ");
                        infoBuilder.Append(XMGK);
                        infoBuilder.Append('\n');
                    } // end if
                    AppendValue("防御力：", DEF);
                    AppendValue("攻速：", ASP);
                    AppendValue("移速：", MSP);
                    AppendValue("命中率：", HIT);
                    AppendValue("闪避率：", AVD);
                    AppendValue("暴击率：", CRT);
                    return infoBuilder.ToString();
                } // end ToString
            } // end class AttributeInfo
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider 

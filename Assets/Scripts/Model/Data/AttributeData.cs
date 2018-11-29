/*******************************************************************
 * FileName: AttributeData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Text;

namespace Solider {
    namespace Model {
        namespace Data {
            public abstract class AttributeData {
                protected static readonly StringBuilder infoBuilder = new StringBuilder();
                /// <summary>
                /// 最大生命值
                /// </summary>
                public int XHP { get; protected set; } 
                /// <summary>
                /// 最大魔法值
                /// </summary>
                public int XMP { get; protected set; }
                /// <summary>
                /// 最小物理攻击
                /// </summary>
                public int NATK { get; protected set; }
                /// <summary>
                /// 最大物理攻击
                /// </summary>
                public int XATK { get; protected set; }
                /// <summary>
                /// 最小魔法攻击
                /// </summary>
                public int NMGK { get; protected set; }
                /// <summary>
                /// 最大魔法攻击
                /// </summary>
                public int XMGK { get; protected set; }
                /// <summary>
                /// 生命恢复速度 ../s
                /// </summary>
                public int HOT { get; protected set; }
                /// <summary>
                /// 魔法恢复速度 ../s
                /// </summary>
                public int MOT { get; protected set; }
                /// <summary>
                /// 物理防御
                /// </summary>
                public int DEF { get; protected set; }
                /// <summary>
                /// 魔法防御
                /// </summary>
                public int RGS { get; protected set; }
                /// <summary>
                /// 攻击速度
                /// </summary>
                public float ASP { get; protected set; }
                /// <summary>
                /// 移动速度
                /// </summary>
                public float MSP { get; protected set; }
                /// <summary>
                /// 命中率
                /// </summary>
                public float HIT { get; protected set; }
                /// <summary>
                /// 闪避率
                /// </summary>
                public float AVD { get; protected set; }
                /// <summary>
                /// 暴击率
                /// </summary>
                public float CRT { get; protected set; }

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
            } // end class AttributeData
        } // end namespace Data
    } // end namespace Model
} // end namespace Solider 

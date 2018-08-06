/*******************************************************************
 * FileName: AttributeData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Solider {
    namespace Model {
        namespace Data {
            public abstract class AttributeData {
                /// <summary>
                /// id
                /// </summary>
                public int id { get; protected set; }
                /// <summary>
                /// 名字
                /// </summary>
                public string name { get; protected set; }
                /// <summary>
                /// 生命值
                /// </summary>
                public int HP { get; protected set; }
                /// <summary>
                /// 最大生命值
                /// </summary>
                public int XHP { get; protected set; } 
                /// <summary>
                /// 魔法值
                /// </summary>
                public int MP { get; protected set; }
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
            } // end class AttributeData
        } // end namespace Data
    } // end namespace Model
} // end namespace Solider 

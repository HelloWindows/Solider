/*******************************************************************
 * FileName: IAttributeData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface IAttributeData {
                /// <summary>
                /// 最大生命值
                /// </summary>
                int XHP { get; }
                /// <summary>
                /// 最大魔法值
                /// </summary>
                int XMP { get; }
                /// <summary>
                /// 最小物理攻击
                /// </summary>
                int NATK { get; }
                /// <summary>
                /// 最大物理攻击
                /// </summary>
                int XATK { get; }
                /// <summary>
                /// 最小魔法攻击
                /// </summary>
                int NMGK { get; }
                /// <summary>
                /// 最大魔法攻击
                /// </summary>
                int XMGK { get; }
                /// <summary>
                /// 生命恢复速度 ../s
                /// </summary>
                int HOT { get; }
                /// <summary>
                /// 魔法恢复速度 ../s
                /// </summary>
                int MOT { get; }
                /// <summary>
                /// 物理防御
                /// </summary>
                int DEF { get; }
                /// <summary>
                /// 魔法防御
                /// </summary>
                int RGS { get; }
                /// <summary>
                /// 攻击速度
                /// </summary>
                float ASP { get; }
                /// <summary>
                /// 移动速度
                /// </summary>
                float MSP { get; }
                /// <summary>
                /// 命中率
                /// </summary>
                float HIT { get; }
                /// <summary>
                /// 闪避率
                /// </summary>
                float AVD { get; }
                /// <summary>
                /// 暴击率
                /// </summary>
                float CRT { get; }
            } // end interface IAttributeData
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider 
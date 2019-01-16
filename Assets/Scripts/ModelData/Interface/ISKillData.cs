/*******************************************************************
 * FileName: ISKillData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface ISKillData {
                /// <summary>
                ///  物理攻击
                /// </summary>
                int ATK { get; }
                /// <summary>
                /// 魔法攻击
                /// </summary>
                int MGK { get; }
                /// <summary>
                /// 物理攻击百分比
                /// </summary>
                float ATKR { get; }
                /// <summary>
                /// 魔法攻击百分比
                /// </summary>
                float MGKR { get; }
                /// <summary>
                /// 忽略物理防御百分比
                /// </summary>
                float DEFR { get; }
                /// <summary>
                /// 忽略魔法防御百分比
                /// </summary>
                float RGSR { get; } 
            } // end class ISKillData
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider

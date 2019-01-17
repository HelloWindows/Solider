/*******************************************************************
 * FileName: IDamageData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface IDamageData {
                /// <summary>
                /// 攻击者 id
                /// </summary>
                string hashID { get; }
                /// <summary>
                ///  物理攻击
                /// </summary>
                int ATK { get; }
                /// <summary>
                /// 魔法攻击
                /// </summary>
                int MGK { get; }
                /// <summary>
                /// 忽略物理防御百分比
                /// </summary>
                float DEFR { get; }
                /// <summary>
                /// 忽略魔法防御百分比
                /// </summary>
                float RGSR { get; }
                /// <summary>
                /// 命中率
                /// </summary>
                float HIT { get; }         
                /// <summary>
                /// 是否暴击
                /// </summary>
                bool iscrit { get; }
            } // end interface IDamageData
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider 

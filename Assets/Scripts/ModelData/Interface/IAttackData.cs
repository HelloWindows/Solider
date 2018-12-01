/*******************************************************************
 * FileName: IAttackData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface IAttackData {
                /// <summary>
                /// 攻击者 id
                /// </summary>
                string id { get; }
                /// <summary>
                /// 物理伤害
                /// </summary>
                int ATK { get; }
                /// <summary>
                /// 魔法伤害
                /// </summary>
                int MGK { get; }
                /// <summary>
                /// 命中率
                /// </summary>
                float HIT { get; }         
                /// <summary>
                /// 是否命中
                /// </summary>
                bool ismiss { get; }
                /// <summary>
                /// 是否暴击
                /// </summary>
                bool iscrit { get; }
                /// <summary>
                /// 计算普通物理攻击
                /// </summary>
                /// <param name="data"> 被攻击者 </param>
                /// <returns> 攻击结果 </returns>
                IRealData AttackTo(IAttributeData data);
            } // end interface IAttackData
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider 

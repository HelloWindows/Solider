/*******************************************************************
 * FileName: AttributeData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.ModelData.Data;

namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface ICharacterAttribute :IAttributeData {
                /// <summary>
                /// 名字
                /// </summary>
                string name { get; }
                /// <summary>
                /// 角色类型
                /// </summary>
                string roleType { get; }
                /// <summary>
                /// 当前生命值
                /// </summary>
                int HP { get; }
                /// <summary>
                /// 当前魔法值
                /// </summary>
                int MP { get; }
                /// <summary>
                /// 受到攻击的数据
                /// </summary>
                /// <param name="data"> 攻击数据 </param>
                void Minus(AttackData data);

            } // end class ICharacterAttribute
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider 

/*******************************************************************
 * FileName: ICharacterDataAction.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;

namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface ICharacterDataAction : ICharacterData {
                /// <summary>
                /// 初始化角色数据
                /// </summary>
                /// <param name="initAttribute"> 角色初始信息 </param>
                void Init(IAttributeInfo initAttribute);
                /// <summary>
                /// 受到攻击的数据
                /// </summary>
                /// <param name="data"> 攻击数据 </param>
                void Minus(IRealData data);
                /// <summary>
                /// 获得治疗的数据
                /// </summary>
                /// <param name="data"> 治疗数据 </param>
                void Plus(IRealData data);
                /// <summary>
                /// 穿戴装备的数据
                /// </summary>
                /// <param name="info"> 装备信息 </param>
                void Plus(IEquipInfo info);
            } // end class ICharacterDataAction
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider 

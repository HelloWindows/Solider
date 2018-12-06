/*******************************************************************
 * FileName: ICharacterData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace ModelData {
        namespace Interface {
            public interface ICharacterData {
                /// <summary>
                /// 名字
                /// </summary>
                string name { get; }
                /// <summary>
                /// 角色类型
                /// </summary>
                string roleType { get; }
                /// <summary>
                /// 是否存活
                /// </summary>
                /// <returns> 是否存活 </returns>
                bool IsLive { get; }
                /// <summary>
                /// 当前生命值
                /// </summary>
                int HP { get; }
                /// <summary>
                /// 当前魔法值
                /// </summary>
                int MP { get; }
            } // end interface ICharacterData
        } // end namespace Interface
    } // end namespace ModelData
} // end namespace Solider
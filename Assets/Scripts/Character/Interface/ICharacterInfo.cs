/*******************************************************************
 * FileName: ICharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using Solider.ModelData.Character;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterInfo : IDisposable{
                /// <summary>
                /// 是否存活
                /// </summary>
                /// <returns> 是否存活 </returns>
                bool IsLive { get; }
                /// <summary>
                /// 自愈
                /// </summary>
                void Update(float deltaTime);
                /// <summary>
                /// 获取角色属性数据
                /// </summary>
                /// <returns> 属性数据 </returns>
                CharacterAttribute GetAttributeData();
                /// <summary>
                /// 复活
                /// </summary>
                void Revive();
            } // end interface ICharacterInfo 
        } // end namespace Interface
    } // end namespace Character 
} // end namespace Solider
/*******************************************************************
 * FileName: ICharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using Solider.ModelData.Interface;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterInfo {
                /// <summary>
                /// 获取角色数据
                /// </summary>
                /// <returns> 角色数据 </returns>
                ICharacterData GetCharacterData();
                /// <summary>
                /// 复活
                /// </summary>
                void Revive();
            } // end interface ICharacterInfo 
        } // end namespace Interface
    } // end namespace Character 
} // end namespace Solider
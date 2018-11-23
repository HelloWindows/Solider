/*******************************************************************
 * FileName: ICharacterFSMSystem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterFSMSystem {
                /// <summary>
                /// 运行
                /// </summary>
                /// <param name="deltaTime"> 时间变量 </param>
                void Update(float deltaTime);
            } // end interface ICharacterFSMSystem 
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider
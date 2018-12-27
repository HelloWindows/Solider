/*******************************************************************
 * FileName: ICharacterFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterFSM {
                /// <summary>
                /// 当前状态层
                /// </summary>
                int currentLayer { get; }
                /// <summary>
                /// 却换状态
                /// </summary>
                /// <param name="state"> 状态 </param>
                void PerformTransition(ICharacterState state);
                /// <summary>
                /// 却换状态
                /// </summary>
                /// <param name="state"> 名字 </param>
                void PerformTransition(string name);
            } // end class ICharacterFSM
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

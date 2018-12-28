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
                /// 切换状态
                /// </summary>
                /// <param name="state"> 状态 </param>
                void PerformTransition(ICharacterState state);
                /// <summary>
                /// 切换状态
                /// </summary>
                /// <param name="state"> 名字 </param>
                void PerformTransition(string name);
                /// <summary>
                /// 切换状态基于层级关系
                /// </summary>
                /// <param name="state"> 切换成功返回 true </param>
                /// <returns></returns>
                bool TransitionOnLayer(ICharacterState state);
            } // end class ICharacterFSM
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

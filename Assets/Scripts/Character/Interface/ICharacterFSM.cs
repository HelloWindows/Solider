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
                /// 却换状态
                /// </summary>
                /// <param name="state"> 状态 </param>
                void PerformTransition(ICharacterFSMState state);
                /// <summary>
                /// 切换上一个状态
                /// </summary>
                void TransitionPrev();
            } // end interface ICharacterFSM 
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider
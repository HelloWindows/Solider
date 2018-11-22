/*******************************************************************
 * FileName: IFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Framework {
    namespace FSM {
        namespace Interface {
            public interface IFSM {
                /// <summary>
                /// 却换状态
                /// </summary>
                /// <param name="state"> 状态 </param>
                void PerformTransition(IFSMState state);
                /// <summary>
                /// 切换上一个状态
                /// </summary>
                void TransitionPrev();
            } // end class IFSM
        } // end namespace Interface
    } // end namespace FSM
} // end namespace Framework 

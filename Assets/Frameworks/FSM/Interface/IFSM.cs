﻿/*******************************************************************
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
                /// <param name="name"> 状态名 </param>
                void PerformTransition(string name);
            } // end class IFSM
        } // end namespace Interface
    } // end namespace FSM
} // end namespace Framework 
/*******************************************************************
 * FileName: IFSMSystem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework {
    namespace FSM {
        namespace Interface {
            public interface IFSMSystem {
                /// <summary>
                /// 添加状态
                /// </summary>
                /// <param name="state"> 状态对象 </param>
                void AddState(IFSMState state);
                /// <summary>
                /// 移除状态
                /// </summary>
                /// <param name="name"> 状态名 </param>
                void RemoveState(string name);
                /// <summary>
                /// 却换状态
                /// </summary>
                /// <param name="name"> 状态名 </param>
                void PerformTransition(string name);
            } // end class IFSMSystem 
        } // end namespace Interface 
    } // end namespace FSM
} // end namespace Custom
/*******************************************************************
 * FileName: IFSMSystem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Framework {
    namespace FSM {
        namespace Interface {
            public interface IFSMSystem : IFSM {
                /// <summary>
                /// 运行
                /// </summary>
                /// <param name="deltaTime"> 时间变量 </param>
                void Update(float deltaTime);
                /// <summary>
                /// 添加状态
                /// </summary>
                /// <param name="state"> 状态 </param>
                void AddState(IFSMState state);
                /// <summary>
                /// 移除状态
                /// </summary>
                /// <param name="state"> 状态 </param>
                void RemoveState(IFSMState state);
            } // end class IFSMSystem 
        } // end namespace Interface 
    } // end namespace FSM
} // end namespace Custom
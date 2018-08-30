/*******************************************************************
 * FileName: IFSMSystem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
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
                /// 运行
                /// </summary>
                /// <param name="deltaTime"> 时间变量 </param>
                void Update(float deltaTime);
            } // end class IFSMSystem 
        } // end namespace Interface 
    } // end namespace FSM
} // end namespace Custom
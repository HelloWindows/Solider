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
            } // end class IFSMSystem 
        } // end namespace Interface 
    } // end namespace FSM
} // end namespace Custom
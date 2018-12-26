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
                void Update();
            } // end class IFSMSystem 
        } // end namespace Interface 
    } // end namespace FSM
} // end namespace Custom
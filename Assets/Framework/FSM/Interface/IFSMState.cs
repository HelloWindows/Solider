/*******************************************************************
 * FileName: IFSMState.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Framework {
    namespace FSM {
        namespace Interface {
            public interface IFSMState {
                string id { get; }
                void DoBeforeEntering();
                void DoBeforeLeaving();
                void Reason(float deltaTime);
                void Act(float deltaTime);
            } // end class IFSMState 
        } // end namespace Interface
    } // end namespace FSM
} // end namespace Solider
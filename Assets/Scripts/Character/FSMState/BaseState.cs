/*******************************************************************
 * FileName: BaseState.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;

namespace Solider {
    namespace Character {
        namespace FSMState {
            public class BaseState : IFSMState {
                public string name { get; private set; }

                public BaseState(string name) {
                    this.name = name;
                } // end BaseState

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeEntering() {
                } // end DoBeforeEntering

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                public void Reason(float deltaTime) {
                } // end Reason
            } // end class 
        } // end namespace FSMState
    } // end namespace Character 
} // end namespace Solider
/*******************************************************************
 * FileName: FSMSystem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.FSM.Interface;
using Framework.Tools;

namespace Framework {
    namespace FSM {
        public class FSMSystem : IFSMSystem {
            private IFSMState previousState;
            private IFSMState currentState;

            public FSMSystem() {
            } // end FSMSystem

            public void Update(float deltaTime) {
                if (null == currentState) return;
                // end if
                currentState.Reason(deltaTime);
                currentState.Act(deltaTime);
            } // end Update

            public void TransitionPrev() {
                PerformTransition(previousState);
            } // end TransitionPrev

            public void PerformTransition(IFSMState state) {
                if (null != currentState) currentState.DoBeforeLeaving();
                // end if
                previousState = currentState;
                currentState = state;
                if (null != currentState) currentState.DoBeforeEntering();
                // end if
            } // end PerformTransition

            public void PerformTransition(string stateID) {
                IFSMState state = Configs.fsmStateConfig.GetCharacterState(stateID);
                if (null == state) {
                    DebugTool.ThrowException("FSMSystem PerformTransition is don't exsit!!！ stateID: " + stateID);
                    return;
                } // end if
                PerformTransition(state);
            } // end PerformTransition
        } // end class FSMSystem 
    } // end namespace FSM 
} // end namespace Framework
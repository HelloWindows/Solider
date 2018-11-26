/*******************************************************************
 * FileName: FSMSystem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using System.Collections.Generic;

namespace Framework {
    namespace FSM {
        public class FSMSystem : IFSMSystem {
            private IFSMState previousState;
            private IFSMState currentState;
            private Dictionary<string, IFSMState> stateMap;

            public FSMSystem() {
                stateMap = new Dictionary<string, IFSMState>();
            } // end FSMSystem

            public void PerformTransition(IFSMState state) {
                if (null != currentState) currentState.DoBeforeLeaving();
                // end if
                previousState = currentState;
                currentState = state;
                if (null != currentState) currentState.DoBeforeEntering();
                // end if
            } // end PerformTransition

            public void Update(float deltaTime) {
                if (null == currentState) return;
                // end if
                currentState.Reason(deltaTime);
                currentState.Act(deltaTime);
            } // end Update

            public void TransitionPrev() {
                PerformTransition(previousState);
            } // end TransitionPrev

            public void AddState(IFSMState state) {
            } // end AddState

            public void RemoveState(IFSMState state) {
            } // end RemoveState
        } // end class FSMSystem 
    } // end namespace FSM 
} // end namespace Framework
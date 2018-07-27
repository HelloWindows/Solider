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
        public class FSMSystem : IFSM, IFSMSystem {
            private IFSMState currentState;
            private Dictionary<string, IFSMState> stateMap;

            public FSMSystem() {
                stateMap = new Dictionary<string, IFSMState>();
            } // end FSMSystem

            public void AddState(IFSMState state) {
                if (stateMap.ContainsKey(state.name)) {
#if __MY_DEBUG__
                    throw new System.Exception("FSMSystem AddState repetition!");
#else
                    return;
#endif
                } // end if
                if (null == currentState) {
                    currentState = state;
                    currentState.DoBeforeEntering();
                } // end if
                stateMap[state.name] = state;
            } // end AddState

            public void RemoveState(string name) {
                if (!stateMap.ContainsKey(name)) {
#if __MY_DEBUG__
                    throw new System.Exception("FSMSystem RemoveState state don't exist! name: " + name);
#else
                    return;
#endif
                } // end if
                stateMap[name].DoRemove();
                stateMap.Remove(name);
            } // end RemoveState

            public void PerformTransition(string name) {
                if (!stateMap.ContainsKey(name)) {
#if __MY_DEBUG__
                    throw new System.Exception("FSMSystem PerformTransition state don't exist! name: " + name);
#else
                    return;
#endif
                } // end if
                if (null != currentState) currentState.DoBeforeLeaving();
                // end if
                currentState = stateMap[name];
                if (null != currentState) currentState.DoBeforeEntering();
                // end if
            } // end PerformTransition

            public void Update(float deltaTime) {
                if (null == currentState) return;
                // end if
                currentState.Reason(deltaTime);
                currentState.Act(deltaTime);
            } // end Update
        } // end class FSMSystem 
    } // end namespace FSM 
} // end namespace Framework
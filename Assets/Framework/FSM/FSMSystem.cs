﻿/*******************************************************************
 * FileName: FSMSystem.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using System.Collections.Generic;

namespace Framework {
    namespace FSM {
        public class FSMSystem : IFSM, IFSMSystem {
            private string prevStateName;
            private IFSMState currentState;
            private Dictionary<string, IFSMState> stateMap;

            public FSMSystem() {
                stateMap = new Dictionary<string, IFSMState>();
            } // end FSMSystem

            public void AddState(IFSMState state) {
                if (stateMap.ContainsKey(state.name)) {
                    DebugTool.ThrowException("FSMSystem AddState repetition!");
                    return;
                } // end if
                if (null == currentState) {
                    currentState = state;
                    currentState.DoBeforeEntering();
                    prevStateName = state.name;
                } // end if
                stateMap[state.name] = state;
            } // end AddState

            public void RemoveState(string name) {
                if (!stateMap.ContainsKey(name)) {
                    DebugTool.ThrowException("FSMSystem RemoveState state don't exist! name: " + name);
                    return;
                } // end if
                stateMap[name].DoRemove();
                stateMap.Remove(name);
            } // end RemoveState

            public void PerformTransition(string name) {
                if (!stateMap.ContainsKey(name)) {
                    DebugTool.ThrowException("FSMSystem PerformTransition state don't exist! name: " + name);
                    return;
                } // end if
                if (null != currentState) currentState.DoBeforeLeaving();
                // end if
                prevStateName = currentState.name;
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

            public void TransitionPrev() {
                PerformTransition(prevStateName);
            } // end TransitionPrev
        } // end class FSMSystem 
    } // end namespace FSM 
} // end namespace Framework
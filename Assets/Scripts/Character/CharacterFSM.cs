/*******************************************************************
 * FileName: CharacterFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Solider.Character.FSM;
using Solider.Character.Interface;
using System;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        public class CharacterFSM : ICharacterFSM {
            public int currentLayer {
                get { return null == currentState ? Convert.ToInt32(StateLayer.Default) : currentState.layer; }
            } // end currentLayer

            private ICharacterState currentState;
            private Dictionary<string, ICharacterState> stateDict;

            public CharacterFSM() {
            } // end CharacterFSM

            public void Update() {
                if (null == currentState) return;
                // end if
                currentState.Reason();
                currentState.Act();
            } // end Update

            public void PerformTransition(ICharacterState state) {
                if (null != currentState) currentState.DoBeforeLeaving();
                // end if
                currentState = state;
                if (null != currentState) currentState.DoBeforeEntering();
            } // end PerformTransition

            public void PerformTransition(string name) {
                if (null == stateDict) {
                    DebugTool.ThrowException(GetType() + "stateDict is null");
                    return;
                } // end if
                if (stateDict.ContainsKey(name)) {
                    PerformTransition(stateDict[name]);
                } else {
                    DebugTool.ThrowException(GetType() + "stateDict is don't exsit " + name);
                    return;
                }// end if
            } // end PerformTransitions

            protected void AddState(ICharacterState state) {
                if (null == stateDict) stateDict = new Dictionary<string, ICharacterState>();
                // end if
                if (null == state) {
                    DebugTool.ThrowException(GetType() + "AddState state is null!");
                    return;
                } // end if
                if (stateDict.ContainsKey(state.id)) {
                    DebugTool.ThrowException("SwordmanFSM AddState have repeat state!");
                    return;
                } // end if
                stateDict[state.id] = state;
            } // end PushBaseState
        } // end class CharacterFSM
    } // end namespace Character
} // end namespace Solider 

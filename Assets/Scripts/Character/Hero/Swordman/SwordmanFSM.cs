/*******************************************************************
 * FileName: SwordmanFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM;
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Interface;
using System.Collections.Generic;
using System;

namespace Solider {
    namespace Character {
        namespace Swordman {
            public class SwordmanFSM : IFSMSystem {
                private IFSMSystem fsmSystem;
                private Dictionary<string, IFSMState> baseStateDict;

                public SwordmanFSM(ICharacter character) {
                    fsmSystem = new FSMSystem();
                    baseStateDict = new Dictionary<string, IFSMState>();
                    PushBaseState(new SwordmanDie(character));
                    PushBaseState(new SwordmanIdle(character));
                    PushBaseState(new SwordmanHurt(character));
                    PushBaseState(new SwordmanWait(character));
                } // end SwordmanFSM

                public void PerformTransition(IFSMState state) {
                    if (baseStateDict.ContainsKey(state.name)) {
                        fsmSystem.PerformTransition(baseStateDict[state.name]);
                        return;
                    } // end if
                    fsmSystem.PerformTransition(state);
                } // end PerformTransition

                public void TransitionPrev() {
                    fsmSystem.TransitionPrev();
                } // end TransitionPrev

                public void Update(float deltaTime) {
                    fsmSystem.Update(deltaTime);
                } // end Update

                private void PushBaseState(IFSMState state) {
                    if (baseStateDict.ContainsKey(state.name)) {
                        DebugTool.ThrowException("SwordmanFSM PushBaseState have repeat state!");
                        return;
                    } // end if
                    baseStateDict[state.name] = state;
                } // end PushBaseState

                public void AddState(IFSMState state)
                {
                    throw new NotImplementedException();
                }

                public void RemoveState(IFSMState state)
                {
                    throw new NotImplementedException();
                }
            } // end class SwordmanFSM
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Solider 

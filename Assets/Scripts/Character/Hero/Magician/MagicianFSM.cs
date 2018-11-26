/*******************************************************************
 * FileName: MagicianFSM.cs
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
        namespace Magician {
            public class MagicianFSM : IFSMSystem {
                private IFSMSystem fsmSystem;
                private Dictionary<string, IFSMState> baseStateDict;

                public MagicianFSM(ICharacter character) {
                    fsmSystem = new FSMSystem();
                    baseStateDict = new Dictionary<string, IFSMState>();
                    PushBaseState(new MagicianDie(character));
                    PushBaseState(new MagicianIdle(character));
                    PushBaseState(new MagicianHurt(character));
                    PushBaseState(new MagicianWait(character));
                } // end MagicianFSM

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
            } // end class MagicianFSM 
        } // end namespace Magician
    } // end namespace Character
} // end namespace Solider
/*******************************************************************
 * FileName: ArcherFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM;
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Interface;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        namespace Archer {
            public class ArcherFSM : IFSMSystem {
                private IFSMSystem fsmSystem;
                private Dictionary<string, IFSMState> baseStateDict;

                public ArcherFSM(ICharacter character) {
                    fsmSystem = new FSMSystem();
                    baseStateDict = new Dictionary<string, IFSMState>();
                    PushBaseState(new ArcherDie(character));
                    PushBaseState(new ArcherIdle(character));
                    PushBaseState(new ArcherHurt(character));
                    PushBaseState(new ArcherWait(character));
                } // end ArcherFSM

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
            } // end class Archer
        } // end namespace Archer
    } // end namespace Character
} // end namespace Solider 

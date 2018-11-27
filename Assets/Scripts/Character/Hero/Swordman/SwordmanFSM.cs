/*******************************************************************
 * FileName: SwordmanFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM;
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Hore;
using Solider.Character.Interface;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        namespace Swordman {
            public class SwordmanFSM : IFSMSystem {
                private IFSMSystem fsmSystem;
                private Dictionary<string, IFSMState> baseStateDict;

                public SwordmanFSM(ICharacter character) {
                    fsmSystem = new FSMSystem();
                    baseStateDict = new Dictionary<string, IFSMState>();
                    PushBaseState(new HoreWalk(character));
                    PushBaseState(new HoreIdle(character));
                    PushBaseState(new HoreRun(character));
                    PushBaseState(new HoreWait(character));
                    PushBaseState(new SwordmanAttack1(character));
                    PushBaseState(new HoreDie(character, "swordman_die"));
                    PushBaseState(new HoreHurt(character, "swordman_hurt"));
                } // end SwordmanFSM

                public void PerformTransition(string stateID) {
                    if (baseStateDict.ContainsKey(stateID)) {
                        fsmSystem.PerformTransition(baseStateDict[stateID]);
                        return;
                    } // end if
                    fsmSystem.PerformTransition(stateID);
                } // end PerformTransition

                public void PerformTransition(IFSMState state) {
                    fsmSystem.PerformTransition(state);
                } // end PerformTransition

                public void TransitionPrev() {
                    fsmSystem.TransitionPrev();
                } // end TransitionPrev

                public void Update(float deltaTime) {
                    fsmSystem.Update(deltaTime);
                } // end Update

                private void PushBaseState(IFSMState state) {
                    if (baseStateDict.ContainsKey(state.id)) {
                        DebugTool.ThrowException("SwordmanFSM PushBaseState have repeat state!!! stateID:" + state.id);
                        return;
                    } // end if
                    baseStateDict[state.id] = state;
                } // end PushBaseState
            } // end class SwordmanFSM
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Solider 

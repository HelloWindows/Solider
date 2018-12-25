/*******************************************************************
 * FileName: MagicianFSM.cs
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
        namespace Hero {
            public class MagicianFSM : IFSMSystem {
                private IFSMSystem fsmSystem;
                private Dictionary<string, IFSMState> baseStateDict;

                public MagicianFSM(IMainCharacter character) {
                    fsmSystem = new FSMSystem();
                    baseStateDict = new Dictionary<string, IFSMState>();
                    PushBaseState(new HoreWait(character));
                    PushBaseState(new HoreWalk(character));
                    PushBaseState(new HoreIdle(character));
                    PushBaseState(new HoreRun(character));
                    PushBaseState(new MagicianAttack1(character));
                    PushBaseState(new HoreDie(character));
                    PushBaseState(new HoreHurt(character));
                } // end MagicianFSM

                public void PerformTransition(IFSMState state) {
                    if (baseStateDict.ContainsKey(state.id)) {
                        fsmSystem.PerformTransition(baseStateDict[state.id]);
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
                    if (baseStateDict.ContainsKey(state.id)) {
                        DebugTool.ThrowException("SwordmanFSM PushBaseState have repeat state!");
                        return;
                    } // end if
                    baseStateDict[state.id] = state;
                } // end PushBaseState

                public void PerformTransition(string stateID) {
                } // end PerformTransition
            } // end class MagicianFSM 
        } // end namespace Hero
    } // end namespace Character
} // end namespace Solider
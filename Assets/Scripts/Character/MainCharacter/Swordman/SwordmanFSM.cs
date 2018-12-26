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

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class SwordmanFSM : IFSMSystem {
                private IFSMSystem fsmSystem;
                private Dictionary<string, IFSMState> baseStateDict;

                public SwordmanFSM(IMainCharacter character) {
                    fsmSystem = new FSMSystem();
                    baseStateDict = new Dictionary<string, IFSMState>();
                    PushBaseState(new MainCharacterWalk(character));
                    PushBaseState(new MainCharacterIdle(character));
                    PushBaseState(new MainCharacterRun(character));
                    PushBaseState(new MainCharacterWait(character));
                    PushBaseState(new SwordmanAttack1(character));
                    PushBaseState(new MainCharacterDie(character));
                    PushBaseState(new MainCharacterHurt(character));
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

                public void Update() {
                    fsmSystem.Update();
                } // end Update

                private void PushBaseState(IFSMState state) {
                    if (baseStateDict.ContainsKey(state.id)) {
                        DebugTool.ThrowException("SwordmanFSM PushBaseState have repeat state!!! stateID:" + state.id);
                        return;
                    } // end if
                    baseStateDict[state.id] = state;
                } // end PushBaseState
            } // end class SwordmanFSM
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

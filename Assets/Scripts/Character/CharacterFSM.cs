/*******************************************************************
 * FileName: CharacterFSM.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        public class CharacterFSM : ICharacterFSMSystem {
            private ICharacter character;
            private ICharacterFSMState previousState;
            private ICharacterFSMState currentState;

            public CharacterFSM(ICharacter character) {
                this.character = character;
            } // end CharacterFSM

            public void PerformTransition(ICharacterFSMState state) {
                if (null != currentState) currentState.DoBeforeLeaving(character);
                // end if
                previousState = currentState;
                currentState = state;
                if (null != currentState) currentState.DoBeforeEntering(character);
                // end if
            } // end PerformTransition

            public void Update(float deltaTime) {
                if (null == currentState) return;
                // end if
                currentState.Reason(character, deltaTime);
                currentState.Act(character, deltaTime);
            } // end Update

            public void TransitionPrev() {
                PerformTransition(previousState);
            } // end TransitionPrev
        } // end class CharacterFSM 
    } // end namespace Character
} // end namespace Solider
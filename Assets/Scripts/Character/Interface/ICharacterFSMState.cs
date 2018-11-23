/*******************************************************************
 * FileName: ICharacterFSMState.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterFSMState {
                string id { get; }
                void DoBeforeEntering(ICharacter character);
                void DoBeforeLeaving(ICharacter character);
                void Reason(ICharacter character,float deltaTime);
                void Act(ICharacter character, float deltaTime);
            } // end interface ICharacterFSMState 
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider
/*******************************************************************
 * FileName: ICharacterFSMState.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterFSMState {
                string id { get; }
                IFSMState CreateInstance(ICharacter character);
            } // end interface ICharacterFSMState
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

/*******************************************************************
 * FileName: ICharacterFSMState.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Custom {
	public interface ICharacterFSMState : IFSMState {
        IFSMState CreateInstance(ICharacter character);
    } // end class ICharacterFSMState
} // end namespace Custom 

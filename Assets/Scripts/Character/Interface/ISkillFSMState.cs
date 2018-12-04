/*******************************************************************
 * FileName: ISkillFSMState.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Config.Interface;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ISkillFSMState {
                string id { get; }
                IFSMState CreateInstance(ICharacter character, ISkillInfo skillInfo);
            } // end interface ISkillFSMState
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

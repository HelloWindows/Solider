/*******************************************************************
 * FileName: ICharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Audio;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacter {
                IFSM fsm { get; }
                IAvatar avatar { get; }
                IAudioSound audio { get; }
                ICharacterMove move { get; }
            } // end interface ICharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

/*******************************************************************
 * FileName: IMainCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface IMainCharacter : ICharacter {
                IIputInfo input { get; }
                ICharacterSkill skill { get; }
                IMainCharacterSurface surface { get; }
            } // end interface IMainCharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 


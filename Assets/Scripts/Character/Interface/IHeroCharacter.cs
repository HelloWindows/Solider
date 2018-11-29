/*******************************************************************
 * FileName: IHeroCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface IHeroCharacter : ICharacter {
                IIputInfo input { get; }
                IHeroCharacterSurface surface { get; }
            } // end interface IHeroCharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 


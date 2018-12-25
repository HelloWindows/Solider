﻿/*******************************************************************
 * FileName: IMainCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.Model.Interface;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface IMainCharacter : ICharacter {
                IPackInfo pack { get; }
                IIputInfo input { get; }
                ICharacterSkill skill { get; }
                IMainCharacterSurface surface { get; }
            } // end interface IMainCharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 


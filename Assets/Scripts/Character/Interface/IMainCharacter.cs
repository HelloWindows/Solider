/*******************************************************************
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
            public interface IMainCharacter : ISkillCharacter {
                IPackInfo pack { get; }
                IInputCenter input { get; }
                IMainCharacterSurface mainSurface { get; }
            } // end interface IMainCharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 


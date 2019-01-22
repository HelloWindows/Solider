/*******************************************************************
 * FileName: ISkillCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ISkillCharacter : ICharacter {
                ICharacterSkill skill { get; }
            } // end interface ISkillCharacter
        } // end namespace Interface 
    } // end namespace Character 
} // end namespace Solider 
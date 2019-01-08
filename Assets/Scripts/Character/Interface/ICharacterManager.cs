/*******************************************************************
 * FileName: ICharacterManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterManager {
                ICharacterFactory factory { get; }
            } // end class ICharacterManager 
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider
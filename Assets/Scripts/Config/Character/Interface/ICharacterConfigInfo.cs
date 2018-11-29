/*******************************************************************
 * FileName: ICharacterConfigInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface ICharacterConfigInfo {
                IAttributeInfo attribute { get; }
                ICharacterSoundInfo soundInfo { get; }
            } // end interface ICharacterConfigInfo 
        } // end namespace Interface
    } // end namespace Config
} // end namespace Solider
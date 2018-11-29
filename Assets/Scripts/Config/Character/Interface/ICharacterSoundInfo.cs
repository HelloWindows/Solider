/*******************************************************************
 * FileName: ICharacterSoundInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface ICharacterSoundInfo {
                bool TryGetSoundPath(string name, out string value);
            } // end interface ICharacterSoundInfo
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider
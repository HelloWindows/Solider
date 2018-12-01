/*******************************************************************
 * FileName: ICharacterConfigMgr.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface ICharacterConfigMgr {
                ICharacterConfig GetCharacterConfig(string id);
            } // end interface ICharacterConfigMgr 
        } // end namespace Interface
    } // end namespace Config
} // end namespace Solider
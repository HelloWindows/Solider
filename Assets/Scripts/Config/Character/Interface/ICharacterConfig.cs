/*******************************************************************
 * FileName: ICharacterConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface ICharacterConfig {
                string id { get; }
                string name { get; }
                int npc_type { get; }
                IAttributeInfo initAttribute { get; }
                bool TryGetSoundPath(string name, out string path);
                bool TryGetEffectPath(string name, out string path);
            } // end interface ICharacterConfig 
        } // end namespace Interface
    } // end namespace Config
} // end namespace Solider
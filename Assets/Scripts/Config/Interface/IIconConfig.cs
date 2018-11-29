/*******************************************************************
 * FileName: IIconConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface IIconConfig {
                bool TryGetSkillInfo(string id, out ISkillInfo info);
            } // end interface IIconConfig
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider
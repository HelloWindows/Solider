/*******************************************************************
 * FileName: IItemConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface IItemConfig {
                IItemInfo GetItemInfo(string id);
                string GetItemGrade(string id);
                string GetItemType(string id);
            } // end interface IItemConfig
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider

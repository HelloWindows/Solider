/*******************************************************************
 * FileName: IEquipInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface IEquipInfo : IItemInfo {
                string type { get; }
                string role { get; }
                IAttributeInfo attributeInfo { get; }
            } // end interface IEquipInfo
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider
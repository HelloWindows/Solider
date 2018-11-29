/*******************************************************************
 * FileName: IBluePrintInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface IBluePrintInfo : IItemInfo {
                int stuffNumber { get; }
                string targetID { get; }
                bool TryGetStuffID(int index, out string id);
                bool TryGetStuffCount(int index, out int count);
            } // end class IBluePrintInfo 
        } // end namespace Interface
    } // end namespace Config
} // end namespace Solider
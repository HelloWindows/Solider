/*******************************************************************
 * FileName: IWearEquip.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections.Generic;

namespace Solider {
    namespace Interface {
        public interface IWearInfo {
            void GetWearEquip(out Dictionary<string, string> dict);
            bool PutOnEquip(string id);
            void TakeOffEquip(string type);
        } // end interface IWearInfo
    } // end namespace Interface
} // end namespace Solider 

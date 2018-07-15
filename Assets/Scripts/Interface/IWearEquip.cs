/*******************************************************************
 * FileName: IWearEquip.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model;

namespace Solider {
    namespace Interface {
        public interface IWearEquip {
            void PutOnEquip(string type, string itemid);
            void TakeOffEquip(string type);
        } // end interface IWearEquip
    } // end namespace Interface
} // end namespace Solider 

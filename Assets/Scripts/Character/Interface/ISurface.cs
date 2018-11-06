/*******************************************************************
 * FileName: IDress.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ISurface {
                void FurlWeapon();
                void LiftWeapon();
                void ReloadEquip(string id);
                void ReloadEquip(Dictionary<string, string> wearDict);
            } // end interface ISurface
        } // end namespace Interface 
    } // end namespace Character 
} // end namespace Solider 

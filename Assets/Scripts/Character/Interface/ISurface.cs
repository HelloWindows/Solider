/*******************************************************************
 * FileName: IDress.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ISurface {
                void FurlWeapon();
                void LiftWeapon();
                void ReloadWeapon(string name);
                void ReloadArmor(string name);
            } // end interface ISurface
        } // end namespace Interface 
    } // end namespace Character 
} // end namespace Solider 

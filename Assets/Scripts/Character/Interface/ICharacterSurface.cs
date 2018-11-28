/*******************************************************************
 * FileName: ICharacterSurface.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterSurface : IDisposable {
                void FurlWeapon();
                void LiftWeapon();
                void Freshen();
            } // end interface ICharacterSurface
        } // end namespace Interface 
    } // end namespace Character 
} // end namespace Solider 

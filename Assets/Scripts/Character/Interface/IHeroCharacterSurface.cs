/*******************************************************************
 * FileName: IHeroCharacterSurface.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface IHeroCharacterSurface : IDisposable {
                void FurlWeapon();
                void LiftWeapon();
                void Freshen();
            } // end interface IHeroCharacterSurface
        } // end namespace Interface 
    } // end namespace Character 
} // end namespace Solider 

/*******************************************************************
 * FileName: IMainCharacterSurface.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface IMainCharacterSurface : IDisposable {
                void FurlWeapon();
                void LiftWeapon();
                void Freshen();
            } // end interface IMainCharacterSurface
        } // end namespace Interface 
    } // end namespace Character 
} // end namespace Solider 

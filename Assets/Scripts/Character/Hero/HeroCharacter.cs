/*******************************************************************
 * FileName: HeroCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Input;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Hero {
            public abstract class HeroCharacter : Character, IHeroCharacter {
                public IIputInfo input { get; protected set; }
                public IHeroCharacterSurface surface { get; protected set; }



                protected HeroCharacter(string id, GameObject gameObject) : base(id, gameObject) {
                } // end HeroCharacter

                public override void Dispose() {
                    if (true == isDisposed) return;
                    // end if
                    base.Dispose();
                    if (null != surface) surface.Dispose();
                    // end if
                } // end Dispose
            } // end class HeroCharacter
        } // end namespace Hero
    } // end namespace Character 
} // end namespace Solider 

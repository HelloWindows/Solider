/*******************************************************************
 * FileName: CharacterSurface.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        public class CharacterSurface : ICharacterSurface {
            protected SkinnedMeshRenderer renderer;

            public CharacterSurface(SkinnedMeshRenderer renderer) {
                this.renderer = renderer;
            } // end CharacterSurface
        } // end class CharacterSurface 
    } // end CharacterSurface
} // end namespace Custom
/*******************************************************************
 * FileName: ICharacterFactory.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Framework {
    namespace Interface {
        namespace Scene {
            public interface ICharacterFactory {
                void CreateMainCharacter(Vector3 position);
                void CreateNPC(Vector3 position);
            } // end class ICharacterFactory
        } // end namespace Scene
    } // end namespace Interface
} // end namespace Framework 

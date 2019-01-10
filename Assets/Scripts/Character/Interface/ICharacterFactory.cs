/*******************************************************************
 * FileName: ICharacterFactory.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterFactory {
                void CreateMainCharacter(Vector3 position);
                void CreateNPC(string id, Vector3 position);
                bool GetNPCharacter(string hashID, out ICharacter npc);
                void DisposeNPC(string hashID);
            } // end class ICharacterFactory
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

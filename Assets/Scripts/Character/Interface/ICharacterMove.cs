/*******************************************************************
 * FileName: ICharacterMove.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterMove  {
                void MoveForward(float speed);
                void MoveBackward(float speed);
                void MoveForward(Vector2 dir, float speed);
                void MoveBackward(Vector2 dir, float speed);
            } // end class ICharacterMove
        } // end namespace Interface 
    } // end namespace Character
} // end namespace Solider 

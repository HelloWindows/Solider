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
                void StepForward(float step, float deltaTime);
                void StepForward(Vector2 dir, float deltaTime);
                void MoveForward(Vector2 dir, float deltaTime);
                void MoveBackward();
            } // end class ICharacterMove
        } // end namespace Interface 
    } // end namespace Character
} // end namespace Solider 

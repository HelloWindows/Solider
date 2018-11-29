/*******************************************************************
 * FileName: CharacterMove.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        public class CharacterMove : ICharacterMove {
            private float speed;
            private Rigidbody rgd;
            private Transform transform;

            public CharacterMove(Rigidbody rgd) {
                speed = 3f;
                this.rgd = rgd;
                transform = rgd.transform;
            } // end CharacterMove

            public void StepForward(float step, float deltaTime) {
                transform.Translate(transform.forward * speed * deltaTime, Space.World);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end StepForward

            public void StepForward(Vector2 dir, float deltaTime) {
                Vector3 forward = new Vector3(dir.x, 0, dir.y);
                transform.Translate(forward * speed * deltaTime, Space.World);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end StepForward

            public void MoveForward(Vector2 dir, float deltaTime) {
                Vector3 forward = new Vector3(dir.x, 0, dir.y);
                transform.Translate(forward * speed * deltaTime, Space.World);
                rgd.MoveRotation(Quaternion.LookRotation(forward));
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end MoveForward

            public void StepBackward(float step, float deltaTime) {
                transform.Translate(-transform.forward * speed * deltaTime, Space.World);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end StepBackward

            public void MoveBackward(Vector2 dir, float deltaTime) {
                Vector3 forward = new Vector3(-dir.x, 0, -dir.y);
                transform.Translate(forward * speed * deltaTime, Space.World);
                rgd.MoveRotation(Quaternion.LookRotation(forward));
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end MoveBackward
        } // end class CharacterMove
    } // end namespace Character
} // end namespace Solider 

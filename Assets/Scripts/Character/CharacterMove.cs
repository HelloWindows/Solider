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
            private Transform transform;

            public CharacterMove(Transform transform) {
                this.transform = transform;
            } // end CharacterMove

            public void MoveForward(float speed) {
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end MoveForward

            public void MoveBackward(float speed) {
                transform.Translate(-transform.forward * speed * Time.deltaTime, Space.World);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end MoveBackward

            public void MoveForward(Vector2 dir, float speed) {
                Vector3 forward = new Vector3(dir.x, 0, dir.y).normalized;
                if (Vector3.zero == forward) return;
                // end if
                transform.Translate(forward * speed * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.LookRotation(forward);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end MoveForward

            public void MoveBackward(Vector2 dir, float speed) {
                Vector3 forward = new Vector3(-dir.x, 0, -dir.y).normalized;
                if (Vector3.zero == forward) return;
                // end if
                transform.Translate(forward * speed * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.LookRotation(-forward);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end MoveBackward

            public void FlashMove(Vector3 dir, float distance) {
                Vector3 forward = new Vector3(dir.x, 0, dir.z).normalized;
                if (Vector3.zero == forward) return;
                // end if
                transform.Translate(forward * distance, Space.World);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            } // end FlashMove

            public void LookAt(Vector3 position) {
                Vector3 target = new Vector3(position.x, transform.position.y, position.z);
                transform.LookAt(target);
            } // end LookAts
        } // end class CharacterMove
    } // end namespace Character
} // end namespace Solider 

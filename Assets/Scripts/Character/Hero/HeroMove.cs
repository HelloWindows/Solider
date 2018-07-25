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
        namespace Hero {
            public class HeroMove : ICharacterMove {
                private float speed;
                private Rigidbody rgd;
                private Transform transform;

                public HeroMove(Rigidbody rgd) {
                    speed = 3f;
                    this.rgd = rgd;   
                    transform = rgd.transform;
                } // end HeroMove

                public void StepForward(float step, float deltaTime) {
                    rgd.MovePosition(transform.position + transform.forward * step * deltaTime);
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                } // end StepForward

                public void StepForward(Vector2 dir, float deltaTime) {
                    Vector3 forward = new Vector3(dir.x, 0, dir.y);
                    rgd.MovePosition(transform.position + forward * speed * deltaTime);
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                } // end StepForward

                public void MoveForward(Vector2 dir, float deltaTime) {
                    Vector3 forward = new Vector3(dir.x, 0, dir.y);
                    rgd.MovePosition(transform.position + forward * speed * deltaTime);
                    rgd.MoveRotation(Quaternion.LookRotation(forward));
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                } // end MoveForward

                public void StepBackward(float step, float deltaTime) {
                    rgd.MovePosition(transform.position - transform.forward * step * deltaTime);
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                } // end StepBackward

                public void MoveBackward(Vector2 dir, float deltaTime) {
                    Vector3 forward = new Vector3(-dir.x, 0, -dir.y);
                    rgd.MovePosition(transform.position + forward * speed * deltaTime);
                    rgd.MoveRotation(Quaternion.LookRotation(forward));
                    transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                } // end MoveBackward
            } // end class HeroMove
        } // end namespace Hero
    } // end namespace Character
} // end namespace Solider 

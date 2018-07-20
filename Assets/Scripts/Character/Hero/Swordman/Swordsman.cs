/*******************************************************************
 * FileName: Swordsman.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom;
using Framework.Interface;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        public class Swordsman : MonoBehaviour, ICharacter {
            public IAvatar avatar{ get; private set; }
            private IIputInfo input;

            void Start() {
                Animation anim = gameObject.AddComponent<Animation>();
                avatar = new SwordsmanAvatar(anim);
                input = new CrossInput();
            } // end Start

            private void Update() {
                input.Update(Time.deltaTime);

                if (input.joystickDir.magnitude > 0) {
                    avatar.Play("walk");
                } // end if
            } // end Update
        } // end class Swordsman
    } // end namespace Character
} // end namespace Custom 

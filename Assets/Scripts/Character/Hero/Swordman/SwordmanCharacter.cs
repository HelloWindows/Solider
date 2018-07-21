/*******************************************************************
 * FileName: Swordsman.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Custom;
using Framework.FSM.Interface;
using Framework.Interface.Audio;
using Framework.Interface.Input;
using Solider.Character.Hero;
using Solider.Character.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Swordman {
            public class SwordmanCharacter : MonoBehaviour, ICharacter {
                public IFSM fsm { get; private set; }
                public IAvatar avatar { get; private set; }
                public new IAudioSound audio { get; private set; }
                public ICharacterMove move { get; private set; }
                private IIputInfo input;
                private IFSMSystem fsmSystem;

                void Start() {
                    input = new CrossInput();
                    gameObject.AddComponent<AudioListener>();
                    move = new HeroMove(gameObject.GetComponent<Rigidbody>());
                    avatar = new SwordmanAvatar(gameObject.AddComponent<Animation>());
                    audio = new CharacterAduio(gameObject.AddComponent<AudioSource>(), transform);
                    fsmSystem = new SwordmanFSM(this, input);
                    fsm = fsmSystem as IFSM;
                } // end Start

                private void Update() {
                    fsmSystem.Update(Time.deltaTime);
                } // end Update
            } // end class SwordmanCharacter
        } // end namespace Swordman
    } // end namespace Character
} // end namespace Custom 

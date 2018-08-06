/*******************************************************************
 * FileName: ICharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Audio;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacter {
                bool isDisposed { get; }
                IFSM fsm { get; }
                IAvatar avatar { get; }
                ISurface surface { get; }
                IAudioSound audio { get; }
                ICharacterMove move { get; }
                ICharacterInfo info { get; }
                Vector3 position { get; }
                void Update(float deltaTime);
                void Dispose();
            } // end interface ICharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

/*******************************************************************
 * FileName: ICharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Interface.Audio;
using Framework.Interface.Input;
using System;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacter : IDisposable {
                bool isDisposed { get; }
                IFSM fsm { get; }
                IIputInfo input { get; }
                ICharacterSurface surface { get; }
                ICharacterAduio audio { get; }
                ICharacterMove move { get; }
                ICharacterInfo info { get; }
                ICharacterBuff buff { get; }
                ICharacterAvatar avatar { get; }

                Vector3 position { get; }
                void Update(float deltaTime);
            } // end interface ICharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

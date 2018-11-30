/*******************************************************************
 * FileName: ICharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Config.Interface;
using System;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacter : IDisposable {
                string id { get; }
                string hashID { get; }
                bool isDisposed { get; }
                IFSM fsm { get; }
                ICharacterAduio audio { get; }
                ICharacterMove move { get; }
                ICharacterInfo info { get; }
                ICharacterBuff buff { get; }
                ICharacterAvatar avatar { get; }
                ICharacterConfig config { get; }

                Vector3 position { get; }
                void Update(float deltaTime);
            } // end interface ICharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

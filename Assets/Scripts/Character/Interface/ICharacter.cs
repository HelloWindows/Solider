/*******************************************************************
 * FileName: ICharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacter {
                string id { get; }
                string hashID { get; }
                bool isDisposed { get; }
                ICharacterFSM fsm { get; }
                ICharacterAudio audio { get; }
                ICharacterMove move { get; }
                ICharacterInfo info { get; }
                ICharacterBuff buff { get; }
                ICharacterAvatar avatar { get; }
                ICharacterConfig config { get; }
                ICharacterCenter center { get; }
                Vector3 position { get; }
                void Update();
            } // end interface ICharacter
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

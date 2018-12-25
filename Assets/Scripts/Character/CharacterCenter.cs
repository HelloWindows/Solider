/*******************************************************************
 * FileName: CharacterCenter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        public class CharacterCenter : ICharacterCenter {
            public void AddListener(Action<CenterEvent> action) {
                throw new NotImplementedException();
            } // end AddListener

            public void Broadcast(CenterEvent content) {
                throw new NotImplementedException();
            } // end Broadcast

            public void RemoveListener(Action<CenterEvent> action) {
                throw new NotImplementedException();
            } // end RemoveListener
        } // end class CharacterCenter 
    } // end namespace Character
} // end namespace Solider
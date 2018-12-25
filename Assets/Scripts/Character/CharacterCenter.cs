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
        public class CharacterCenter : ICharacterCenter, IDisposable {

            private Action<CenterEvent> m_action;

            public CharacterCenter() {
            } // end CharacterCenter

            public void AddListener(Action<CenterEvent> action) {
                m_action += action;
            } // end AddListener
            
            public void RemoveListener(Action<CenterEvent> action) {
                m_action -= action;
            } // end RemoveListener

            public void Broadcast(CenterEvent content) {
                if (null == m_action) return;
                // end if
                m_action(content);
            } // end Broadcast

            public void Dispose() {
                m_action = null;
            } // end Dispose
        } // end class CharacterCenter 
    } // end namespace Character
} // end namespace Solider
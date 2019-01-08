/*******************************************************************
 * FileName: CharacterManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Factory;
using Solider.Character.Interface;
using System;

namespace Solider {
    namespace Character {
        namespace Manager {
            public class CharacterManager : ICharacterManager, IDisposable {
                public ICharacterFactory factory { get { return m_factory; } }
                public IMainCharacter mainCharacter { get { return m_factory.mainCharacter; } }
                private CharacterFactory m_factory;

                public CharacterManager() {
                    m_factory = new CharacterFactory();
                } // end CharacterManager

                public void Update() {
                    m_factory.Update();
                } // end Update

                public void Dispose() {
                    if (null != m_factory) m_factory.Dispose();
                    // end if
                } // end Dispose
            } // end class CharacterManager 
        } // end namespace Manager
    } // end namespace Character
} // end namespace Solider
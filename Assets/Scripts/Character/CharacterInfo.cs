/*******************************************************************
 * FileName: CharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.ModelData.Character;
using Solider.ModelData.Data;
using Solider.ModelData.Interface;
using System;

namespace Solider {
    namespace Character {
        public abstract class CharacterInfo : ICharacterInfo, IDisposable {
            private bool isLive;
            public bool IsLive {
                get {
                    if (!isLive) return false;
                    // end if
                    if (m_charcterData.HP > 0) return true;
                    // end if
                    isLive = false;
                    return isLive;
                } // end get
            } // end IsLive
            public ICharacter lockCharacter { get; private set; }
            public ICharacterData characterData { get { return m_charcterData; } }
            private float timer;
            protected RealData m_selfTreat { get; private set; }

            protected IAttributeInfo initArribute;
            protected CharacterData m_charcterData;

            public CharacterInfo(string name) {
                timer = 0;
                isLive = true;
                m_selfTreat = new RealData();
            } // end CharacterInfo

            public void Update() {
                if (!IsLive) return;
                // end if
                timer += UnityEngine.Time.deltaTime;
                if (timer < 1) return;
                // end if
                timer = 0;
                m_selfTreat.SetSelfTreat(m_charcterData);
                m_charcterData.Plus(m_selfTreat);
            } // end SelfHealing

            public void RelockCharacter(string hashID) {
            } // end RelockCharacter

            public void Revive() {

            } // end Revive

            public abstract void Dispose();
            // end Dispose
        } // end class CharacterInfo 
    } // end namespace Character
} // end namespace Custom
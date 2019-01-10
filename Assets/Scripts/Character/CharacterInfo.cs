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
            public bool IsLive {
                get {
                    return m_charcterData.IsLive;
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
                m_selfTreat = new RealData();
            } // end CharacterInfo

            public void Update() {
                if (!IsLive || m_charcterData.HP == m_charcterData.XHP && m_charcterData.MP == m_charcterData.XMP) return;
                // end if
                timer += UnityEngine.Time.deltaTime;
                if (timer < 1) return;
                // end if
                timer = 0;
                m_selfTreat.SetSelfTreat(m_charcterData);
                m_charcterData.Plus(m_selfTreat);
            } // end SelfHealing

            public void LockCharacter(ICharacter chracter) {
                lockCharacter = chracter;
            } // end LockCharacter

            public void Revive() {
                m_charcterData.Revive();
            } // end Revive

            public abstract void Dispose();
            public abstract void UnderAttack(IDamageData data);
            // end Dispose
        } // end class CharacterInfo 
    } // end namespace Character
} // end namespace Custom
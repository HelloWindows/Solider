/*******************************************************************
 * FileName: CharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.Manager;
using Solider.ModelData.Character;
using Solider.ModelData.Data;
using Solider.ModelData.Interface;
using System;

namespace Solider {
    namespace Character {
        public class CharacterInfo : ICharacterInfo, IDisposable {
            private bool isLive;
            public bool IsLive {
                get {
                    if (!isLive) return false;
                    // end if
                    if (charcterData.HP > 0) return true;
                    // end if
                    isLive = false;
                    return isLive;
                } // end get
            } // end IsLive
            private float timer;
            private RealData m_selfTreat;
            private ICharacter character;

            protected IAttributeInfo initArribute;
            protected CharacterData charcterData;

            public CharacterInfo(string name, string roleType, ICharacter character) {
                timer = 0;
                isLive = true;
                this.character = character;
                charcterData = new CharacterData(name, roleType);
                initArribute = character.config.initAttribute;
                CheckAttributeData(CenterEvent.ReloadEquip);
                m_selfTreat = new RealData();
                charcterData.Plus(m_selfTreat);
                if (null == character) return;
                // end if
                character.center.AddListener(this.CheckAttributeData);
            } // end CharacterInfo

            public ICharacterData GetCharacterData() {
                return charcterData;
            } // end GetAttributeData

            public void Update(float deltaTime) {
                if (!IsLive) return;
                // end if
                timer += deltaTime;
                if (timer < 1) return;
                // end if
                timer = 0;
                m_selfTreat.SetSelfTreat(charcterData);
                charcterData.Plus(m_selfTreat);
            } // end SelfHealing

            protected virtual void CheckAttributeData(CenterEvent type) {
                if (CenterEvent.BuffChange != type) return;
                // end if
            } // end CheckAttributeData

            public void Revive() {

            } // end Revive

            public void Dispose() {
                if (null == character) return;
                // end if
                character.center.RemoveListener(CheckAttributeData);
            } // end Dispose
        } // end class CharacterInfo 
    } // end namespace Character
} // end namespace Custom
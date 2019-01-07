/*******************************************************************
 * FileName: NPCharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using Solider.ModelData.Character;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class NPCharacterInfo : CharacterInfo {
                private ICharacter character;

                public NPCharacterInfo(string name, ICharacter character) : base(name) {
                    this.character = character;
                    initArribute = character.config.initAttribute;
                    m_charcterData = new CharacterData(name);
                    CheckAttributeData(CenterEvent.ReloadEquip);
                    m_charcterData.Plus(m_selfTreat);
                    character.center.AddListener(CheckAttributeData);
                } // end MainCharacterInfo

                private void CheckAttributeData(CenterEvent type) {
                    if (CenterEvent.BuffChange != type && CenterEvent.ReloadEquip != type) return;
                    // end if
                    m_charcterData.Init(initArribute);
                } // end CheckAttributeData

                public override void Dispose() {
                    character.center.RemoveListener(CheckAttributeData);
                } // end Dispose
            } // end class NPCharacterInfo
        } // end namespace NPC
    } // end namespace Character
} // end namespace Solider 
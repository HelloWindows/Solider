/*******************************************************************
 * FileName: MainCharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.ModelData.Character;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterInfo : CharacterInfo {
                private IMainCharacter mainCharacter;

                public MainCharacterInfo(string name, string roleType, IMainCharacter mainCharacter) : base(name) {
                    this.mainCharacter = mainCharacter;
                    initArribute = mainCharacter.config.initAttribute;
                    m_charcterData = new CharacterData(name, roleType);
                    CheckAttributeData(CenterEvent.ReloadEquip);
                    m_charcterData.Plus(m_selfTreat);
                    mainCharacter.center.AddListener(CheckAttributeData);
                } // end MainCharacterInfo

                private void CheckAttributeData(CenterEvent type) {
                    if (CenterEvent.BuffChange != type && CenterEvent.ReloadEquip != type) return;
                    // end if
                    m_charcterData.Init(initArribute);
                    for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                        IEquipInfo info = mainCharacter.pack.GetWearInfo().GetEquipInfo(ConstConfig.EquipTypeList[i]);
                        if (null == info) continue;
                        // end if
                        m_charcterData.Plus(info);
                    } // end for
                } // end CheckAttributeData

                public override void Dispose() {
                    mainCharacter.center.RemoveListener(CheckAttributeData);
                } // end Dispose
            } // end class MainCharacterInfo
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

/*******************************************************************
 * FileName: MainCharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Solider.Character.Interface;
using Solider.Config.Interface;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MainCharacterInfo : CharacterInfo {
                private IMainCharacter mainCharacter;

                public MainCharacterInfo(string name, string roleType, IMainCharacter mainCharacter) : base(name, roleType, mainCharacter) {
                    this.mainCharacter = mainCharacter;
                } // end MainCharacterInfo

                protected override void CheckAttributeData(CenterEvent type) {
                    if (CenterEvent.ReloadEquip != type || CenterEvent.BuffChange != type) return;
                    // end if
                    charcterData.Init(initArribute);
                    for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                        IEquipInfo info = mainCharacter.pack.GetWearInfo().GetEquipInfo(ConstConfig.EquipTypeList[i]);
                        if (null == info) continue;
                        // end if
                        charcterData.Plus(info);
                    } // end for
                } // end CheckAttributeData
            } // end class MainCharacterInfo
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider 

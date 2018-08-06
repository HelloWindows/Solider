/*******************************************************************
 * FileName: CharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using Solider.Model.Data;

namespace Solider {
    namespace Character {
        namespace Model {
            public class CharacterInfo : ICharacterInfo {
                private bool isLive;
                public bool IsLive {
                    get {
                        if (!isLive) return false;
                        // end if
                        if (roleArribute.HP <= 0) isLive = false;
                        // end if
                        return isLive;
                    } // end get
                } // end IsLive
                private FairData selfTreat;
                private CharacterAttribute roleArribute;
                private CharacterAttribute tempArribute;
                private CharacterInitAttribute roleInitArribute;

                public CharacterInfo(int id, string name, string roleType) {
                    selfTreat = new FairData();
                    roleArribute = new CharacterAttribute(id, name, roleType);
                    tempArribute = new CharacterAttribute(id, name, roleType);
                    roleInitArribute = new CharacterInitAttribute("");
                } // end CharacterInfo

                public AttributeData GetAttributeData() {
                    tempArribute += roleInitArribute;
                    //for (int i = 0; i < equipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                    //    EquipInfo info = equipPack.GetEquipInfo(equipTypeList[i]);
                    //    if (null == info) continue;
                    //    // end if
                    //    tempArribute += info;
                    //} // end for
                    roleArribute += tempArribute;
                    return roleArribute;
                } // end GetAttributeData

                public void SelfHealing() {
                    if (!IsLive) return;
                    // end if
                    GetAttributeData();
                    selfTreat += roleArribute;
                    roleArribute += selfTreat;
                } // end SelfHealing
            } // end class CharacterInfo 
        } // end namespace Model
    } // end namespace Character
} // end namespace Custom
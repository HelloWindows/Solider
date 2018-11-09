/*******************************************************************
 * FileName: CharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Broadcast;
using Framework.Config;
using Framework.Config.Const;
using Solider.Character.Interface;
using Solider.Config;
using Solider.Manager;
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
                        if (roleArribute.HP > 0) return true;
                        // end if
                        isLive = false;
                        return isLive;
                    } // end get
                } // end IsLive
                private RealData selfTreat;
                private CharacterAttribute roleArribute;
                private CharacterAttribute tempArribute;
                private CharacterInitAttribute roleInitArribute;

                public CharacterInfo(int id, string name, string roleType) {
                    isLive = true;
                    selfTreat = new RealData();
                    roleArribute = new CharacterAttribute(id, name, roleType);
                    tempArribute = new CharacterAttribute(id, name, roleType);
                    roleInitArribute = new CharacterInitAttribute("");
                    CheckAttributeData();
                    BroadcastCenter.AddListener(BroadcastType.ReloadEquip, CheckAttributeData);
                } // end CharacterInfo

                public AttributeData GetAttributeData() {
                    tempArribute += roleArribute;
                    return tempArribute;
                } // end GetAttributeData

                public void SelfHealing() {
                    if (!IsLive) return;
                    // end if
                    selfTreat += roleArribute;
                    roleArribute += selfTreat;
                } // end SelfHealing

                private void CheckAttributeData() {
                    if (null == GameManager.playerInfo.pack) return;
                    // end if
                    tempArribute += roleInitArribute;
                    for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                        EquipInfo info = GameManager.playerInfo.pack.GetWearInfo().GetEquipInfo(ConstConfig.EquipTypeList[i]);
                        if (null == info) continue;
                        // end if
                        tempArribute += info;
                    } // end for
                    roleArribute += tempArribute;
                } // end CheckAttributeData

                public void Revive() {
                    
                } // end Revive

                public void Dispose() {
                    BroadcastCenter.RemoveListener(BroadcastType.ReloadEquip, CheckAttributeData);
                } // end Dispose
            } // end class CharacterInfo 
        } // end namespace Model
    } // end namespace Character
} // end namespace Custom
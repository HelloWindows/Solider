/*******************************************************************
 * FileName: CharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Broadcast;
using Framework.Config.Const;
using Solider.Character.Interface;
using Solider.Character.Model;
using Solider.Config.Interface;
using Solider.Manager;
using Solider.Model.Data;

namespace Solider {
    namespace Character {
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
            private float timer;
            private RealData selfTreat;
            private CharacterAttribute roleArribute;
            private CharacterAttribute tempArribute;
            private CharacterInitAttribute roleInitArribute;

            public CharacterInfo(string id, string name, string roleType) {
                timer = 0;
                isLive = true;
                selfTreat = new RealData();
                roleArribute = new CharacterAttribute(name, roleType);
                tempArribute = new CharacterAttribute(name, roleType);
                roleInitArribute = new CharacterInitAttribute("");
                CheckAttributeData();
                roleArribute += selfTreat;
                BroadcastCenter.AddListener(BroadcastType.ReloadEquip, CheckAttributeData);
            } // end CharacterInfo

            public CharacterAttribute GetAttributeData() {
                tempArribute += roleArribute;
                return tempArribute;
            } // end GetAttributeData

            public void Update(float deltaTime) {
                if (!IsLive) return;
                // end if
                timer += deltaTime;
                if (timer < 1) return;
                // end if
                timer = 0;
                selfTreat += roleArribute;
                roleArribute += selfTreat;
            } // end SelfHealing

            private void CheckAttributeData() {
                if (null == GameManager.playerInfo.pack) return;
                // end if
                tempArribute += roleInitArribute;
                for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                    IEquipInfo info = GameManager.playerInfo.pack.GetWearInfo().GetEquipInfo(ConstConfig.EquipTypeList[i]);
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
    } // end namespace Character
} // end namespace Custom
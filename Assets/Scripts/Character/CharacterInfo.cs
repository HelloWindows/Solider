/*******************************************************************
 * FileName: CharacterInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Broadcast;
using Framework.Config.Const;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.Manager;
using Solider.ModelData.Character;
using Solider.ModelData.Data;
using Solider.ModelData.Interface;

namespace Solider {
    namespace Character {
        public class CharacterInfo : ICharacterInfo {
            private bool isLive;
            public bool IsLive {
                get {
                    if (!isLive) return false;
                    // end if
                    if (charcterDataAction.HP > 0) return true;
                    // end if
                    isLive = false;
                    return isLive;
                } // end get
            } // end IsLive
            private float timer;
            private IRealDataAction selfTreatAction;
            private ICharacterDataAction charcterDataAction;
            private IAttributeInfo initArribute;

            public CharacterInfo(string name, string roleType, IAttributeInfo initArribute) {
                timer = 0;
                isLive = true;
                charcterDataAction = new CharacterDataAction(name, roleType);
                this.initArribute = initArribute;
                CheckAttributeData();
                selfTreatAction = new RealData();
                charcterDataAction.Plus(selfTreatAction);
                BroadcastCenter.AddListener(BroadcastType.ReloadEquip, CheckAttributeData);
            } // end CharacterInfo

            public ICharacterData GetCharacterData() {
                return charcterDataAction;
            } // end GetAttributeData

            public void Update(float deltaTime) {
                if (!IsLive) return;
                // end if
                timer += deltaTime;
                if (timer < 1) return;
                // end if
                timer = 0;
                selfTreatAction.SetSelfTreat(charcterDataAction);
                charcterDataAction.Plus(selfTreatAction);
            } // end SelfHealing

            private void CheckAttributeData() {
                if (null == GameManager.playerInfo.pack) return;
                // end if
                charcterDataAction.Init(initArribute);
                for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                    IEquipInfo info = GameManager.playerInfo.pack.GetWearInfo().GetEquipInfo(ConstConfig.EquipTypeList[i]);
                    if (null == info) continue;
                    // end if
                    charcterDataAction.Plus(info);
                } // end for
            } // end CheckAttributeData

            public void Revive() {

            } // end Revive

            public void Dispose() {
                BroadcastCenter.RemoveListener(BroadcastType.ReloadEquip, CheckAttributeData);
            } // end Dispose
        } // end class CharacterInfo 
    } // end namespace Character
} // end namespace Custom
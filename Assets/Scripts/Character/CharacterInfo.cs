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
                    if (m_charcterDataAction.HP > 0) return true;
                    // end if
                    isLive = false;
                    return isLive;
                } // end get
            } // end IsLive
            private float timer;
            private RealData m_selfTreat;
            private CharacterData m_charcterDataAction;
            private IAttributeInfo m_initArribute;
            private ICharacterCenter m_center;

            public CharacterInfo(string name, string roleType, IAttributeInfo initArribute, ICharacterCenter center) {
                timer = 0;
                isLive = true;
                m_center = center;
                m_charcterDataAction = new CharacterData(name, roleType);
                m_initArribute = initArribute;
                CheckAttributeData(CenterEvent.ReloadEquip);
                m_selfTreat = new RealData();
                m_charcterDataAction.Plus(m_selfTreat);
                if (null == m_center) return;
                // end if
                m_center.AddListener(CheckAttributeData);
            } // end CharacterInfo

            public ICharacterData GetCharacterData() {
                return m_charcterDataAction;
            } // end GetAttributeData

            public void Update(float deltaTime) {
                if (!IsLive) return;
                // end if
                timer += deltaTime;
                if (timer < 1) return;
                // end if
                timer = 0;
                m_selfTreat.SetSelfTreat(m_charcterDataAction);
                m_charcterDataAction.Plus(m_selfTreat);
            } // end SelfHealing

            private void CheckAttributeData(CenterEvent type) {
                if (null == GameManager.playerInfo.pack) return;
                // end if
                m_charcterDataAction.Init(m_initArribute);
                for (int i = 0; i < ConstConfig.EquipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                    IEquipInfo info = GameManager.playerInfo.pack.GetWearInfo().GetEquipInfo(ConstConfig.EquipTypeList[i]);
                    if (null == info) continue;
                    // end if
                    m_charcterDataAction.Plus(info);
                } // end for
            } // end CheckAttributeData

            public void Revive() {

            } // end Revive

            public void Dispose() {
                if (null == m_center) return;
                // end if
                m_center.RemoveListener(CheckAttributeData);
            } // end Dispose
        } // end class CharacterInfo 
    } // end namespace Character
} // end namespace Custom
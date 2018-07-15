/*******************************************************************
 * FileName: PlayerInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections.Generic;
using Solider.Model.Data;
using Solider.Interface;

namespace Solider {
    namespace Model {
        public class PlayerInfo {
            private static PlayerInfo instance;
            public static PlayerInfo GetInstance(string playerID, string name, string roleType) {
                if (null == instance) instance = new PlayerInfo(playerID, name, roleType);
                // end if
                return instance;
            } // end GetInstance

            private WearInfo wearInfo;
            private RoleAttribute roleArribute;

            private PlayerInfo(string playerID, string name, string roleType) {
                wearInfo = new WearInfo();
                roleArribute = new RoleAttribute(playerID, name, roleType);
            } // end PlayerInfo

            public AttributeData GetAttributeData() {
                return roleArribute;
            } // end GetAttributeData

            public IWearEquip GetWearInfo() {
                return wearInfo;
            } // end GetWearInfo

            private class WearInfo : IWearEquip {
                private readonly string[] nameList = { "weapon", "armor", "shoes" };
                private Dictionary<string, string> wearDict;

                public WearInfo() {
                    wearDict = new Dictionary<string, string>();
                    for (int i = 0; i < nameList.Length; i++) {
                        
                    } // end for
                } // end WearInfo

                public void PutOnEquip(string type, string itemid) {
                    if (!wearDict.ContainsKey(type)) return;
                    // end if
                    string itemType = ConfigManager.itemConfig.GetItemType(itemid);
                    if (itemType != type) return;
                    // end if

                } // end WearEquip
            
                public void TakeOffEquip(string type) {

                } // end TakeOffEquip

                public EquipInfo GetEquipInfo(string type) {
                    if (!wearDict.ContainsKey(type)) return null;
                    // end if
                    ItemInfo info = ConfigManager.itemConfig.GetItemInfo(wearDict[type]);
                    if (null == info) return null;
                    // end if
                    return info as EquipInfo;
                } // end GetItemInfo
            } // end class WearInfo
        } // end class PlayerInfo 
    } // end namespace Data
} // end namespace Solider
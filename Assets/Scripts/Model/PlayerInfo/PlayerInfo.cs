/*******************************************************************
 * FileName: PlayerInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Model {
        public class PlayerInfo {

            private class WearInfo {
                private readonly string[] nameList = { "weapon", "armor", "shoes" };
                private Dictionary<string, string> wearDict;

                public WearInfo() {
                    wearDict = new Dictionary<string, string>();
                    for (int i = 0; i < nameList.Length; i++) {
                        
                    } // end for
                } // end WearInfo

                public void WearEquip(string type, string itemid) {
                    if (!wearDict.ContainsKey(type)) return;
                    // end if

                } // end WearEquip

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
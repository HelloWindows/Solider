/*******************************************************************
 * FileName: RoleInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections.Generic;
using Solider.Model.Data;
using Solider.Interface;
using Solider.Manager;
using System;
using Framework.Config;

namespace Solider {
    namespace Model {
        public class RoleInfo {
            private static RoleInfo instance;
            public static RoleInfo GetInstance(string roleID, string name, string roleType) {
                if (null == instance) instance = new RoleInfo(roleID, name, roleType);
                // end if
                return instance;
            } // end GetInstance

            private WearInfo wearInfo;
            private RoleAttribute roleArribute;

            private RoleInfo(string roleID, string name, string roleType) {
                wearInfo = new WearInfo(roleID, roleType);
                roleArribute = new RoleAttribute(roleID, name, roleType);
            } // end PlayerInfo

            public AttributeData GetAttributeData() {
                return roleArribute;
            } // end GetAttributeData

            public IWearInfo GetWearInfo() {
                return wearInfo;
            } // end GetWearInfo

            private class WearInfo : IWearInfo {
                private readonly string roleID;
                private readonly string roleType;
                private Dictionary<string, string> wearDict;

                public WearInfo(string roleID, string roleType) {
                    this.roleID = roleID;
                    this.roleType = roleType;
                    Dictionary<string, string> dict = new Dictionary<string, string>();
                    SqliteManager.GetWearInfoWithID(roleID, ref dict);
                    wearDict = new Dictionary<string, string>();
                    for (int i = 0; i < ConfigManager.equipTypeList.Length; i++) {
                        string type = ConfigManager.equipTypeList[i];
                        if (dict.ContainsKey(type)) {
                            wearDict[type] = dict[type];
                        } else {
                            wearDict[type] = "0";
                        } // end if
                    } // end for
                } // end WearInfo

                public bool PutOnEquip(string id) {
                    EquipInfo info = ConfigManager.itemConfig.GetItemInfo(id) as EquipInfo;
                    if (null == info || (info.role != ConstConfig.ALLROLE && info.role != roleType)) return false;
                    // end if
                    string type = info.type;
                    if (!wearDict.ContainsKey(type)) return false;
                    // end if
                    RoleManager.pack.PackItem(wearDict[type], 0);
                    wearDict[type] = id;
                    SqliteManager.SetWearInfoWithID(roleID, type, wearDict[type]);
                    return true;
                } // end WearEquip
            
                public void TakeOffEquip(string type) {
                    if (!wearDict.ContainsKey(type)) return;
                    // end if
                    RoleManager.pack.PackItem(wearDict[type], 0);
                    wearDict[type] = "0";
                    SqliteManager.SetWearInfoWithID(roleID, type, wearDict[type]);
                } // end TakeOffEquip

                public EquipInfo GetEquipInfo(string type) {
                    if (!wearDict.ContainsKey(type)) return null;
                    // end if
                    ItemInfo info = ConfigManager.itemConfig.GetItemInfo(wearDict[type]);
                    if (null == info) return null;
                    // end if
                    return info as EquipInfo;
                } // end GetItemInfo

                public void GetWearEquip(out Dictionary<string, string> dict) {
                    dict = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, string> pair in wearDict) {
                        dict[pair.Key] = pair.Value;
                    } // end foreach
                } // end GetWearEquip
            } // end class WearInfo
        } // end class RoleInfo 
    } // end namespace Data
} // end namespace Solider
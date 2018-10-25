/*******************************************************************
 * FileName: PackInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using System.Collections.Generic;
using Solider.Interface;
using Framework.Config;
using Solider.Config;
using System.Collections;

namespace Solider {
    namespace Model {
        public class PackInfo : IPackInfo {
            private EquipPack equipPack;
            private Dictionary<string, IPack> packDict;
            private readonly string[] equipTypeList = { ConstConfig.WEAPON, ConstConfig.NECKLACE, ConstConfig.RING,
                ConstConfig.ARMOE, ConstConfig.PANTS, ConstConfig.SHOES };

            public PackInfo(string username, int roleindex, string name, string roleType) {
                packDict = new Dictionary<string, IPack>();
                equipPack = new EquipPack(username, roleindex, ConstConfig.EQUIP, roleType);
                packDict.Add(ConstConfig.EQUIP, equipPack);
                packDict.Add(ConstConfig.CONSUME, new Pack(username, roleindex, ConstConfig.CONSUME));
                packDict.Add(ConstConfig.STUFF, new Pack(username, roleindex, ConstConfig.STUFF));
                packDict.Add(ConstConfig.PRINT, new Pack(username, roleindex, ConstConfig.PRINT));
            } // end PlayerInfo

            public IWearInfo GetWearInfo() {
                return equipPack;
            } // end GetWearInfo

            public void PackItem(string id, int count) {
                IPack pack = GetItemPack(Configs.itemConfig.GetItemType(id));
                if (null == pack) return;
                // end if
                pack.PackItem(id, count);
            } // end PackItems

            public IPack GetItemPack(string name) {
                if (packDict.ContainsKey(name)) {
                    return packDict[name];
                } // end if
                return null;
            } // end GetItemPack

            public IEnumerator GetEnumerator() {
                for (int i = 0; i < equipTypeList.Length; i++) { // 累加所有已穿戴的装备的属性
                    EquipInfo info = equipPack.GetEquipInfo(equipTypeList[i]);
                    if (null == info) continue;
                    // end if
                    yield return info;
                } // end for
            } // end GetEnumerator
        } // end class PackInfo 
    } // end namespace Data
} // end namespace Solider
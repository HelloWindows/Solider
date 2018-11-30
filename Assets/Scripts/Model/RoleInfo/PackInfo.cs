/*******************************************************************
 * FileName: PackInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using System.Collections.Generic;
using Framework.Config;
using Solider.Model.Interface;

namespace Solider {
    namespace Model {
        public class PackInfo : IPackInfo {
            private IWearInfo wearInfo;
            private Dictionary<string, IPack> packDict;

            public PackInfo(string username, int roleindex, string name, string roleType) {
                packDict = new Dictionary<string, IPack>();
                IEquipPack equipPack = new EquipPack(username, roleindex, ConstConfig.EQUIP, roleType);
                wearInfo = equipPack;
                packDict.Add(ConstConfig.EQUIP, equipPack);
                packDict.Add(ConstConfig.CONSUME, new Pack(username, roleindex, ConstConfig.CONSUME));
                packDict.Add(ConstConfig.STUFF, new Pack(username, roleindex, ConstConfig.STUFF));
                packDict.Add(ConstConfig.PRINT, new Pack(username, roleindex, ConstConfig.PRINT));
            } // end PlayerInfo

            public IWearInfo GetWearInfo() {
                return wearInfo;
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
        } // end class PackInfo 
    } // end namespace Data
} // end namespace Solider
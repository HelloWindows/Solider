/*******************************************************************
 * FileName: Pack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config;
using Framework.Config;
using Framework.Config.Const;
using Framework.Manager;
using Solider.Interface;
using System.Collections.Generic;
using Framework.Broadcast;

namespace Solider {
    namespace Model {
        public class EquipPack : IPack, IWearInfo {
            private readonly int roleindex;
            private readonly string username;
            private readonly string packType;
            private readonly string roleType;

            private string[] idList;
            private Dictionary<string, string> wearDict;

            public bool IsFull {
                get {
                    for (int i = 0; i < idList.Length; i++) {
                        if (idList[i] == "0") return false;
                        // end if
                    } // end for
                    return true;
                } // end get
            } // end IsFull

            public EquipPack(string username, int roleindex, string packType, string roleType) {
                this.username = username;
                this.roleindex = roleindex;
                this.packType = packType;
                this.roleType = roleType;
                idList = new string[ConstConfig.GRID_COUNT];

                #region ******** 初始化背包信息 ********
                Dictionary<int, string[]> idDict;
                SqliteManager.GetPackInfoWithID(username, roleindex, packType, out idDict);
                for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                    if (!idDict.ContainsKey(i)) {
                        idList[i] = "0";
                        continue;
                    } // end if
                    idList[i] = idDict[i][0];
                    if (Configs.itemConfig.GetItemType(idList[i]) != packType) idList[i] = "0";
                    // end if
                } // end for
                #endregion

                #region ******** 初始化装备穿戴信息 ********
                string[] equipTypeList = { ConstConfig.WEAPON, ConstConfig.NECKLACE, ConstConfig.RING, ConstConfig.WING,
                ConstConfig.ARMOE, ConstConfig.PANTS, ConstConfig.SHOES };
                Dictionary<string, string> wearDict;
                SqliteManager.GetWearInfoWithID(username, roleindex, out wearDict);
                this.wearDict = new Dictionary<string, string>();
                for (int i = 0; i < equipTypeList.Length; i++) {
                    string type = equipTypeList[i];
                    if (wearDict.ContainsKey(type)) {
                        this.wearDict[type] = wearDict[type];
                    } else {
                        this.wearDict[type] = "0";
                    } // end if
                } // end for
                #endregion
            } // end Pack

            public void PackItem(string itemID, int count) {
                if (packType != Configs.itemConfig.GetItemType(itemID)) return;
                // end if
                for (int i = 0; i < idList.Length; i++) {
                    if (idList[i] != "0") continue;
                    // end if
                    idList[i] = itemID;
                    WriteGridInfo(i, idList[i], 1);
                    return;
                } // end for
            } // end PackItem

            public bool EnoughWithIDAndCount(string itemID, int count) {
                if (GetCountForID(itemID) < count) return false;
                // end if
                return true;
            } // end EnoughWithIDAndCount

            public void UseItemWithGid(int gid) {
                if (gid < 0 || gid >= idList.Length) return;
                // end if
                string tempID = idList[gid];
                EquipInfo info = Configs.itemConfig.GetItemInfo(tempID) as EquipInfo;
                if (null == info || (info.role != ConstConfig.ALLROLE && info.role != roleType)) return; // 检测是否是装备，是否符合当前角色类型
                // end if
                string type = info.type;
                if (!wearDict.ContainsKey(type)) return; // 检测装备类型是否存在
                // end if
                idList[gid] = wearDict[type];
                wearDict[type] = tempID;
                WriteGridInfo(gid, idList[gid], 0);
                BroadcastCenter.Broadcast(BroadcastType.ReloadEquip);
                SqliteManager.SetWearInfoWithID(username, roleindex, type, wearDict[type]);
            } // end UseItemWithGid

            public void ExpendItemWithID(string itemID, int count) {
                for (int i = 0; i < idList.Length; i++) {
                    if (idList[i] != itemID) continue;
                    // end if
                    idList[i] = "0";
                    count--;
                    if (count > 0) continue;
                    // end if
                } // end for
            } // end ExpendItemWithID

            public ItemInfo GetItemInfoForGrid(int gid) {
                if (gid < 0 || gid >= idList.Length) return null;
                // end if
                return Configs.itemConfig.GetItemInfo(idList[gid]);
            } // end GetItemInfoWithGid

            public int GetCountForGrid(int gid) {
                if (gid < 0 || gid >= idList.Length) return 0;
                // end if
                if (idList[gid] == "0") return 0;
                // end if
                return 1;
            } // end GetConsumeCountWithGid

            public int GetCountForID(string itemID) {
                int sum = 0;
                for (int i = 0; i < idList.Length; i++) {
                    if (itemID == idList[i]) sum++;
                    // end if
                } // end for
                return sum;
            } // end GetCountForID

            public void ExchangeGridInfoWithGid(int gid, int target) {
                if (gid < 0 || gid >= idList.Length || target < 0 || target >= idList.Length) return;
                // end if
                string tid = idList[gid];
                idList[gid] = idList[target];
                idList[target] = tid;
                WriteGridInfo(gid, idList[gid], 0);
                WriteGridInfo(target, idList[target], 0);
            } // end ExchangeGridInfoWithGid

            public void ArrangePack() {
                Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
                SqliteManager.GetArrangePackInfo(username, roleindex, packType, ref dict);
                for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                    if (dict.ContainsKey(i)) {
                        idList[i] = dict[i][0];
                    } else {
                        idList[i] = "0";
                    } // end if
                    WriteGridInfo(i, idList[i], 0);
                } // end for
            } // end ArrangePack

            public void DiscardItem(int gid, int count) {
                if (gid < 0 || gid >= idList.Length || count < 0) return;
                // end if
                idList[gid] = "0";
                WriteGridInfo(gid, idList[gid], 0);
            } // end DiscardItem

            public Dictionary<string, string> GetWearEquip() {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (KeyValuePair<string, string> pair in wearDict) {
                    dict[pair.Key] = pair.Value;
                } // end foreach
                return dict;
            } // end GetWearEquip

            public void TakeOffEquip(string type) {
                if ("0" == wearDict[type] || !wearDict.ContainsKey(type)) return;
                // end if
                PackItem(wearDict[type], 0);
                wearDict[type] = "0";
                SqliteManager.SetWearInfoWithID(username, roleindex, type, wearDict[type]);
            } // end TakeOffEquip

            public EquipInfo GetEquipInfo(string type) {
                if (!wearDict.ContainsKey(type)) {
                    return null;
                } // end if
                return Configs.itemConfig.GetItemInfo(wearDict[type]) as EquipInfo;
            } // end GetItemInfo

            private void WriteGridInfo(int gid, string id, int count) {
                string grade = Configs.itemConfig.GetItemGrade(id);
                SqliteManager.SetPackInfoWithID(username, roleindex, packType, gid, id, grade, count);
            } // end WriteGridInfo
        } // end class EquipPack
    } // end namespace Model
} // end namespace Solider 

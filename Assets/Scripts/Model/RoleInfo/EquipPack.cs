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

namespace Solider {
    namespace Model {
        public class EquipPack : IPack, IWearInfo {
            private readonly string packType;
            private readonly string roleID;
            private readonly string roleType;
            private readonly string[] equipTypeList = { ConstConfig.WEAPON, ConstConfig.ARMOE, ConstConfig.SHOES };

            private string[] idList;
            private Dictionary<string, string> wearDict;

            public EquipPack(string roleID, string packType, string roleType) {
                this.roleID = roleID;
                this.packType = packType;
                this.roleType = roleType;
                idList = new string[ConstConfig.GRID_COUNT];

                #region ******** 初始化背包信息 ********
                Dictionary<int, string[]> idDict;
                SqliteManager.GetPackInfoWithID(roleID, packType, out idDict);
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
                Dictionary<string, string> wearDict;
                SqliteManager.GetWearInfoWithID(roleID, out wearDict);
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
                string type = Configs.itemConfig.GetItemType(itemID);
                if (this.packType != type) return;
                // end if
                for (int i = 0; i < idList.Length; i++) {
                    if (idList[i] != "0") continue;
                    // end if
                    idList[i] = itemID;
                    WriteGridInfo(i, idList[i], 0);
                    return;
                } // end for
            } // end PackItem

            public void UseItemWithGid(int gid) {
                if (gid < 0 || gid >= idList.Length) return;
                // end if
                EquipInfo info = Configs.itemConfig.GetItemInfo(idList[gid]) as EquipInfo;
                if (null == info || (info.role != ConstConfig.ALLROLE && info.role != roleType)) return; // 检测是否是装备，是否符合当前角色类型
                // end if
                string type = info.type;
                if (!wearDict.ContainsKey(type)) return; // 检测装备类型是否存在
                // end if
                string temp = idList[gid];
                idList[gid] = wearDict[type];
                wearDict[type] = temp;
                WriteGridInfo(gid, idList[gid], 0);
                SqliteManager.SetWearInfoWithID(roleID, type, wearDict[type]);
            } // end UseItemWithGid

            public ItemInfo GetItemInfoForGrid(int gid) {
                if (gid < 0 || gid >= idList.Length) return null;
                // end if
                return Configs.itemConfig.GetItemInfo(idList[gid]);
            } // end GetItemInfoWithGid

            public int GetCountForGrid(int gid) {
                return 0;
            } // end GetConsumeCountWithGid

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
                SqliteManager.GetArrangePackInfo(roleID, packType, ref dict);
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
                if (!wearDict.ContainsKey(type)) return;
                // end if
                PackItem(wearDict[type], 0);
                wearDict[type] = "0";
                SqliteManager.SetWearInfoWithID(roleID, type, wearDict[type]);
            } // end TakeOffEquip

            public EquipInfo GetEquipInfo(string type) {
                if (!wearDict.ContainsKey(type)) {
                    return null;
                } // end if
                return Configs.itemConfig.GetItemInfo(wearDict[type]) as EquipInfo;
            } // end GetItemInfo

            private void WriteGridInfo(int gid, string id, int count) {
                string grade = Configs.itemConfig.GetItemGrade(id);
                SqliteManager.SetPackInfoWithID(roleID, packType, gid, id, grade, count);
            } // end WriteGridInfo
        } // end class EquipPack
    } // end namespace Model
} // end namespace Solider 

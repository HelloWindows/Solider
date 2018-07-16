/*******************************************************************
 * FileName: RolePack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Manager;
using Solider.Interface;
using Solider.Manager;
using System.Collections.Generic;

namespace Solider {
    namespace Model {
        public class RolePack {
            private Dictionary<string, IPack> packDict;

            private static RolePack instance;
            public static RolePack GetInstance(string playerID) {
                if (null == instance) instance = new RolePack(playerID);
                // end if
                return instance;
            } // end GetInstance

            private RolePack(string playerID) {
                packDict = new Dictionary<string, IPack>();

                for (int i = 0; i < ConfigManager.packTypeList.Length; i++) {
                    Pack pack = new Pack(playerID, ConfigManager.packTypeList[i]);
                    packDict.Add(ConfigManager.packTypeList[i], pack);
                } // end for
            } // end PlayerPack

            public void PackItem(string id, int count) {
                IPack pack = GetItemPack(ConfigManager.itemConfig.GetItemType(id));
                if (null == pack) return;
                // end if
                pack.PackItem(id, count);
            } // end PackItems

            public IPack GetItemPack(string name) {
                if (packDict.ContainsKey(name)) return packDict[name];
                // end if
                return null;
            } // end GetItemPack

            private class Pack : IPack {
                private readonly string type;
                private readonly string roleID;
                private string[] idList;
                private int[] countList;

                public Pack(string roleID, string type) {
                    this.type = type;
                    this.roleID = roleID;
                    idList = new string[ConstConfig.GRID_COUNT];
                    countList = new int[ConstConfig.GRID_COUNT];
                    Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
                    SqliteManager.GetPackInfoWithID(roleID, type, ref dict);

                    for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                        int count = 0;
                        if (!dict.ContainsKey(i)) {
                            idList[i] = "0";
                            continue;
                        } // end if
                        idList[i] = dict[i][0];
                        if (ConfigManager.itemConfig.GetItemType(idList[i]) != type) idList[i] = "0";
                        // end if
                        if (int.TryParse(dict[i][1], out count)) countList[i] = count;
                        // end if
                    } // end for
                } // end Pack

                public void PackItem(string itemID, int count) {
                    string type = ConfigManager.itemConfig.GetItemType(itemID);
                    if (this.type != type) return;
                    // end if
                    for (int i = 0; i < idList.Length; i++) {
                        if (idList[i] != "0") continue;
                        // end if
                        idList[i] = itemID;
                        countList[i] += count;
                        WriteGridInfo(i, idList[i], countList[i]);
                        return;
                    } // end for
                } // end PackItem

                public void UseItemWithGid(int gid) {
                    if (gid < 0 || gid >= idList.Length) return;
                    // end if
                    IWearInfo wearinfo = RoleManager.info.GetWearInfo();
                    if (wearinfo.PutOnEquip(idList[gid])) {
                        idList[gid] = "0";
                        countList[gid] = 0;
                        WriteGridInfo(gid, idList[gid], countList[gid]);
                        return;
                    } // end if
                } // end UseItemWithGid

                public ItemInfo GetItemInfoForGrid(int gid) {
                    if (gid < 0 || gid >= idList.Length) return null;
                    // end if
                    return ConfigManager.itemConfig.GetItemInfo(idList[gid]);
                } // end GetItemInfoWithGid

                public int GetCountForGrid(int gid) {
                    if (gid < 0 || gid >= countList.Length) return 0;
                    // end if
                    return countList[gid];
                } // end GetConsumeCountWithGid

                public void ExchangeGridInfoWithGid(int gid, int target) {
                    if (gid < 0 || gid >= idList.Length || target < 0 || target >= idList.Length) return;
                    // end if
                    string tid = idList[gid];
                    int tcount = countList[gid];
                    idList[gid] = idList[target];
                    countList[gid] = countList[target];
                    idList[target] = tid;
                    countList[target] = tcount;
                    WriteGridInfo(gid, idList[gid], countList[gid]);
                    WriteGridInfo(target, idList[target], countList[target]);
                } // end ExchangeGridInfoWithGid

                public void ArrangePack() {
                    Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
                    SqliteManager.GetArrangePackInfo(roleID, type, ref dict);

                    for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                        int count = 0;

                        if (dict.ContainsKey(i)) {
                            idList[i] = dict[i][0];

                            if (int.TryParse(dict[i][1], out count)) {
                                countList[i] = count;
                            } else {
                                countList[i] = 0;
                            } // end if
                        } else {
                            idList[i] = "0";
                            countList[i] = 0;
                        } // end if
                        WriteGridInfo(i, idList[i], countList[i]);
                    } // end for
                } // end ArrangePack

                public void DiscardItem(int gid, int count) {
                    if (gid < 0 || gid >= countList.Length || count < 0) return;
                    // end if
                    int surplus = countList[gid] - count;
                    if (surplus <= 0) {
                        idList[gid] = "0";
                        countList[gid] = 0;
                    } else {
                        countList[gid] = surplus;
                    }// end if
                    WriteGridInfo(gid, idList[gid], countList[gid]);
                } // end DiscardItem

                private void WriteGridInfo(int gid, string id, int count) {
                    string grade = ConfigManager.itemConfig.GetItemGrade(id);
                    SqliteManager.SetPackInfoWithID(roleID, type, gid, id, grade, count);
                } // end WriteGridInfo
            } // end class Pack 
        } // end class RolePack
    } // end namespace Data  
} // end namespace Custom
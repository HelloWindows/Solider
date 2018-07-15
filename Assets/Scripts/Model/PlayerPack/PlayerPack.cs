/*******************************************************************
 * FileName: PlayerPack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Manager;
using Solider.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Model {
        public class PlayerPack {
            private readonly string[] nameList = { "equip", "consume", "stuff" };
            private Dictionary<string, IPack> packDict;

            private static PlayerPack instance;
            public static PlayerPack GetInstance(string playerID) {
                if (null == instance) instance = new PlayerPack(playerID);
                // end if
                return instance;
            } // end GetInstance

            private PlayerPack(string playerID) {
                packDict = new Dictionary<string, IPack>();

                for (int i = 0; i < nameList.Length; i++) {
                    Pack pack = new Pack(playerID, nameList[i]);
                    packDict.Add(nameList[i], pack);
                } // end for
            } // end PlayerPack

            public IPack GetItemPack(string name) {
                if (packDict.ContainsKey(name)) return packDict[name];
                // end if
                return null;
            } // end GetItemPack

            private class Pack : IPack {
                private readonly string type;
                private readonly string playerID;
                private string[] idList;
                private int[] countList;

                public Pack(string playerID, string type) {
                    this.type = type;
                    this.playerID = playerID;
                    idList = new string[ConstConfig.GRID_COUNT];
                    countList = new int[ConstConfig.GRID_COUNT];
                    Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
                    SqliteManager.GetPackInfoWithID(playerID, type, ref dict);

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
                        countList[i] = count;
                        return;
                    } // end for
                } // end PackItem

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
                    SqliteManager.GetArrangePackInfo(playerID, type, ref dict);

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
                    SqliteManager.SetPackInfoWithID(playerID, type, gid, id, grade, count);
                } // end WriteGridInfo
            } // end class Pack 
        } // end class PlayerPack
    } // end namespace Data  
} // end namespace Custom
/*******************************************************************
 * FileName: Pack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config;
using Framework.Config;
using Framework.Manager;
using Solider.Interface;
using Framework.Config.Const;
using System.Collections.Generic;

namespace Solider {
    namespace Model {
        public class Pack : IPack {
            private readonly string roleID;
            private readonly string packType;
            private string[] idList;
            private int[] countList;

            public Pack(string roleID, string packType) {
                this.packType = packType;
                this.roleID = roleID;
                idList = new string[ConstConfig.GRID_COUNT];
                countList = new int[ConstConfig.GRID_COUNT];
                Dictionary<int, string[]> dict;
                SqliteManager.GetPackInfoWithID(roleID, packType, out dict);

                for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                    int count = 0;
                    if (!dict.ContainsKey(i)) {
                        idList[i] = "0";
                        continue;
                    } // end if
                    idList[i] = dict[i][0];
                    if (Configs.itemConfig.GetItemType(idList[i]) != packType) idList[i] = "0";
                    // end if
                    if (int.TryParse(dict[i][1], out count)) countList[i] = count;
                    // end if
                } // end for
            } // end Pack

            public void PackItem(string itemID, int count) {
                string type = Configs.itemConfig.GetItemType(itemID);
                if (packType != type) return;
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
            } // end UseItemWithGid

            public ItemInfo GetItemInfoForGrid(int gid) {
                if (gid < 0 || gid >= idList.Length) return null;
                // end if
                return Configs.itemConfig.GetItemInfo(idList[gid]);
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
                SqliteManager.GetArrangePackInfo(roleID, packType, ref dict);

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
                string grade = Configs.itemConfig.GetItemGrade(id);
                SqliteManager.SetPackInfoWithID(roleID, packType, gid, id, grade, count);
            } // end WriteGridInfo
        } // end class Pack 
    } // end namespace Model
} // end namespace Solider 

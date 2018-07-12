/*******************************************************************
 * FileName: PlayerPack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Manager;
using Solider.Config;
using Solider.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Data {
        public class PlayerPack {
            private string[] equipIDList;
            private string[] consumeIDList;
            private string[] stuffIDList;

            private int[] equipCountList;
            private int[] consumeCountList;
            private int[] stuffCountList;

            public PlayerPack(string playerID) {
                ResolvePackInfo(playerID, "equip", ref equipIDList, ref equipCountList);
                ResolvePackInfo(playerID, "consume", ref consumeIDList, ref consumeCountList);
                ResolvePackInfo(playerID, "stuff", ref stuffIDList, ref stuffCountList);
            } // end PlayerPack

            /// <summary>
            /// 获取对应格子的装备信息
            /// </summary>
            /// <param name="gid"> 格子id </param>
            /// <returns> 装备信息 </returns>
            public EquipInfo GetEquipInfoWithGid(int gid) {
                if (gid < 0 || gid >= equipIDList.Length) return null;
                // end if
                return InstanceMgr.GetConfigManager().GetEquipInfoWithID(equipIDList[gid]);
            } // end GetEquipInfoWithGid

            /// <summary>
            /// 调换两个格子的装备信息
            /// </summary>
            /// <param name="gid"> 格子id </param>
            /// <param name="target"> 目标格子id </param>
            public void ExchangeEquipInfoWithGid(int gid, int target) {
                ExchangeInfo("equip", gid, target, ref equipIDList, ref equipCountList);
            } // end ExchangeInfoWithGid

            private void ExchangeInfo(string type, int gid, int target, ref string[] idList, ref int[] countList) {
                if (gid < 0 || gid >= idList.Length ||
                    target < 0 || target >= idList.Length) return;
                // end if
                string tid = idList[gid];
                int tcount = countList[gid];
                idList[gid] = idList[target];
                countList[gid] = countList[target];
                idList[target] = tid;
                countList[target] = tcount;
                WriteGridInfo(type, gid, idList[gid], countList[gid]);
                WriteGridInfo(type, target, idList[target], countList[target]);
            } // end ExchangeInfo

            private void WriteGridInfo(string type, int gid, string id, int count) {
                string grade = InstanceMgr.GetConfigManager().GetItemGradeWithID(id);
                SqliteManager.SetPackInfoWithID(PlayerManager.playerID, type, gid, id, grade, count);
            } // end WriteGridInfo

            private void ResolvePackInfo(string playerID, string type, ref string[] idList, ref int[] countList) {
                idList = new string[ConstConfig.GRID_COUNT];
                countList = new int[ConstConfig.GRID_COUNT];
                Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
                SqliteManager.GetPackInfoWithID(playerID, type, ref dict);

                for (int i = 0; i < ConstConfig.GRID_COUNT; i++) {
                    int count = 0;

                    if (dict.ContainsKey(i)) {
                        idList[i] = dict[i][0];

                        if (int.TryParse(dict[i][1], out count)) {
                            countList[i] = count;
                        } else {
                            countList[i] = 0;
                        } // end if
                    } // end if
                } // end for
            } // end ResolveInfo
        } // end class PlayerPack 
    } // end namespace Data  
} // end namespace Custom
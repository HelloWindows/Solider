﻿/*******************************************************************
 * FileName: PlayerPack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Manager;
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

            public PlayerPack() {
                ResolveInfo("equit", ref equipIDList, ref equipCountList);
                ResolveInfo("consume", ref equipIDList, ref equipCountList);
                ResolveInfo("stuff", ref equipIDList, ref equipCountList);
            } // end PlayerPack

            private void ResolveInfo(string type, ref string[] idList, ref int[] countList) {
                idList = new string[ConstConfig.GRID_COUNT];
                countList = new int[ConstConfig.GRID_COUNT];
                Dictionary<int, string[]> dict = new Dictionary<int, string[]>();
                SqliteManager.GetPackInfoWithID(InstanceMgr.CurrentID.ToString(), type, ref dict);

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
                    Debug.Log("ID: " + idList[i] + " Count: " + countList[i]);
                } // end for
            } // end ResolveInfo
        } // end class PlayerPack 
    } // end namespace Data  
} // end namespace Custom
/*******************************************************************
 * FileName: PlayerPack.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Data {
        public class PlayerPack {

            private Dictionary<int, string> equipmentPack;
            private Dictionary<int, string> consumablePack;
            private Dictionary<int, string> stuffPack;

            public PlayerPack() {
                equipmentPack = new Dictionary<int, string>();
                consumablePack = new Dictionary<int, string>();
                stuffPack = new Dictionary<int, string>();
                SqliteManager.GetPackInfoWithID(InstanceMgr.CurrentID.ToString(), "equipment", ref equipmentPack);
                SqliteManager.GetPackInfoWithID(InstanceMgr.CurrentID.ToString(), "consumable", ref consumablePack);
                SqliteManager.GetPackInfoWithID(InstanceMgr.CurrentID.ToString(), "stuff", ref stuffPack);
            } // end PlayerPack
        } // end class PlayerPack 
    } // end namespace Data  
} // end namespace Custom
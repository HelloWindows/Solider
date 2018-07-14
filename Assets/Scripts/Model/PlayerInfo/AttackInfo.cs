/*******************************************************************
 * FileName: AttackInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Model {
        public class AttackInfo {
            public int ATK { get; private set; }
            public int MGK { get; private set; }
            public bool iscrit { get; private set; }

            public AttackInfo(AttributeInfo info) {
                iscrit = Random.Range(0, 100f) < info.CRT ? true : false;
                ATK = Random.Range(info.min_ATK, info.max_ATK) * (iscrit ? 2 : 1);
                MGK = Random.Range(info.min_MGK, info.max_MGK) * (iscrit ? 2 : 1);
            } // end AttackInfo
        } // end class AttackInfo
    } // end namespace Model
} // end namespace Solider 

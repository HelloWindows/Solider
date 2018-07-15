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
        namespace Data {
            public class AttackData {
                public string id { get; private set; }
                public int ATK { get; private set; }
                public int MGK { get; private set; }
                public bool iscrit { get; private set; }
                public bool ismiss { get; private set; }

                public AttackData(AttributeData data) {
                    iscrit = Random.Range(0, 100f) < data.CRT ? true : false;
                    ATK = Random.Range(data.NATK, data.XATK) * (iscrit ? 2 : 1);
                    MGK = Random.Range(data.NMGK, data.XMGK) * (iscrit ? 2 : 1);
                } // end AttackInfo
            } // end class AttackData
        } // end namespace Data
    } // end namespace Model
} // end namespace Solider 

/*******************************************************************
 * FileName: TreatData.cs
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
            public class TreatData {
                public int HP { get; private set; }
                public int MP { get; private set; }
                public float HPR { get; private set; }
                public float MPR { get; private set; }
                public float XHPR { get; private set; }
                public float XMPR { get; private set; }

                public TreatData(ConsumeInfo info) {
                    HP = info.HP;
                    MP = info.MP;
                } // end TreatData
            } // end class TreatData
        } // end namespace Data
    } // end namespace Model 
} // end namespace Custom 

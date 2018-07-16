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

                public TreatData() {
                    HP = 0;
                    MP = 0;
                    HPR = 0;
                    MPR = 0;
                    XHPR = 0;
                    XMPR = 0;
                } // end TreatData

                public TreatData(ConsumeInfo info) {
                    HP = info.HP;
                    MP = info.MP;
                } // end TreatData

                /// <summary>
                /// 初始化角色数据
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="init"> 初始数据 </param>
                /// <returns> 结果数据 </returns>
                public static TreatData operator +(TreatData treat, RoleAttribute role) {
                    treat.HP = role.HOT;
                    treat.MP = role.MOT;
                    treat.HPR = 0;
                    treat.MPR = 0;
                    treat.XHPR = 0;
                    treat.XMPR = 0;
                    return treat;
                } // end operator +
            } // end class TreatData
        } // end namespace Data
    } // end namespace Model 
} // end namespace Custom 

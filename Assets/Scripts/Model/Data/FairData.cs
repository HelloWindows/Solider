/*******************************************************************
 * FileName: FairData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Model;
using Solider.Config;

namespace Solider {
    namespace Model {
        namespace Data {
            public class FairData {
                /// <summary>
                /// 恢复 hp
                /// </summary>
                public int HP { get; private set; }
                /// <summary>
                /// 恢复 mp
                /// </summary>
                public int MP { get; private set; }
                /// <summary>
                /// 已损失 hp 百分率
                /// </summary>
                public float HPR { get; private set; }
                /// <summary>
                /// 已损失 mp 百分率
                /// </summary>
                public float MPR { get; private set; }
                /// <summary>
                /// 最大 hp 百分率
                /// </summary>
                public float XHR { get; private set; }
                /// <summary>
                /// 最大 mp 百分率
                /// </summary>
                public float XMR { get; private set; }

                public FairData(ConsumeInfo info) {
                    HP = info.HP;
                    MP = info.MP;
                } // end TreatData

                /// <summary>
                /// 角色自愈数据
                /// </summary>
                /// <param name="role"> 自愈数据 </param>
                /// <param name="init"> 角色数据 </param>
                /// <returns> 自愈数据 </returns>
                public static FairData operator +(FairData treat, CharacterAttribute role) {
                    treat.HP = role.HOT;
                    treat.MP = role.MOT;
                    return treat;
                } // end operator +
            } // end class FairData
        } // end namespace Data
    } // end namespace Model 
} // end namespace Custom 

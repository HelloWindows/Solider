/*******************************************************************
 * FileName: FairData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config;

namespace Solider {
    namespace Character {
        namespace Model {
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
                /// 恢复已损失 hp 百分率
                /// </summary>
                public float HPP { get; private set; }
                /// <summary>
                /// 恢复已损失 mp 百分率
                /// </summary>
                public float MPP { get; private set; }
                /// <summary>
                /// 恢复最大 hp 百分率
                /// </summary>
                public float XHPP { get; private set; }
                /// <summary>
                /// 恢复最大 mp 百分率
                /// </summary>
                public float XMPP { get; private set; }

                public FairData() {
                    HP = 0;
                    MP = 0;
                    HPP = 0;
                    MPP = 0;
                    XHPP = 0;
                    XMPP = 0;
                } // end TreatData

                public FairData(ConsumeInfo info) {
                    HP = info.HP;
                    MP = info.MP;
                } // end TreatData

                /// <summary>
                /// 初始化角色数据
                /// </summary>
                /// <param name="role"> 角色数据 </param>
                /// <param name="init"> 初始数据 </param>
                /// <returns> 结果数据 </returns>
                public static FairData operator +(FairData treat, CharacterAttribute role) {
                    treat.HP = role.HOT;
                    treat.MP = role.MOT;
                    treat.HPP = 0;
                    treat.MPP = 0;
                    treat.XHPP = 0;
                    treat.XMPP = 0;
                    return treat;
                } // end operator +
            } // end class FairData
        } // end namespace Data
    } // end namespace Model 
} // end namespace Custom 

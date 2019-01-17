/*******************************************************************
 * FileName: RealData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using Solider.Config.Interface;
using Solider.ModelData.Interface;

namespace Solider {
    namespace ModelData {
        namespace Data {
            public class RealData : IRealData, IRealDataAction {
                public int HP { get; private set; }
                public int MP { get; private set; }
                public float HPR { get; private set; }
                public float MPR { get; private set; }
                public float XHR { get; private set; }
                public float XMR { get; private set; }
                public bool ismiss { get; private set; }

                /// <summary>
                /// 满 HP 和 MP 的效果
                /// </summary>
                public RealData() {
                    XHR = 100;
                    XMR = 100;
                } // end RealData

                public RealData(IDamageData damage, ICharacterData target) {
                    if (null == damage || null == target) return;
                    // end if
                    HP = MathTool.LimitZero(damage.ATK -  MathTool.Percent(target.DEF, damage.DEFR + 100f)) +
                        MathTool.LimitZero(damage.MGK - MathTool.Percent(target.RGS, damage.RGSR + 100f));
                } // end RealData

                public RealData(IConsumeInfo info) {
                    if (null == info) return;
                    // end if
                    HP = info.HP;
                    MP = info.MP;
                    HPR = info.HPR;
                    MPR = info.MPR;
                    XHR = info.XHR;
                    XMR = info.XMR;
                } // end TreatData

                public void SetSelfTreat(IAttributeData data) {
                    HP = data.HOT;
                    MP = data.MOT;
                    HPR = 0;
                    MPR = 0;
                    XHR = 0;
                    XMR = 0;
                } // end SetSelfTreat
            } // end class RealData
        } // end namespace Data
    } // end namespace ModelData 
} // end namespace Solider 

/*******************************************************************
 * FileName: AttackInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.ModelData.Interface;
using Framework.Tools;

namespace Solider {
    namespace ModelData {
        namespace Data {
            public class AttackData : IAttackData {
                public string id { get; private set; }
                public int ATK { get; private set; }
                public int MGK { get; private set; }
                public float HIT { get; private set; } 
                public bool ismiss { get; private set; }
                public bool iscrit { get; private set; } 

                public AttackData(string id, IAttributeData data) {
                    this.id = id;
                    HIT = data.HIT;
                    iscrit = MathTool.Random(0, 100f) < data.CRT ? true : false;
                    ATK = MathTool.Random(data.NATK, data.XATK) * (iscrit ? 2 : 1);
                    MGK = MathTool.Random(data.NMGK, data.XMGK) * (iscrit ? 2 : 1);
                } // end AttackInfo

                /// <summary>
                /// 计算普通物理攻击
                /// </summary>
                /// <param name="data"> 被攻击者 </param>
                /// <returns> 攻击结果 </returns>
                public IRealData AttackTo(IAttributeData data) {
                    ismiss = MathTool.Random(0, 100f) < data.AVD - HIT;
                    ATK = ismiss ? 0 : MathTool.LimitZero(ATK - data.DEF);
                    MGK = 0;
                    return new RealData(this);
                } // end AttackTo
            } // end class AttackData
        } // end namespace Data
    } // end namespace ModelData
} // end namespace Solider 

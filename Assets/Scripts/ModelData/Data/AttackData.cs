/*******************************************************************
 * FileName: DamageData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.ModelData.Interface;
using Framework.Tools;
using Solider.Character.Interface;

namespace Solider {
    namespace ModelData {
        namespace Data {
            public class DamageData : IDamageData {
                public string hashID { get; private set; }
                public int ATK { get; private set; }
                public int MGK { get; private set; }
                public float HIT { get; private set; } 
                public bool ismiss { get; private set; }
                public bool iscrit { get; private set; }

                public DamageData(ICharacter character) {
                    if (null == character) {
                    } // end if
                    hashID = character.hashID;
                    HIT = character.info.characterData.HIT;
                    iscrit = MathTool.Random(0, 100f) < character.info.characterData.CRT ? true : false;
                    ATK = MathTool.Random(character.info.characterData.NATK, character.info.characterData.XATK) * (iscrit ? 2 : 1);
                    MGK = MathTool.Random(character.info.characterData.NMGK, character.info.characterData.XMGK) * (iscrit ? 2 : 1);
                } // end DamageData

                public DamageData(string hashID, IAttributeData data) {
                    this.hashID = hashID;
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
            } // end class DamageData
        } // end namespace Data
    } // end namespace ModelData
} // end namespace Solider 

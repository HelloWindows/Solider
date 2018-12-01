/*******************************************************************
 * FileName: AttackInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Solider.ModelData.Character;
using Solider.ModelData.Interface;

namespace Solider {
    namespace ModelData {
        namespace Data {
            public class AttackData : IAttackData {
                public string id { get; private set; }
                public int ATK { get; private set; }
                public int MGK { get; private set; }
                public float HIT { get; private set; } // 命中率
                public bool iscrit { get; private set; } // 暴击
                public bool ismiss { get; private set; } // 失误

                public AttackData(string id, IAttributeData data) {
                    this.id = id;
                    HIT = data.HIT;
                    iscrit = Random.Range(0, 100f) < data.CRT ? true : false;
                    ATK = Random.Range(data.NATK, data.XATK) * (iscrit ? 2 : 1);
                    MGK = Random.Range(data.NMGK, data.XMGK) * (iscrit ? 2 : 1);
                } // end AttackInfo

                /// <summary>
                /// 判断攻击是否失误
                /// </summary>
                /// <param name="attack"> 攻击数据 </param>
                /// <param name="cher"> 被攻击的角色 </param>
                /// <returns></returns>
                public static AttackData operator -(AttackData attack, CharacterAttribute cher) {
                    attack.ismiss = Random.Range(0, 100) < (cher.AVD - attack.HIT) ? true : false;
                    // 也可以在这里做吸血处理，添加吸血率属性,计算攻击结果,计算吸血值，根据id传给攻击者。
                    return attack;
                } // end operator -
            } // end class AttackData
        } // end namespace Data
    } // end namespace ModelData
} // end namespace Solider 

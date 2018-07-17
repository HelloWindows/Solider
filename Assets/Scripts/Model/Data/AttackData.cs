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
                public float HIT { get; private set; } // 命中率
                public bool iscrit { get; private set; } // 暴击
                public bool ismiss { get; private set; } // 失误

                public AttackData(AttributeData data) {
                    HIT = data.HIT;
                    iscrit = Random.Range(0, 100f) < data.CRT ? true : false;
                    ATK = Random.Range(data.NATK, data.XATK) * (iscrit ? 2 : 1);
                    MGK = Random.Range(data.NMGK, data.XMGK) * (iscrit ? 2 : 1);
                } // end AttackInfo
                
                /// <summary>
                /// 判断攻击是否失误
                /// </summary>
                /// <param name="attack"> 攻击数据 </param>
                /// <param name="npc"> 被攻击的npc </param>
                /// <returns></returns>
                public static AttackData operator -(AttackData attack, NPCAttribute npc) {
                    attack.ismiss = Random.Range(0, 100) < (npc.AVD - attack.HIT) ? true : false;
                    // 也可以在这里做吸血处理，添加吸血率属性,计算攻击结果,计算吸血值，根据id传给攻击者。我最痛恨吸血这个功能了，完全失去游戏性
                    return attack;
                } // end operator -
            } // end class AttackData
        } // end namespace Data
    } // end namespace Model
} // end namespace Solider 

/*******************************************************************
 * FileName: BuffInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Config {
        public class BuffInfo {
            public bool isDebuff { get; private set; } // 是否是减益 buff (用来判读是否应该被净化)
            public bool isPassive { get; private set; } // 是否是被动 buff (被动技能就是一个buff)
            public bool removable { get; private set; } // 可以被去除 (有些buff可以被净化)
            public int HOT { get; private set; } // hp 恢复
            public int MOT { get; private set; } // mp 恢复
            public int HOTP { get; private set; } // hp 恢复百分百
            public int MOTP { get; private set; } // mp 恢复百分百
            public float ATKP { get; private set; } // 物理攻击百分百
            public float MGKP { get; private set; } // 物理攻击率百分百
            public float DEFP { get; protected set; } // 物理防御百分百
            public float RGSP { get; protected set; } // 魔法防御百分百
            public float ASPP { get; private set; } // 攻速百分百
            public float MSPP { get; private set; } // 移速百分百
            public float HIT { get; private set; } // 命中率
            public float AVD { get; private set; } // 闪避率
            public float CRT { get; private set; } // 暴击率
            public float LOT { get; private set; } // 持续时间
        } // end class BuffInfo
    } // end namespace Config
} // end namespace Custom 

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
            public readonly bool isDebuff; // 是否是减益 buff (用来判读是否应该被净化)
            public readonly bool isPassive; // 是否是被动 buff (被动技能就是一个buff)
            public readonly bool removable; // 可以被去除 (有些buff可以被净化)
            public readonly int HOT; // hp 恢复
            public readonly int MOT; // mp 恢复
            public readonly int HOTP; // hp 恢复百分百
            public readonly int MOTP; // mp 恢复百分百
            public readonly float ATKP; // 物理攻击百分百
            public readonly float MGKP; // 物理攻击率百分百
            public readonly float DEFP; // 物理防御百分百
            public readonly float RGSP; // 魔法防御百分百
            public readonly float ASPP; // 攻速百分百
            public readonly float MSPP; // 移速百分百
            public readonly float HIT; // 命中率
            public readonly float AVD; // 闪避率
            public readonly float CRT; // 暴击率
            public readonly float LOT; // 持续时间
        } // end class BuffInfo
    } // end namespace Config
} // end namespace Custom 

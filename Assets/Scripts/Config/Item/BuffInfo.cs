/*******************************************************************
 * FileName: BuffInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Solider {
    namespace Config {
        public class BuffInfo {
            public readonly bool isDebuff; // 是否是减益 buff (用来判断是否应该被净化)
            public readonly bool isPassive; // 是否是被动 buff (被动技能就是一个buff)
            public readonly bool removable; // 可以被去除 (有些buff可以被净化)
            public readonly float HPR;
            public readonly float MPR;
            public readonly float XHR;
            public readonly float XMR;
            public readonly int ATK;
            public readonly int MGK;
            public readonly float ATKR; // 物理攻击百分百
            public readonly float MGKR; // 物理攻击率百分百
            public readonly float DEFR; // 物理防御百分百
            public readonly float RGSR; // 魔法防御百分百
            public readonly float ASPR; // 攻速百分百
            public readonly float MSPR; // 移速百分百
            public readonly float HIT; // 命中率
            public readonly float AVD; // 闪避率
            public readonly float CRT; // 暴击率
            public readonly float LOT; // 持续时间
        } // end class BuffInfo
    } // end namespace Config
} // end namespace Custom 

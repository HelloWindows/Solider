/*******************************************************************
 * FileName: IBuffInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface IBuffInfo : IIconInfo {
                string buffID { get; } // 相同ID的 buff 只能同时存在一个
                bool isDebuff { get; }  // 是否是减益 buff (用来判断是否应该被净化)
                bool isPassive { get; }  // 是否是被动 buff (被动技能就是一个buff)
                bool removable { get; }  // 可以被去除 (有些buff可以被净化)
                int HOT { get; }
                int MOT { get; }
                float HPR { get; }
                float MPR { get; }
                float XHR { get; }
                float XMR { get; }
                float ATKR { get; }  // 物理攻击百分比
                float MGKR { get; }  // 魔法攻击百分比
                float DEFR { get; }  // 物理防御百分比
                float RGSR { get; }  // 魔法防御百分比
                float ASPR { get; }  // 攻速百分比
                float MSPR { get; }  // 移速百分比
                float HIT { get; }  // 命中率
                float AVD { get; }  // 闪避率
                float CRT { get; }  // 暴击率
                float LOT { get; }  // 持续时间
            } // end interface IBuffInfo
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider
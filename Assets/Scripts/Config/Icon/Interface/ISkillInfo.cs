/*******************************************************************
 * FileName: ISkillInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Solider {
    namespace Config {
        namespace Interface {
            public interface ISkillInfo : IIconInfo {
                bool isBuff { get; } // 判断是否是 buff 技能
                bool isPassive { get; } // 是否是被动技能
                int ATK { get; } // 物理攻击
                int MGK { get; } // 魔法攻击
                float ATKR { get; } // 物理攻击百分比
                float MGKR { get; } // 魔法攻击百分比
                float DEFR { get; } // 忽略物理防御百分比
                float RGSR { get; } // 忽略魔法防御百分比
                float CD { get; } // 冷却时间
                string soundPath { get; }
                IBuffInfo buff { get; } // buff 信息
            } // end interface ISkillInfo
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider
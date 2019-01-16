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
                float CD { get; } // 冷却时间
                string soundPath { get; }
                IBuffInfo buff { get; } // buff 信息
            } // end interface ISkillInfo
        } // end namespace Interface
    } // end namespace IItemInfo 
} // end namespace Solider
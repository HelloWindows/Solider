/*******************************************************************
 * FileName: SkillInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Solider {
    namespace Config {
        public class SkillInfo {
            public bool isBuff { get; private set; } // 判断是否是 buff 技能
            public bool isPassive { get; private set; } // 是否是被动技能
            public int HPP { get; private set; } // hp 恢复百分百
            public int MPP { get; private set; } // mp 恢复百分百
            public float ATKP { get; private set; } // 物理攻击百分百
            public float MGKP { get; private set; } // 物理攻击率百分百
            public float DEFP { get; private set; } // 忽略物理防御百分百
            public float RGSP { get; private set; } // 忽略魔法防御百分百
            public BuffInfo buff { get; private set; } // buff 信息
        } // end class SkillInfo
    } // end namespace Config
} // end namespace Solider 

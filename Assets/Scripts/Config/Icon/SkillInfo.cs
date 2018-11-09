/*******************************************************************
 * FileName: SkillInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

using LitJson;

namespace Solider {
    namespace Config {
        namespace Icon {
            public class SkillInfo : IconInfo {
                public bool isBuff { get; private set; } // 判断是否是 buff 技能
                public bool isPassive { get; private set; } // 是否是被动技能
                public float ATKR { get; private set; } // 物理攻击百分百
                public float MGKR { get; private set; } // 魔法攻击百分百
                public float DEFR { get; private set; } // 忽略物理防御百分百
                public float RGSR { get; private set; } // 忽略魔法防御百分百
                public BuffInfo buff { get; private set; } // buff 信息

                public SkillInfo(JsonData data) {
                    id = (string)data["id"];
                    name = (string)data["name"];
                    spritepath = (string)data["spritepath"];
                    intro = (string)data["intro"];
                    isBuff = (bool)data["buff"];
                    isPassive = (bool)data["passive"];
                    JsonData property = data["property"];
                    ATKR = (float)property["ATKR"];
                    MGKR = (float)property["MGKR"];
                    DEFR = (float)property["DEFR"];
                    RGSR = (float)property["RGSR"];
                    if (isBuff || isPassive) {
                        buff = new BuffInfo(data);
                    } // end if
                } // end SkillInfo
            } // end class SkillInfo
        } // end namespace Icon
    } // end namespace Config
} // end namespace Solider 

/*******************************************************************
 * FileName: SkillInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;
using Solider.Config.Interface;

namespace Solider {
    namespace Config {
        namespace Icon {
            public class SkillInfo : IconInfo, ISkillInfo {
                public bool isBuff { get; private set; } 
                public bool isPassive { get; private set; } 
                public float ATKR { get; private set; } 
                public float MGKR { get; private set; } 
                public float DEFR { get; private set; } 
                public float RGSR { get; private set; } 
                public float CD { get; private set; } 
                public IBuffInfo buff { get; private set; } 

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
                    CD = (float)property["CD"];
                    if (isBuff || isPassive)
                        buff = new BuffInfo(data);
                    else
                        buff = null;
                    // end if
                } // end SkillInfo
            } // end class SkillInfo
        } // end namespace Icon
    } // end namespace Config
} // end namespace Solider 

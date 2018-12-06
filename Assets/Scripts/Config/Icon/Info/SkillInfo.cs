/*******************************************************************
 * FileName: SkillInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Config.Interface;

namespace Solider {
    namespace Config {
        namespace Icon {
            public class SkillInfo : IconInfo, ISkillInfo {
                public bool isBuff { get; private set; } 
                public bool isPassive { get; private set; }
                public int ATK { get; private set; } 
                public int MGK { get; private set; } 
                public float ATKR { get; private set; } 
                public float MGKR { get; private set; } 
                public float DEFR { get; private set; } 
                public float RGSR { get; private set; } 
                public float CD { get; private set; }
                public string soundPath { get; private set; }
                public IBuffInfo buff { get; private set; } 

                public SkillInfo(JsonData data) {
                    id = (string)data["id"];
                    name = (string)data["name"];
                    spritepath = (string)data["spritepath"];
                    intro = (string)data["intro"];
                    isBuff = (bool)data["buff"];
                    isPassive = (bool)data["passive"];
                    JsonData property = data["property"];
                    ATK = JsonTool.GetJsonData_Int(property, "ATK");
                    MGK = JsonTool.GetJsonData_Int(property, "MGK");
                    ATKR = JsonTool.GetJsonData_Float(property, "ATKR");
                    MGKR = JsonTool.GetJsonData_Float(property, "MGKR");
                    DEFR = JsonTool.GetJsonData_Float(property, "DEFR");
                    RGSR = JsonTool.GetJsonData_Float(property, "RGSR");
                    CD = JsonTool.GetJsonData_Float(property, "CD");
                    soundPath = JsonTool.GetJsonData_String(property, "soundPath");
                    buff = null;
                    if (isBuff || isPassive) buff = new BuffInfo(data);
                    // end if
                } // end SkillInfo
            } // end class SkillInfo
        } // end namespace Icon
    } // end namespace Config
} // end namespace Solider 

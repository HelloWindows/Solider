/*******************************************************************
 * FileName: BuffInfo.cs
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
            public class BuffInfo : IconInfo, IBuffInfo {
                public string buffID { get; private set; } 
                public bool isDebuff { get; private set; } 
                public bool isPassive { get; private set; } 
                public bool removable { get; private set; } 
                public int HOT { get; private set; } 
                public int MOT { get; private set; } 
                public float HPR { get; private set; } 
                public float MPR { get; private set; } 
                public float XHR { get; private set; } 
                public float XMR { get; private set; } 
                public float ATKR { get; private set; }  
                public float MGKR { get; private set; }  
                public float DEFR { get; private set; } 
                public float RGSR { get; private set; }  
                public float ASPR { get; private set; }  
                public float MSPR { get; private set; }
                public float HIT { get; private set; }  
                public float AVD { get; private set; }  
                public float CRT { get; private set; }  
                public float LOT { get; private set; }  

                public BuffInfo(JsonData data) {
                    id = (string)data["id"];
                    name = (string)data["name"];
                    spritepath = (string)data["spritepath"];
                    intro = (string)data["intro"];
                    JsonData property = data["buffinfo"];
                    buffID = (string)property["buffID"];
                    isDebuff = (bool)property["isDebuff"];
                    isPassive = (bool)property["isPassive"];
                    removable = (bool)property["removable"];
                    HOT = JsonTool.GetJsonData_Int(property, "HOT");
                    MOT = JsonTool.GetJsonData_Int(property, "MOT");
                    HPR = JsonTool.GetJsonData_Float(property, "HPR");
                    MPR = JsonTool.GetJsonData_Float(property, "MPR");
                    XHR = JsonTool.GetJsonData_Float(property, "XHR");
                    XMR = JsonTool.GetJsonData_Float(property, "XMR");
                    ATKR = JsonTool.GetJsonData_Float(property, "ATKR");
                    MGKR = JsonTool.GetJsonData_Float(property, "MGKR");
                    DEFR = JsonTool.GetJsonData_Float(property, "DEFR");
                    RGSR = JsonTool.GetJsonData_Float(property, "RGSR");
                    ASPR = JsonTool.GetJsonData_Float(property, "ASPR");
                    MSPR = JsonTool.GetJsonData_Float(property, "MSPR");
                    HIT = JsonTool.GetJsonData_Float(property, "HIT");
                    AVD = JsonTool.GetJsonData_Float(property, "AVD");
                    CRT = JsonTool.GetJsonData_Float(property, "CRT");
                    LOT = JsonTool.GetJsonData_Float(property, "LOT");
                } // end BuffInfo
            } // end class BuffInfo
        } // end namespace Icon 
    } // end namespace Config
} // end namespace Custom 

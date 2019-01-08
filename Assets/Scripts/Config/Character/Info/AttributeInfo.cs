/*******************************************************************
 * FileName: AttributeInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using LitJson;
using Solider.Config.Interface;

namespace Solider {
    namespace Config {
        namespace Character {
            public class AttributeInfo : IAttributeInfo {
                public int XHP { get; protected set; }
                public int XMP { get; protected set; }
                public int NATK { get; protected set; }
                public int XATK { get; protected set; }
                public int NMGK { get; protected set; }
                public int XMGK { get; protected set; }
                public int HOT { get; protected set; }
                public int MOT { get; protected set; }
                public int DEF { get; protected set; }
                public int RGS { get; protected set; }
                public float ASP { get; protected set; }
                public float MSP { get; protected set; }
                public float HIT { get; protected set; }
                public float AVD { get; protected set; }
                public float CRT { get; protected set; }

                public AttributeInfo(JsonData data) {
                    XHP = JsonTool.GetJsonData_Int(data, "XHP");
                    XMP = JsonTool.GetJsonData_Int(data, "XMP");
                    HOT = JsonTool.GetJsonData_Int(data, "HOT");
                    NATK = JsonTool.GetJsonData_Int(data, "NATK");
                    XATK = JsonTool.GetJsonData_Int(data, "XATK");
                    NMGK = JsonTool.GetJsonData_Int(data, "NMGK");
                    XMGK = JsonTool.GetJsonData_Int(data, "XMGK");
                    DEF = JsonTool.GetJsonData_Int(data, "DEF");
                    RGS = JsonTool.GetJsonData_Int(data, "RGS");

                    ASP = JsonTool.GetJsonData_Float(data, "ASP");
                    MSP = JsonTool.GetJsonData_Float(data, "MSP");
                    HIT = JsonTool.GetJsonData_Float(data, "HIT");
                    AVD = JsonTool.GetJsonData_Float(data, "AVD");
                    CRT = JsonTool.GetJsonData_Float(data, "CRT");
                } // end AttributeInfo
            } // end class AttributeInfo
        } // end namespace Character
    } // end namespace Config
} // end namespace Solider 

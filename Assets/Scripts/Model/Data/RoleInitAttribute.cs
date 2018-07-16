/*******************************************************************
 * FileName: RoleInitAttribute.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using System.Collections.Generic;

namespace Solider {
    namespace Model {
        namespace Data {
            public class RoleInitAttribute : AttributeData {

                public RoleInitAttribute(string roleID) {
                    Dictionary<string, float> dict = new Dictionary<string, float>();
                    SqliteManager.GetRoleInfoWithID(roleID, ref dict);
                    XHP = (int)dict["xhp"];
                    XMP = (int)dict["xmp"];
                    NATK = (int)dict["natk"];
                    XATK = (int)dict["xatk"];
                    NMGK = (int)dict["nmgk"];
                    XMGK = (int)dict["xmgk"];
                    HOT = (int)dict["hot"];
                    MOT = (int)dict["mot"];
                    DEF = (int)dict["def"];
                    RGS = (int)dict["rgs"];
                    ASP = dict["asp"];
                    MSP = dict["msp"];
                    CRT = dict["crt"];
                } // end RoleInitAttribute
            } // end class RoleInitAttribute
        } // end namespace Data 
    } // end namespace Model
} // end namespace Custom 

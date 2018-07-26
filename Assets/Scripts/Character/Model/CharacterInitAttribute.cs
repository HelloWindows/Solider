/*******************************************************************
 * FileName: CharacterInitAttribute.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Solider.Model.Data;
using System.Collections.Generic;

namespace Solider {
    namespace Character {
        namespace Model {
            public class CharacterInitAttribute : AttributeData {

                public CharacterInitAttribute(string charID) {
                    Dictionary<string, float> dict = new Dictionary<string, float>();
                    SqliteManager.GetRoleInfoWithID(charID, ref dict);
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
            } // end class CharacterInitAttribute
        } // end namespace Data 
    } // end namespace Model
} // end namespace Custom 

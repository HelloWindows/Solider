/*******************************************************************
 * FileName: AttributeData.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Model {
        namespace Data {
            public abstract class AttributeData {
                public string name { get; protected set; }
                public int HP { get; protected set; }
                public int XHP { get; protected set; }
                public int MP { get; protected set; }
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
                public float CRT { get; protected set; }
            } // end class AttributeData
        } // end namespace Data
    } // end namespace Model
} // end namespace Solider 

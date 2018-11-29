/*******************************************************************
 * FileName: IconInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;

namespace Solider {
    namespace Config {
        namespace Icon {
            public abstract class IconInfo : IIconInfo {
                public string id { get; protected set; }
                public string name { get; protected set; }
                public string spritepath { get; protected set; }
                public string intro { get; protected set; }
            } // end class IconInfo
        } // end namespace Icon
    } // end Interface
} // end namespace Solider 

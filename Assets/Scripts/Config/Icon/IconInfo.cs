/*******************************************************************
 * FileName: IconInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Text;

namespace Solider {
    namespace Config {
        namespace Icon {
            public abstract class IconInfo {
                protected static readonly StringBuilder infoBuilder = new StringBuilder();
                public string id { get; protected set; }
                public string name { get; protected set; }
                public string spritepath { get; protected set; }
                public string intro { get; protected set; }

                protected void AppendValue(string prefix, float value) {
                    if (0 == value) return;
                    // end if
                    infoBuilder.Append(prefix);
                    infoBuilder.Append(value);
                    infoBuilder.Append('\n');
                } // end AppendValue
            } // end class IconInfo
        } // end namespace Icon
    } // end Interface
} // end namespace Solider 

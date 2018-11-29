/*******************************************************************
 * FileName: ItemInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Config.Interface;
using System.Text;

namespace Solider {
    namespace Config {
        namespace Item {
            public abstract class ItemInfo : IItemInfo {
                protected static readonly StringBuilder infoBuilder = new StringBuilder();
                public string id { get; protected set; }
                public string name { get; protected set; }
                public string grade { get; protected set; }
                public int maximum { get; protected set; }
                public string spritepath { get; protected set; }
                public string intro { get; protected set; }

                protected void AppendValue(string prefix, float value) {
                    if (0 == value) return;
                    // end if
                    infoBuilder.Append(prefix);
                    infoBuilder.Append(value);
                    infoBuilder.Append('\n');
                } // end AppendValue

                protected void AppendValue(string prefix, float value, string suffix) {
                    if (0 == value) return;
                    // end if
                    infoBuilder.Append(prefix);
                    infoBuilder.Append(value);
                    infoBuilder.Append(suffix);
                    infoBuilder.Append('\n');
                } // end AppendValue
            } // end class ItemInfo
        } // end namespace Item
    } // end namespace Config
} // end namespace Solider 

/*******************************************************************
 * FileName: InfoString.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Text;

namespace Solider {
    namespace Config {
        public abstract class InfoString {
            protected static readonly StringBuilder infoBuilder = new StringBuilder();

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
        } // end class InfoString
    } // end namespace Config
} // end namespace Solider 

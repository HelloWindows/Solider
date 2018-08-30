/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Config {
        public class FontConfig {
            private static Dictionary<string, Font> fontDict;

            public static Dictionary<string, Font> FontDict {
                get {
                    if (null == fontDict) {
                        fontDict = new Dictionary<string, Font>(); 
                        DebugTool.CheckNullDictionary(fontDict);
                    } // end if
                    return fontDict;
                } // end get
            } // end FontDict
        } // end class FontConfig
    } // end namespace Config
} // end namespace HiiGo
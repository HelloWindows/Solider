/*******************************************************************
 * FileName: ButtonConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Config {
        public class ButtonConfig {
            private static Dictionary<string, Sprite> btnSpriteDict;
            public static Dictionary<string, Sprite> BtnSpriteDict {
                get {
                    if (null == btnSpriteDict) {
                        btnSpriteDict = new Dictionary<string, Sprite>();
                        DebugTool.CheckNullDictionary(btnSpriteDict);
                    } // end if
                    return btnSpriteDict;
                } // end get
            } // end BtnSpriteDict
        } // end class ButtonConfig
    } // end namespace Config
} // end namespace Framework
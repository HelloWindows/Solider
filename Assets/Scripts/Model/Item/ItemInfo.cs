﻿/*******************************************************************
 * FileName: ItemInfo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Solider {
    namespace Model {
        public abstract class ItemInfo {
            protected static readonly StringBuilder infoBuilder = new StringBuilder();
            public string id { get; protected set; }
            public string name { get; protected set; }
            public string grade { get; protected set; }
            public string spritepath { get; protected set; }
            public string intro { get; protected set; }

            protected void AppendValue(string prefix, float value) {
                if (0 == value) return;
                // end if
                infoBuilder.Append(prefix);
                infoBuilder.Append(value);
                infoBuilder.Append('\n');
            } // end AppendValue
        } // end class ItemInfo
    } // end Interface
} // end namespace Custom 

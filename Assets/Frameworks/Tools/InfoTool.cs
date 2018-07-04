/*******************************************************************
 * FileName: InfoTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Tools {
        public class InfoTool {
            
            public Hashtable InfoTable { get; private set; }

            public InfoTool() {
                InfoTable = new Hashtable();
            } // end InfoTool

        } // end class InfoTool 
    } // end namespace Tools
} // end namespace Framework
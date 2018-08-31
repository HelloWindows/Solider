﻿/*******************************************************************
 * FileName: PathConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System.Collections.Generic;

namespace Framework {
    namespace Config {
        public abstract class PathConfig {
            protected readonly Dictionary<string, string> pathDict;

            protected PathConfig() {
                pathDict = new Dictionary<string, string>();
            } // end PrefabConfig

            public string GetPath(string name) {
                if (pathDict.ContainsKey(name)) return pathDict[name];
                // end if
                DebugTool.ThrowException("PathConfig GetPath name: " + name + " is don't config!");
                return null;
            } // end GetPath
        } // end class PathConfig
    } // end namespace Config 
} // end namespace Framework 
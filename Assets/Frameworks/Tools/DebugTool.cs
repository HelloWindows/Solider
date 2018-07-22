/*******************************************************************
 * FileName: DebugTools.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2017-xxxx 
 *******************************************************************/
using System;
using System.Collections.Generic;

namespace Framework {
    namespace Tools {
        public static class DebugTool {

            public static void CheckNullDictionary<T, V>(Dictionary<T, V> dict) {

                foreach (KeyValuePair<T, V> pair in dict) {

                    if (null == pair.Value) {  
                        throw new Exception("CheckNullDictionary have null! Key: " + pair.Key.ToString());
                    } // end if
                } // end foreach
            } // end CheckNullDictionary

            public static void CheckNullList<T>(List<T> list) {

                foreach (T item in list)
                    if(null == item) throw new Exception("CheckNullList have null item!");
            } // end CheckNullList
        } // end class DebugTools
    } // end namespace Tools
} // end namespace Framework

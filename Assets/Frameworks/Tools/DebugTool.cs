/*******************************************************************
 * FileName: DebugTools.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2017-xxxx 
 *******************************************************************/
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Tools {
            public class DebugTool {

             public static void Log(string msg) {
#if _DEBUG
                Debug.Log(msg);
#endif
             } // end Log

            public static void LogError(string error) {
#if _DEBUG
                Debug.LogError(error);
#endif
            } // end LogError

            public static void LogWarning(string warning) {
#if _DEBUG
                Debug.LogError(warning);
#endif
            } // end LogWarning

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
} // end namespace Custem

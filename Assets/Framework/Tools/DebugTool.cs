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
            /// <summary>
            /// 检测对象是否为 null,为 null 返回 true, 否则返回 false 
            /// </summary>
            /// <typeparam name="T"> 对象类型 </typeparam>
            /// <param name="obj"> 对象 </param>
            /// <param name="errorMsg"> 错误信息 </param>
            /// <returns></returns>
            public static bool CheckNullObject<T>(T obj) {
#if __MY_DEBUG__
                if (null == obj) throw new Exception("CheckNullObject obj is null!");
                // end if
#endif
                return null == obj;
            } // end CheckNullObject

            public static void LogError(string errorMsg) {
#if __MY_DEBUG__
                UnityEngine.Debug.LogError(errorMsg);
#endif
            } // end LogError

            public static void LoaWarning(string warningMsg) {
#if __MY_DEBUG__
                UnityEngine.Debug.LogWarning(warningMsg);
#endif
            } // end LoaWarning

            public static void CheckNullDictionary<T, V>(Dictionary<T, V> dict) {
#if __MY_DEBUG__
                foreach (KeyValuePair<T, V> pair in dict) {
                    if (null == pair.Value) throw new Exception("CheckNullDictionary have null! Key: " + pair.Key.ToString());
                    // end if
                } // end foreach
#endif
            } // end CheckNullDictionary

            public static void CheckNullList<T>(List<T> list) {
#if __MY_DEBUG__
                foreach (T item in list) {
                    if (null == item) throw new Exception("CheckNullList have null item!");
                    // end if
                } // end foreach
#endif
            } // end CheckNullList
        } // end class DebugTools
    } // end namespace Tools
} // end namespace Framework

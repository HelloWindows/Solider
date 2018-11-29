/*******************************************************************
 * FileName: JsonTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using LitJson;

namespace Framework {
    namespace Tools {
        public static class JsonTool {
            public static int TryGetJsonData_Int(JsonData data, string key) {
                try {
                    return (int)data[key];
                } catch {
                    return 0;
                } // end try
            } // end  TryGetJsonData_Int

            public static float TryGetJsonData_Float(JsonData data, string key) {
                try {
                    return (float)data[key];
                } catch {
                    return 0;
                } // end try
            } // end  TryGetJsonData_Float

            public static string TryGetJsonData_String(JsonData data, string key) {
                try {
                    return (string)data[key];
                } catch {
                    return null;
                } // end try
            } // end  TryGetJsonData_String
        } // end class JsonTool 
    } // end namespace Tools
} // end namespace Framework
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
            public static int GetJsonData_Int(JsonData data, string key) {
                try {
                    return (int)data[key];
                } catch {
                    return 0;
                } // end try
            } // end  GetJsonData_Int

            public static float GetJsonData_Float(JsonData data, string key) {
                try {
                    return System.Convert.ToSingle((double)data[key]);
                } catch {
                    return 0;
                } // end try
            } // end  GetJsonData_Float

            public static string GetJsonData_String(JsonData data, string key) {
                try {
                    return (string)data[key];
                } catch {
                    return "";
                } // end try
            } // end GetJsonData_String
        } // end class JsonTool 
    } // end namespace Tools
} // end namespace Framework
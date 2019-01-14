/*******************************************************************
 * FileName: EditorTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using System.IO;
using System.Security.Cryptography;
using UnityEditor;

namespace CustomEditor {
	public static class EditorTool {
        /// <summary>
        /// 过去目标平台
        /// </summary>
        /// <returns> 目标平台 </returns>
        public static BuildTarget GetBuildTarget() {
            BuildTarget target = BuildTarget.WebGL;
#if UNITY_STANDALONE
            target = BuildTarget.StandaloneWindows;
#elif UNITY_IPHONE
			target = BuildTarget.iPhone;
#elif UNITY_ANDROID
            target = BuildTarget.Android;
#endif
            return target;
        } // end GetBuildTarget

        /// <summary>
        /// 获取文件 MD5
        /// </summary>
        /// <param name="filePath"> 文件路径 </param>
        /// <returns> MD5 获取失败返回 null </returns>
        public static string GetMD5Hash(string filePath) {
            if (string.IsNullOrEmpty(filePath)) {
                return null;
            } // end if
            MD5 md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(File.ReadAllBytes(filePath))).Replace("-", "").ToLower();
        } // end GetMD5Hash
    } // end class EditorTool 
} // end namespace CustomEditor
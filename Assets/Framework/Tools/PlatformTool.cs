/*******************************************************************
 * FileName: PlatformManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
namespace Framework {
    namespace Tools {
        public static class PlatformTool {
            public static string GetStreamingAssetsPath(string path) {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_IPHONE
                path = Application.streamingAssetsPath + "/" + path;
#elif UNITY_ANDROID
                path = Application.dataPath + "!assets" + "/" + path;	  
#endif
                return path;
            } // end GetStreamingAssetsPath

            public static string GetPersistentDataPath(string path) {
#if UNITY_EDITOR
                return @"F:\PersistentDataPath\" + path;
#else
                return Application.persistentDataPath + "/" + path;
#endif
            } // end GetPersistentDataPath

            public static string GetSqliteDatabasePath(string path) {
#if UNITY_EDITOR
                path = "data source=" + path;
#elif UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
                path = @"Data Source=" + Application.dataPath + "/" + path; 
#elif UNITY_ANDROID
                path = "URI=file:" + Application.persistentDataPath + "/" + path;	    
#elif UNITY_IPHONE
                path = @"Data Source=" + Application.persistentDataPath + "/" + path;	    
#endif
                return path;
            } // end GetSqliteDatabasePath

            /// <summary>
            /// 同步加载 StreamingAssets 里面的 AssetBundle
            /// </summary>
            /// <param name="assetbundle"> assetbundle 名字 </param>
            /// <returns> 加载完成的 AssetBundle </returns>
            public static AssetBundle LoadFromStreamingAssets(string assetbundle) {
                string path = GetStreamingAssetsPath(assetbundle);
                return AssetBundle.LoadFromFile(path);
            } // end LoadFromStreamingAssetsPath

            /// <summary>
            /// 同步加载 PersistantDataPath 里面的 AssetBundle
            /// </summary>
            /// <param name="assetbundle"> assetbundle 名字 </param>
            /// <returns></returns>
            public static AssetBundle LoadFromPersistantDataPath(string assetbundle) {
                return AssetBundle.LoadFromFile(GetPersistentDataPath(assetbundle));
            } // end LoadFromPersistantDataPath
        } // end class PlatformTool 
    } // end namespace Tools
} // end namespace Framework
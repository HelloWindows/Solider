/*******************************************************************
 * FileName: SpritePacker.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Custom {
	public class SpritePacker {

        [MenuItem("MyMenu/AtlasMaker")]
        static private void MakeAtlas() {
            string spriteDir = Application.dataPath + "/Resources/Sprite";
            if (!Directory.Exists(spriteDir)) {
                Directory.CreateDirectory(spriteDir);
            }

            DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/Atlas");
            foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
                foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories)) {
                    string allPath = pngFile.FullName;
                    string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                    GameObject go = new GameObject(sprite.name);
                    go.AddComponent<SpriteRenderer>().sprite = sprite;
                    allPath = spriteDir + "/" + sprite.name + ".prefab";
                    string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
                    PrefabUtility.CreatePrefab(prefabPath, go);
                    Object.DestroyImmediate(go);
                }
            }
        }
        [MenuItem("MyMenu/Build Assetbundle")]
        private static void BuildAssetBundle() {
            string dir = Application.dataPath + "/StreamingAssets";

            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }
            DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/Atlas");
            foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories())
            {
                List<Sprite> assets = new List<Sprite>();
                string path = dir + "/" + dirInfo.Name + ".assetbundle";
                foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories))
                {
                    string allPath = pngFile.FullName;
                    string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                    assets.Add(AssetDatabase.LoadAssetAtPath<Sprite>(assetPath));
                }
                if (BuildPipeline.BuildAssetBundle(null, assets.ToArray(), path, BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.CollectDependencies, GetBuildTarget()))
                {
                }
            }
        }
        static private BuildTarget GetBuildTarget()
        {
            BuildTarget target = BuildTarget.WebGL;
#if UNITY_STANDALONE
            target = BuildTarget.StandaloneWindows;
#elif UNITY_IPHONE
			target = BuildTarget.iPhone;
#elif UNITY_ANDROID
			target = BuildTarget.Android;
#endif
            return target;
        }
    } // end class SpritePacker
} // end namespace Custom 

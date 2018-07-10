/*******************************************************************
 * FileName: BuildAllAssetBundles.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MyEdior {
	public class ExportAssetBundles {
        [MenuItem("Custom Editor/Build AssetBundles")]
        static void BuildAllAssetBundles() {
            BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        } // end BuildAllAssetBundles
    } // end class ExportAssetBundles 
} // end namespace Custom
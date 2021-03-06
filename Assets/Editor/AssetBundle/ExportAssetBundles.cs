﻿/*******************************************************************
 * FileName: BuildAllAssetBundles.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEditor;

namespace CustomEditor {
	public class ExportAssetBundles {
        [MenuItem("Custom Editor/Asset Bundle/Build AssetBundles", false, 30)]
        static void BuildAllAssetBundles() {
            BuildPipeline.BuildAssetBundles("Assets/StreamingAssets",
                BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.DeterministicAssetBundle, 
                EditorTool.GetBuildTarget());
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        } // end BuildAllAssetBundles
    } // end class ExportAssetBundles 
} // end namespace CustomEditor
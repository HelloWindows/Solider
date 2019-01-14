/*******************************************************************
 * FileName: TextureAndModel.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
namespace CustomEditor {
	public class TextureAndModel {
        [MenuItem("Custom Editor/Report/RepeatedTextureAndModel", false, 10)]
        private static void RepeatedTextureAndModel() {
            Dictionary<string, string> md5Dict = new Dictionary<string, string>();
            string[] paths = AssetDatabase.FindAssets("t:prefab", new string[] { "Assets/Prefab" });
            foreach (string prefabGuid in paths) {
                string prefabAssetPath = AssetDatabase.GUIDToAssetPath(prefabGuid);
                string[] depend = AssetDatabase.GetDependencies(prefabAssetPath, true);
                for (int i = 0; i < depend.Length; i++) {
                    string assetPath = depend[i];
                    AssetImporter importer = AssetImporter.GetAtPath(assetPath);
                    if (importer is TextureImporter || importer is ModelImporter) {
                        string md5 = EditorTool.GetMD5Hash(Path.Combine(Directory.GetCurrentDirectory(), assetPath));
                        string path;
                        if (false == md5Dict.TryGetValue(md5, out path)) {
                            md5Dict[md5] = assetPath;
                        } else {
                            if (path != assetPath) {
                                Debug.LogFormat("{0}, {1} resource is repeated!", path, assetPath);
                            } // end if
                        } // end if
                    } // end if
                } // end for
            } // end foreach
        } // end RepeatedTextureAndModel
    } // end class TextureAndModel 
} // end namespace CustomEditor
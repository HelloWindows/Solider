/*******************************************************************
 * FileName: FindReferences.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Text.RegularExpressions;

namespace CustomEditor {
	public class FindReferences {
        [MenuItem("Assets/Find References In Project", true, 29)]
        private static bool VFind() {
            return false == string.IsNullOrEmpty(AssetDatabase.GetAssetPath(Selection.activeObject));
        } // end VFind

        /// <summary>
        /// 查找选中的资源，被哪些资源引用了
        /// 需要 在 Ediot Setting 中设置 Asset Serialization 为 Force Text
        /// </summary>
        [MenuItem("Assets/Find References In Project", false, 29)]
        private static void Find() {
            Dictionary<string, string> guidDics = new Dictionary<string, string>();
            foreach (Object obj in Selection.objects) {
                string path = AssetDatabase.GetAssetPath(obj);
                if (string.IsNullOrEmpty(path)) continue;
                // end if
                string guid = AssetDatabase.AssetPathToGUID(path);
                if (guidDics.ContainsKey(guid)) continue;
                // end if
                guidDics[guid] = obj.name;
            } // end foreach
            if (guidDics.Count <= 0) return;
            // end if
            List<string> withoutExtensions = new List<string>() { ".prefab", ".unity", ".mat", ".asset" };
            string[] files = Directory.GetFiles(Application.dataPath, "*.*", SearchOption.AllDirectories)
                .Where(s => withoutExtensions.Contains(Path.GetExtension(s).ToLower())).ToArray();
            for (int i = 0; i < files.Length; i++) {
                string file = files[i];
                if (i % 20 == 0) {
                    if (EditorUtility.DisplayCancelableProgressBar("Refernces finding...", file, (float)i / files.Length)) break;
                    // end if
                } // end if
                foreach (KeyValuePair<string, string> guidItem in guidDics) {
                    if (false == Regex.IsMatch(File.ReadAllText(file), guidItem.Key)) continue;
                    // end if
                    Debug.Log(string.Format("name: {0} file: {1}", guidItem.Value, file), AssetDatabase.LoadAssetAtPath<Object>(GetRelativeAssetsPath(file)));
                } // end foreach
            } // end for
            EditorUtility.ClearProgressBar();
            Debug.Log("Matching end!");
        } // end Find

        private static string GetRelativeAssetsPath(string path) {
            return "Assets" + Path.GetFullPath(path).Replace(Path.GetFullPath(Application.dataPath), "").Replace("\\", "/");
        } // end GetRelativeAssetsPath
    } // end class FindReferences 
} // end namespace CustomEditor
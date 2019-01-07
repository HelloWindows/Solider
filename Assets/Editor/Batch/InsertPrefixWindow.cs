﻿/*******************************************************************
 * FileName: BatchFileNameWindow.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CustomEditor {
	public class BatchFileNameWindow : EditorWindow {
        [MenuItem("Custom Editor/Window/InsertPrefix", false, 1000)]
        private static void Init() {
            BatchFileNameWindow window = GetWindow<BatchFileNameWindow>();
            window.titleContent = new GUIContent("InsertPrefix");
            window.Show();
        } // end Init

        private string prefix;

        private void OnGUI() {
            prefix = EditorGUILayout.TextField(new GUIContent("Please input prefix!"), prefix);
            if (GUILayout.Button("Comfirm")) InsertPrefix();
            // end if
        } // end OnGUI

        private void InsertPrefix() {
            if (string.IsNullOrEmpty(prefix)) {
                Debug.Log("Please input prefix!");
                return;
            } // end if
            if (Selection.objects == null || Selection.objects.Length == 0) {
                Debug.LogWarning("Please select files that need insert");
                return;
            } // end if
            foreach (Object obj in Selection.objects) {
                string path = AssetDatabase.GetAssetPath(obj);
                int index = path.LastIndexOf('/') + 1;
                string name = path.Substring(index, path.Length - index);
                name = name.Substring(0, name.LastIndexOf('.'));
                string info = AssetDatabase.RenameAsset(path, prefix + name);
                if (string.IsNullOrEmpty(info)) continue;
                // end if
                Debug.LogWarning(info);
            } // end foreach
        } // end InsertPrefixToChilds
    } // end class BatchFileNameWindow 
} // end namespace CustomEditor
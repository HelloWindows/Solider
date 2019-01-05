/*******************************************************************
 * FileName: ModifyAssetBundleNameWindow.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomEditor {
	public class ModifyAssetBundleNameWindow : EditorWindow {
        [MenuItem("Custom Editor/Window/ModifyAssetBundleName", false, 1000)]
        private static void Init() {
            ModifyAssetBundleNameWindow window = GetWindow<ModifyAssetBundleNameWindow>();
            window.titleContent = new GUIContent("ModifyAssetBundleName");
            window.Show();
        } // end Init

        private string abName;
        private string variant;
        private string selectedDirPath;
        private string comfirmClear;

        private void OnGUI() {
            if (false == string.IsNullOrEmpty(abName)) {
                EditorGUILayout.LabelField(abName + ".unity3d");
            } else {
                EditorGUILayout.LabelField("");
            } // end if       
            abName = EditorGUILayout.TextField(new GUIContent("Assetbundle name:"), string.IsNullOrEmpty(abName) ? "" : abName.ToLower());
            variant = EditorGUILayout.TextField(new GUIContent("Assetbundle variant:"), variant);
            if (GUILayout.Button("Modify for files")) {
                ModifyAssetBundleNameForFiles();
            } // end if
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("directory path:", selectedDirPath);
            if (GUILayout.Button("Browse")) {
                OpenFolder();
            } // end if
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Modify for directory")) {
                ModifyAssetBundleNameForDirectory();
            } // end if
            if (GUILayout.Button("Remove unused names")) {
                AssetDatabase.RemoveUnusedAssetBundleNames();
            } // end if
            comfirmClear = EditorGUILayout.TextField(new GUIContent("Comfirm clear:"), comfirmClear);
            if (GUILayout.Button("Remove all assetbundle names")) {
                ClearAllAssetBundlesName();
            } // end if
        } // end OnGUI

        private void OpenFolder() {
            string path = EditorUtility.OpenFolderPanel("selecte directory", "", "");
            if (string.IsNullOrEmpty(path)) return;
            // end if
            if (!path.Contains(Application.dataPath)) {
                Debug.LogWarning("directory is don't at current project");
                return;
            } // end if
            if (path.Length != 0) {
                int firstindex = path.IndexOf("Assets");
                selectedDirPath = path.Substring(firstindex) + "/";
                EditorUtility.FocusProjectWindow();
            } // end if
        } // end OpenFolder

        private void ModifyAssetBundleNameForFiles() {
            if (string.IsNullOrEmpty(abName)) {
                Debug.LogWarning("Please input Assetbundle name!");
                return;
            } // end if
            if (Selection.objects == null || Selection.objects.Length == 0) {
                Debug.LogWarning("Please select files that need modify");
                return;
            } // end if
            foreach (Object obj in Selection.objects) {
                AssetImporter assetImporter = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(obj));
                assetImporter.SetAssetBundleNameAndVariant(abName + ".unity3d", variant);
            } // end foreach
            AssetDatabase.Refresh();
        } // end ModifyAssetBundleNameForFiles

        private void ModifyAssetBundleNameForDirectory() {
            if (string.IsNullOrEmpty(abName)) {
                Debug.LogWarning("Please input Assetbundle name!");
                return;
            } // end if
            if (false == Directory.Exists(selectedDirPath)) {
                Debug.LogWarning("selectedDirPath is don't exsit! path:" + selectedDirPath);
                return;
            } // end if
            DirectoryInfo rootDirInfo = new DirectoryInfo(selectedDirPath);
            foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
                foreach (FileInfo fileInfo in dirInfo.GetFiles("*", SearchOption.AllDirectories)) {
                    if (fileInfo.Name.EndsWith(".meta")) continue;
                    // end if                   
                    AssetImporter assetImporter = AssetImporter.GetAtPath(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")));
                    assetImporter.SetAssetBundleNameAndVariant(abName + ".unity3d", variant);
                } // end foreach
            } // end foreach
        } // end ModifyAssetBundleNameForDirectory

        private void ClearAllAssetBundlesName() {
            if (string.IsNullOrEmpty(comfirmClear) || false == comfirmClear.Equals("clear")) {
                Debug.LogWarning("Clear all assetbundle name need input \"clear\" to confirm");
                return;
            } // end if
            int length = AssetDatabase.GetAllAssetBundleNames().Length;
            string[] oldAssetBundleNames = new string[length];
            for (int i = 0; i < length; i++) {
                oldAssetBundleNames[i] = AssetDatabase.GetAllAssetBundleNames()[i];
            } // end for
            for (int i = 0; i < oldAssetBundleNames.Length; i++) {
                AssetDatabase.RemoveAssetBundleName(oldAssetBundleNames[i], true);
            } // end for
        } // end ClearAllAssetBundlesName
    } // end class ModifyAssetBundleNameWindow
} // end namespace CustomEditor

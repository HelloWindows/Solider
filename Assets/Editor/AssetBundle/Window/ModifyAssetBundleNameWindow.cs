/*******************************************************************
 * FileName: ModifyAssetBundleNameWindow.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomEditor {
	public class ModifyAssetBundleNameWindow : EditorWindow {
        [MenuItem("Custom Editor/Asset Bundle/Window/ModifyAssetBundleName", false, 100)]
        private static void Init() {
            ModifyAssetBundleNameWindow window = GetWindow<ModifyAssetBundleNameWindow>();
            window.titleContent = new GUIContent("ModifyAssetBundleName");
            window.Show();
        } // end Init

        private string abName;
        private string variant;
        private string selectedDirPath;
        private string browsedDirPath;
        private string comfirmClear;
        private string[] nameOptions;
        private string[] variantOptions;
        private int index;

        private void InitNameOptions() {
            string[] names = AssetDatabase.GetAllAssetBundleNames();
            int length = null == names ? 0 : names.Length;
            nameOptions = new string[length + 1];
            nameOptions[0] = "None";
            for (int i = 0; i < length; i++) {
                nameOptions[i + 1] = names[i];
            } // end for
        } // end if

        private void OnEnable() {
            InitNameOptions();
        } // end OnEnable

        private void OnGUI() {
            EditorGUILayout.BeginHorizontal();
            index = EditorGUILayout.Popup("Assetbundle", index, nameOptions);
            abName = index == 0 ? string.Empty : nameOptions[index];
            variant = EditorGUILayout.TextField(new GUIContent("variant"), string.IsNullOrEmpty(variant) ? "" : variant.ToLower());
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Name:", abName);
            EditorGUILayout.LabelField("variant:", variant);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Refresh")) {
                RefreshSelectedDirectoryPath();
            } // end if
            EditorGUILayout.LabelField("selected directory path:", selectedDirPath);
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("Modify for selected single directory")) {
                if (string.IsNullOrEmpty(abName)) {
                    Debug.LogWarning("Please select Assetbundle name!");
                    return;
                } // end if
                RefreshSelectedDirectoryPath();
                ModifyAssetBundleNameForDirectory(selectedDirPath);
            } // end if
            if (GUILayout.Button("Remove unused names")) {
                AssetDatabase.RemoveUnusedAssetBundleNames();
                InitNameOptions();
            } // end if
            comfirmClear = EditorGUILayout.TextField(new GUIContent("Comfirm clear:"), comfirmClear);
            if (GUILayout.Button("Remove all assetbundle names")) {
                ClearAllAssetBundlesName();
            } // end if
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("browsed directory path:", browsedDirPath);
            if (GUILayout.Button("Browse")) {
                OpenFolder();
            } // end if
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Modify for browsed directory")) {
                if (string.IsNullOrEmpty(abName)) {
                    Debug.LogWarning("Please input Assetbundle name!");
                    return;
                } // end if
                ModifyAssetBundleNameForDirectory(browsedDirPath);
            } // end if
            if (GUILayout.Button("Remove for browsed directory")) {
                ModifyAssetBundleNameForDirectory(browsedDirPath);
            } // end if
            EditorGUILayout.EndHorizontal();
        } // end OnGUI

        private void OpenFolder() {
            string path = EditorUtility.OpenFolderPanel("selecte directory", "", "");
            if (string.IsNullOrEmpty(path)) return;
            // end if
            if (false == path.Contains(Application.dataPath)) {
                Debug.LogWarning("directory is don't at current project");
                return;
            } // end if
            if (path.Length != 0) {
                int firstindex = path.IndexOf("Assets");
                browsedDirPath = path.Substring(firstindex) + "/";
                EditorUtility.FocusProjectWindow();
            } // end if
        } // end OpenFolder

        private void ModifyAssetBundleNameForDirectory(string path) {
            if (false == Directory.Exists(path)) {
                Debug.LogWarning("selectedDirPath is don't exsit! path:" + path);
                return;
            } // end if
            DirectoryInfo rootDirInfo = new DirectoryInfo(path);
            foreach (FileInfo fileInfo in rootDirInfo.GetFiles("*", SearchOption.AllDirectories)) {
                if (fileInfo.Name.EndsWith(".meta")) continue;
                // end if                   
                SetAssetBundleNameAndVariantWithPath(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")));
            } // end foreach
            AssetDatabase.Refresh();
            InitNameOptions();
            Debug.Log("ModifyAssetBundleNameForDirectory Success!");
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
            AssetDatabase.Refresh();
            InitNameOptions();
            Debug.Log("ClearAllAssetBundlesName Success!");
        } // end ClearAllAssetBundlesName

        private void SetAssetBundleNameAndVariantWithPath(string path) {
            AssetImporter assetImporter = AssetImporter.GetAtPath(path);
            if (null == assetImporter) {
                Debug.LogWarning(path + "is not asset!!");
                return;
            } // end if
            assetImporter.SetAssetBundleNameAndVariant(abName, variant);
        } // end SetAssetBundleNameAndVariantWithPath

        private void RefreshSelectedDirectoryPath() {
            if (Selection.assetGUIDs.Length != 1) {
                Debug.LogWarning("selected is null or don't single directory");
                return;
            } // end if  
            selectedDirPath = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
        } // end RefreshSelectedDirectoryPath
    } // end class ModifyAssetBundleNameWindow
} // end namespace CustomEditor

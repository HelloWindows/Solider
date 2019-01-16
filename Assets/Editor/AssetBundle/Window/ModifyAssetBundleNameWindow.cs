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
                InitNameOptions();
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
            foreach (FileInfo fileInfo in rootDirInfo.GetFiles("*", SearchOption.AllDirectories)) {
                if (fileInfo.Name.EndsWith(".meta")) continue;
                // end if                   
                SetAssetBundleNameAndVariantWithPath(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")));
            } // end foreach
            foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
                foreach (FileInfo fileInfo in dirInfo.GetFiles("*", SearchOption.AllDirectories)) {
                    if (fileInfo.Name.EndsWith(".meta")) continue;
                    // end if     
                    SetAssetBundleNameAndVariantWithPath(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")));             
                } // end foreach
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
    } // end class ModifyAssetBundleNameWindow
} // end namespace CustomEditor

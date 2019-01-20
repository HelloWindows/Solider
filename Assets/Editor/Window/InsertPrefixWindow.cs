/*******************************************************************
 * FileName: BatchFileNameWindow.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEditor;
using System.IO;

namespace CustomEditor {
	public class BatchFileNameWindow : EditorWindow {
        [MenuItem("Custom Editor/Window/InsertPrefix", false, 1000)]
        private static void Init() {
            BatchFileNameWindow window = GetWindow<BatchFileNameWindow>();
            window.titleContent = new GUIContent("InsertPrefix");
            window.Show();
        } // end Init

        private string inputPrefix;
        private string selectedDirPath;

        private void OnGUI() {
            EditorGUILayout.LabelField("directory path:", selectedDirPath);
            inputPrefix = EditorGUILayout.TextField(new GUIContent("Please input prefix!"), inputPrefix);
            if (GUILayout.Button("Insert for selected objects")) InsertPrefixForSelectedObjects();
            // end if

            if (GUILayout.Button("Insert for selected directory")) {
                RefreshSelectedDirectoryPath();
                InsertPrefixForSelectedDirectory();
            } // end if

            if (GUILayout.Button("Insert for selected directory and prefix is directory's name")) {
                RefreshSelectedDirectoryPath();
                InsertPrefixForSelectedDirectoryAndPrefixIsDirectoryName();
            } // end if
        } // end OnGUI

        private void InsertPrefixForSelectedObjects() {
            if (string.IsNullOrEmpty(inputPrefix)) {
                Debug.Log("Please input prefix!");
                return;
            } // end if
            if (Selection.objects == null || Selection.objects.Length == 0) {
                Debug.LogWarning("Please select files that need insert");
                return;
            } // end if
            foreach (Object obj in Selection.objects) {
                Debug.Log(obj.name);
                RenameAsset(AssetDatabase.GetAssetPath(obj), inputPrefix + obj.name);
            } // end foreach
            Debug.Log("Insert prefix is success!");
            AssetDatabase.Refresh();
        } // end InsertPrefixForSelectedObjects

        private void InsertPrefixForSelectedDirectory() {
            if (string.IsNullOrEmpty(inputPrefix)) {
                Debug.Log("Please input prefix!");
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
                RenameAsset(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")), inputPrefix + "_" + fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')));
            } // end foreach
            Debug.Log("Insert prefix is success!");
            AssetDatabase.Refresh();
        } // end InsertPrefixForSelectedDirectory

        private void InsertPrefixForSelectedDirectoryAndPrefixIsDirectoryName() {
            if (false == Directory.Exists(selectedDirPath)) {
                Debug.LogWarning("selectedDirPath is don't exsit! path:" + selectedDirPath);
                return;
            } // end if
            DirectoryInfo rootDirInfo = new DirectoryInfo(selectedDirPath);
            foreach (FileInfo fileInfo in rootDirInfo.GetFiles("*", SearchOption.AllDirectories)) {
                if (fileInfo.Name.EndsWith(".meta")) continue;
                // end if   
                int index = fileInfo.Name.IndexOf("_");
                if (index >= 0 && fileInfo.Name.Substring(0, fileInfo.Name.IndexOf("_")) == fileInfo.Directory.Name) continue;
                // end if
                RenameAsset(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")), fileInfo.Directory.Name + "_" + fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')));
            } // end foreach
            Debug.Log("Insert prefix is success!");
            AssetDatabase.Refresh();
        } // end InsertPrefixForSelectedDirectoryAndPrefixIsDirectoryName

        private void RefreshSelectedDirectoryPath() {
            if (Selection.assetGUIDs.Length != 1) {
                Debug.LogWarning("selected is null or don't single directory");
                return;
            } // end if  
            selectedDirPath = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
        } // end RefreshSelectedDirectoryPath

        private void RenameAsset(string pathName, string newName) {
            string info = AssetDatabase.RenameAsset(pathName, newName);
            if (string.IsNullOrEmpty(info)) return;
            // end if
            Debug.LogWarning("RenameAsset warning " + info);
        } // end RenameAsset
    } // end class BatchFileNameWindow 
} // end namespace CustomEditor
/*******************************************************************
 * FileName: PrefabWindow.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.Rendering;

namespace CustomEditor {
	public class PrefabWindow : EditorWindow {
        [MenuItem("Custom Editor/Window/ObjectShadow", false, 1000)]
        private static void Init() {
            PrefabWindow window = GetWindow<PrefabWindow>();
            window.titleContent = new GUIContent("Prefab Window");
            window.Show();
        } // end Init

        private string selectedDirPath;

        private void OnGUI() {
            EditorGUILayout.LabelField("directory path:", selectedDirPath);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Off Cast Shadows for selected single directory")) {
                RefreshSelectedDirectoryPath();
                ChangeCastShadowsInDirectory(false);
            } // end if
            if (GUILayout.Button("On Cast Shadows for selected single directory")) {
                RefreshSelectedDirectoryPath();
                ChangeCastShadowsInDirectory(true);
            } // end if
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Off Receive Shadows for selected single directory")) {
                RefreshSelectedDirectoryPath();
                ChangeReceiveShadowsInDirectory(false);
            } // end if
            if (GUILayout.Button("On Receive Shadows for selected single directory")) {
                RefreshSelectedDirectoryPath();
                ChangeReceiveShadowsInDirectory(true);
            } // end if
            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Remove all animation for selected single directory")) {
                RefreshSelectedDirectoryPath();
                RemoveAllAnimationInDirectory();
            } // end if
        } // end OnGUI

        private void ChangeCastShadowsInDirectory(bool isOn) {
            if (false == Directory.Exists(selectedDirPath)) {
                Debug.LogWarning("selectedDirPath is don't exsit! path:" + selectedDirPath);
                return;
            } // end if
            ShadowCastingMode castMode = isOn ? ShadowCastingMode.On : ShadowCastingMode.Off;
            DirectoryInfo rootDirInfo = new DirectoryInfo(selectedDirPath);
            foreach (FileInfo fileInfo in rootDirInfo.GetFiles("*", SearchOption.AllDirectories)) {
                if (false == fileInfo.Name.EndsWith(".prefab")) continue;
                // end if               
                SetCastShadowsWithPath(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")), castMode);
            } // end foreach
            AssetDatabase.Refresh();
        } // end ChangeCastShadowsInDirectory

        private void ChangeReceiveShadowsInDirectory(bool isOn) {
            if (false == Directory.Exists(selectedDirPath)) {
                Debug.LogWarning("selectedDirPath is don't exsit! path:" + selectedDirPath);
                return;
            } // end if
            DirectoryInfo rootDirInfo = new DirectoryInfo(selectedDirPath);
            foreach (FileInfo fileInfo in rootDirInfo.GetFiles("*", SearchOption.AllDirectories)) {
                if (false == fileInfo.Name.EndsWith(".prefab")) continue;
                // end if               
                SetReceiveShadowsWithPath(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")), isOn);
            } // end foreach
            AssetDatabase.Refresh();
        } // end ChangeReceiveShadowsInDirectory

        private void RemoveAllAnimationInDirectory() {
            if (false == Directory.Exists(selectedDirPath)) {
                Debug.LogWarning("selectedDirPath is don't exsit! path:" + selectedDirPath);
                return;
            } // end if
            DirectoryInfo rootDirInfo = new DirectoryInfo(selectedDirPath);
            foreach (FileInfo fileInfo in rootDirInfo.GetFiles("*", SearchOption.AllDirectories)) {
                if (false == fileInfo.Name.EndsWith(".prefab")) continue;
                // end if               
                RemoveAllAnimationWhitPath(fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("Assets")));
            } // end foreach
            AssetDatabase.Refresh();
        } // end RemoveAllAnimationInDirectory

        private void SetCastShadowsWithPath(string path, ShadowCastingMode castMode) {
            GameObject Go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (null == Go) return;
            // end if
            MeshRenderer[] renderers = Go.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++) {
                renderers[i].shadowCastingMode = castMode;
            } // end for
            SkinnedMeshRenderer[] skinArr = Go.GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int i = 0; i < skinArr.Length; i++) {
                skinArr[i].shadowCastingMode = castMode;
            } // end for
        } // end SetCastShadowsWithPath

        private void SetReceiveShadowsWithPath(string path, bool isOn) {
            GameObject Go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (null == Go) return;
            // end if
            MeshRenderer[] renderers = Go.GetComponentsInChildren<MeshRenderer>();
            for (int i = 0; i < renderers.Length; i++) {
                renderers[i].receiveShadows = isOn;
            } // end for
            SkinnedMeshRenderer[] skinArr = Go.GetComponentsInChildren<SkinnedMeshRenderer>();
            for (int i = 0; i < skinArr.Length; i++) {
                skinArr[i].receiveShadows = isOn;
            } // end for
        } // end SetReceiveShadowsWithPath
      
        private void RemoveAllAnimationWhitPath(string path) {
            GameObject Go = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (null == Go) return;
            // end if
            Animation[] animations = Go.GetComponentsInChildren<Animation>();
            for (int i = 0; i < animations.Length; i++) {
                DestroyImmediate(animations[i], true);
            } // end for
        } // end RemoveAllAnimation

        private void RefreshSelectedDirectoryPath() {
            if (Selection.assetGUIDs.Length != 1) {
                Debug.LogWarning("selected is null or don't single directory");
                return;
            } // end if  
            selectedDirPath = AssetDatabase.GUIDToAssetPath(Selection.assetGUIDs[0]);
        } // end RefreshSelectedDirectoryPath
    } // end class PrefabWindow 
} // end namespace CustomEditor
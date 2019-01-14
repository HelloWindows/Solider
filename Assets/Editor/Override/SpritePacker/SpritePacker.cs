/*******************************************************************
 * FileName: SpritePacker.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.IO;
using UnityEditor;
using UnityEngine;

namespace CustomEditor {
	public class SpritePacker {
        //[MenuItem("Custom Editor/Make Atlas", false, 100)]
        static private void MakeAtlas() {
            string spriteDir = Application.dataPath + "/Resources/Sprite";
            if (!Directory.Exists(spriteDir)) {
                Directory.CreateDirectory(spriteDir);
            } // end if
            DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/Atlas");
            foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
                foreach (FileInfo pngFile in dirInfo.GetFiles("*.png", SearchOption.AllDirectories)) {
                    string allPath = pngFile.FullName;
                    string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
                    Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
                    GameObject go = new GameObject(sprite.name);
                    go.AddComponent<SpriteRenderer>().sprite = sprite;
                    allPath = spriteDir + "/" + sprite.name + ".prefab";
                    string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
                    PrefabUtility.CreatePrefab(prefabPath, go);
                    Object.DestroyImmediate(go);
                } // end foreach
            } // end foreach
        } // end MakeAtlas
    } // end class SpritePacker
} // end namespace CustomEditor 

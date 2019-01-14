/*******************************************************************
 * FileName: Postprocessor.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using UnityEditor;
using System.IO;

namespace CustomEditor {
    public class Postprocessor : AssetPostprocessor {

        private void OnPostprocessTexture(Texture2D texture)  {
            if (assetPath.Contains("Assets/Atlas")) {
                string AtlasName = new DirectoryInfo(Path.GetDirectoryName(assetPath)).Name;
                TextureImporter textureImporter = assetImporter as TextureImporter;
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.mipmapEnabled = false;
                if (texture.width > 512 || texture.height > 512) return;
                // end if
                textureImporter.spritePackingTag = AtlasName;
            } else {
                TextureImporter textureImporter = assetImporter as TextureImporter;
                if (textureImporter.textureType != TextureImporterType.Sprite) return;
                // end if
                if (string.IsNullOrEmpty(textureImporter.spritePackingTag)) return;
                // end if
                textureImporter.spritePackingTag = string.Empty;
                Debug.LogWarning("OnPostprocessTexture sprite atlas must put in Assets/Atlas, assetpath:" + assetPath);
            } // end if
        } // end OnPostprocessTexture

        private void OnPreprocessAudio() {

        } // end OnPreprocessAudio

        /// <summary>
        /// 禁止模型生成材质文件
        /// </summary>
        private void OnPreprocessModel() {
            ModelImporter modelImporter = assetImporter as ModelImporter;
            modelImporter.importMaterials = false;
        } // end OnPreprocessModel
    } // end class Postprocessor
} // end namespace CustomEditor 
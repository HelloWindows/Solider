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

        void OnPostprocessTexture(Texture2D texture)  {
            string AtlasName = new DirectoryInfo(Path.GetDirectoryName(assetPath)).Name;
            TextureImporter textureImporter = assetImporter as TextureImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spritePackingTag = AtlasName;
            textureImporter.mipmapEnabled = false;
        } // end OnPostprocessTexture
    } // end class Postprocessor
} // end namespace CustomEditor 
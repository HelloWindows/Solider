/*******************************************************************
 * FileName: CustomPackerPolicy.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.Sprites;
using System.Collections.Generic;

public class CustomPackerPolicy : IPackerPolicy {
    protected class Entry {
        public Sprite sprite;
        public AtlasSettings settings;
        public string atlasName;
        public SpritePackingMode packingMode;
        public int anisoLevel;
    } // end class Entry

    private const uint kDefaultPaddingPower = 3; // Good for base and two mip levels.

    public virtual int GetVersion() { return 1; }
    protected virtual string TagPrefix { get { return "[TIGHT]"; } }
    protected virtual bool AllowTightWhenTagged { get { return true; } }
    protected virtual bool AllowRotationFlipping { get { return false; } }

    public static bool IsCompressedFormat(TextureFormat fmt) {
        if (fmt >= TextureFormat.DXT1 && fmt <= TextureFormat.DXT5)
            return true;
        if (fmt >= TextureFormat.DXT1Crunched && fmt <= TextureFormat.DXT5Crunched)
            return true;
        if (fmt >= TextureFormat.PVRTC_RGB2 && fmt <= TextureFormat.PVRTC_RGBA4)
            return true;
        if (fmt == TextureFormat.ETC_RGB4)
            return true;
        if (fmt >= TextureFormat.ATC_RGB4 && fmt <= TextureFormat.ATC_RGBA8)
            return true;
        if (fmt >= TextureFormat.EAC_R && fmt <= TextureFormat.EAC_RG_SIGNED)
            return true;
        if (fmt >= TextureFormat.ETC2_RGB && fmt <= TextureFormat.ETC2_RGBA8)
            return true;
        if (fmt >= TextureFormat.ASTC_RGB_4x4 && fmt <= TextureFormat.ASTC_RGBA_12x12)
            return true;
        if (fmt >= TextureFormat.DXT1Crunched && fmt <= TextureFormat.DXT5Crunched)
            return true;
        return false;
    } // end IsCompressedFormat

    public void OnGroupAtlases(BuildTarget target, PackerJob job, int[] textureImporterInstanceIDs) {
        List<Entry> entries = new List<Entry>();

        foreach (int instanceID in textureImporterInstanceIDs) {
            TextureImporter ti = EditorUtility.InstanceIDToObject(instanceID) as TextureImporter;
            TextureFormat desiredFormat;
            ColorSpace colorSpace;
            int compressionQuality;
            ti.ReadTextureImportInstructions(target, out desiredFormat, out colorSpace, out compressionQuality);
            TextureImporterSettings tis = new TextureImporterSettings();
            ti.ReadTextureSettings(tis);
            Sprite[] sprites =
                AssetDatabase.LoadAllAssetRepresentationsAtPath(ti.assetPath)
                    .Select(x => x as Sprite)
                    .Where(x => x != null)
                    .ToArray();
            foreach (Sprite sprite in sprites) {
                Entry entry = new Entry();
                entry.sprite = sprite;
                entry.settings.format = desiredFormat;
                entry.settings.colorSpace = colorSpace;
                // Use Compression Quality for Grouping later only for Compressed Formats. Otherwise leave it Empty.
                entry.settings.compressionQuality = IsCompressedFormat(desiredFormat) ? compressionQuality : 0;
                entry.settings.filterMode = Enum.IsDefined(typeof(FilterMode), ti.filterMode)
                    ? ti.filterMode
                    : FilterMode.Bilinear;
                entry.settings.maxWidth = 1024;
                entry.settings.maxHeight = 1024;
                entry.settings.generateMipMaps = ti.mipmapEnabled;
                entry.settings.enableRotation = AllowRotationFlipping;
                if (ti.mipmapEnabled) {
                    entry.settings.paddingPower = kDefaultPaddingPower;
                } else {
                    entry.settings.paddingPower = (uint)EditorSettings.spritePackerPaddingPower;
                } // end if
#if ENABLE_ANDROID_ATLAS_ETC1_COMPRESSION
                        entry.settings.allowsAlphaSplitting = ti.GetAllowsAlphaSplitting ();
#endif //ENABLE_ANDROID_ATLAS_ETC1_COMPRESSION

                entry.atlasName = ParseAtlasName(ti.spritePackingTag);
                entry.packingMode = GetPackingMode(ti.spritePackingTag, tis.spriteMeshType);
                entry.anisoLevel = ti.anisoLevel;

                entries.Add(entry);
            } // end foreach
            Resources.UnloadAsset(ti);
        } // end foreach

        // First split sprites into groups based on atlas name
        var atlasGroups =
            from e in entries
            group e by e.atlasName;
        foreach (var atlasGroup in atlasGroups) {
            int page = 0;
            // Then split those groups into smaller groups based on texture settings
            var settingsGroups =
                from t in atlasGroup
                group t by t.settings;
            foreach (var settingsGroup in settingsGroups) {
                string atlasName = atlasGroup.Key;
                if (settingsGroups.Count() > 1) {
                    atlasName += string.Format(" (Group {0})", page);
                } // end if
                AtlasSettings settings = settingsGroup.Key;
                settings.anisoLevel = 1;
                // Use the highest aniso level from all entries in this atlas
                if (settings.generateMipMaps) {
                    foreach (Entry entry in settingsGroup) {
                        if (entry.anisoLevel > settings.anisoLevel) {
                            settings.anisoLevel = entry.anisoLevel;
                        } // end if
                    } // end foreach
                } // end if
                job.AddAtlas(atlasName, settings);
                foreach (Entry entry in settingsGroup) {
                    job.AssignToAtlas(atlasName, entry.sprite, entry.packingMode, SpritePackingRotation.None);
                } // end foreach
                ++page;
            } // end foreach
        } // end foreach
    } // end OnGroupAtlases

    protected bool IsTagPrefixed(string packingTag) {
        packingTag = packingTag.Trim();
        if (packingTag.Length < TagPrefix.Length) return false;
        // end if
        return (packingTag.Substring(0, TagPrefix.Length) == TagPrefix);
    } // end IsTagPrefixed

    private string ParseAtlasName(string packingTag) {
        string name = packingTag.Trim();
        if (IsTagPrefixed(name)) {
            name = name.Substring(TagPrefix.Length).Trim();
        } // end if
        return (name.Length == 0) ? "(unnamed)" : name;
    } // end ParseAtlasName

    private SpritePackingMode GetPackingMode(string packingTag, SpriteMeshType meshType) {
        if (meshType == SpriteMeshType.Tight) {
            if (IsTagPrefixed(packingTag) == AllowTightWhenTagged) {
                return SpritePackingMode.Tight;
            } // end if
        } // end if
        return SpritePackingMode.Rectangle;
    } // end GetPackingMode
} // end class CustomPackerPolicy

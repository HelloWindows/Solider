/*******************************************************************
 * FileName: ResourcesTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
namespace Framework {
    namespace Tools {
        public static class ResourcesTool {
            private static AssetBundle m_spriteAsset;
            private static AssetBundle spriteAsset {
                get {
                    if (null == m_spriteAsset) {
                        m_spriteAsset = PlatformTool.LoadFromStreamingAssets("atlas/res_sprite.unity3d");
                    } // end if
                    return m_spriteAsset;
                } // end if
            } // end spriteAsset

            private static AssetBundle m_audioAsset;
            private static AssetBundle audioAsset {
                get {
                    if (null == m_audioAsset) {
                        m_audioAsset = PlatformTool.LoadFromStreamingAssets("aduio/res_aduio.unity3d");
                    } // end if
                    return m_audioAsset;
                } // end get
            } // end audioAsset

            private static AssetBundle m_prefabAsset;
            private static AssetBundle prefabAsset {
                get {
                    if (null == m_prefabAsset) {
                        m_prefabAsset = PlatformTool.LoadFromStreamingAssets("prefab/res_prefab.unity3d");
                    } // end if
                    return m_prefabAsset;
                } // end get
            } // end prefabAsset

            private static AssetBundle m_uiPrefabAsset;
            private static AssetBundle uiPrefabAsset {
                get {
                    if (null == m_uiPrefabAsset) {
                        m_uiPrefabAsset = PlatformTool.LoadFromStreamingAssets("prefab/res_prefab_ui.unity3d");
                    } // end if
                    return m_uiPrefabAsset;
                } // end get
            } // end uiPrefabAsset

            private static AssetBundle m_poolPrefabAsset;
            private static AssetBundle poolPrefabAsset {
                get {
                    if (null == m_poolPrefabAsset) {
                        m_poolPrefabAsset = PlatformTool.LoadFromStreamingAssets("prefab/res_prefab_pool.unity3d");
                    } // end if
                    return m_poolPrefabAsset;
                } // end get
            } // end poolPrefabAsset

            private static AssetBundle m_animationAsset;
            private static AssetBundle animationAsset {
                get {
                    if (null == m_animationAsset) {
                        m_animationAsset = PlatformTool.LoadFromStreamingAssets("animation/res_animation.unity3d");
                    } // end if
                    return m_animationAsset;
                } // end get
            } // end animationAsset

            private static AssetBundle m_materialAsset;
            private static AssetBundle materialAsset {
                get {
                    if (null == m_materialAsset) {
                        m_materialAsset = PlatformTool.LoadFromStreamingAssets("material/res_material.unity3d");
                    } // end if
                    return m_materialAsset;
                } // end get
            } // end materialAsset

            public static Sprite LoadSprite(string spriteName) {
                if (string.IsNullOrEmpty(spriteName)) return null;
                // end if
                return spriteAsset.LoadAsset<Sprite>(spriteName);
            } // end LoadSprite

            public static AudioClip LoadAudioClip(string audioName) {
                if (string.IsNullOrEmpty(audioName)) return null;
                // end if
                return audioAsset.LoadAsset<AudioClip>(audioName);
            } // end LoadAudioClip

            public static GameObject LoadPrefab(string prefabName) {
                if (string.IsNullOrEmpty(prefabName)) return null;
                // end if
                return prefabAsset.LoadAsset<GameObject>(prefabName);
            } // end LoadPrefab

            public static GameObject LoadPrefabUI(string uiName) {
                if (string.IsNullOrEmpty(uiName)) return null;
                // end if
                if (null == spriteAsset) ConsoleTool.SetError("prefabUI need preload sprite!");
                // end if
                return uiPrefabAsset.LoadAsset<GameObject>(uiName);
            } // end LoadPrefabUI

            public static GameObject LoadPrefabPool(string name) {
                if (string.IsNullOrEmpty(name)) return null;
                // end if
                return poolPrefabAsset.LoadAsset<GameObject>(name);
            } // end LoadPrefabPool

            public static AnimationClip LoadAnimationClip(string animationPath) {
                if (string.IsNullOrEmpty(animationPath)) return null;
                // end if
                AnimationClip clip  = animationAsset.LoadAsset<AnimationClip>(animationPath);
                return clip;
            } // end LoadAnimationClip

            public static Material LoadMaterial(string materialName) {
                if (string.IsNullOrEmpty(materialName)) return null;
                // end if
                Material material  = materialAsset.LoadAsset<Material>(materialName);
                return material;
            } // end LoadMaterial
        } // end class ResourcesTool 
    } // end namespace Tools
} // end namespace Framework
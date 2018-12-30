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
        } // end class ResourcesTool 
    } // end namespace Tools
} // end namespace Framework
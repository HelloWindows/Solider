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
            public static Sprite LoadSprite(string spriteName) {
                return spriteAsset.LoadAsset<Sprite>(spriteName);
            } // end LoadSprite
        } // end class ResourcesTool 
    } // end namespace Tools
} // end namespace Framework
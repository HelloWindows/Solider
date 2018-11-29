/*******************************************************************
 * FileName: CharacterAduio.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Solider.Character.Interface;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Character {
        public class CharacterAduio : ICharacterAduio {
            private float valume;
            private AudioSource audio;
            private static Dictionary<string, AudioClip> clipCache;

            public CharacterAduio(AudioSource audio) {
                valume = 1;
                this.audio = audio;
                if (null == clipCache) clipCache = new Dictionary<string, AudioClip>();
                // end if
            } // end CharacterAduio

            public void PlaySoundCache(string name) {
                AudioClip clip = GetClipAtCache(name);
                if (null == clip) return;
                // end if
                audio.PlayOneShot(clip, valume);
            } // end PlaySoundCache

            public void PlaySoundOnce(string name) {
                AudioClip clip = Resources.Load<AudioClip>(Configs.soundConfig.GetPath(name));
                if (null == clip) return;
                // end if
                audio.PlayOneShot(clip, valume);
            } // end PlaySoundOnce

            public void PlaySoundOnceForPath(string path) {
                if (null == path) return;
                // end if
                AudioClip clip = Resources.Load<AudioClip>(path);
                if (null == clip) return;
                // end if
                audio.PlayOneShot(clip, valume);
            } // end PlaySoundOnceForPath

            public void PlaySoundCacheForPath(string name, string path) {
                if (null == name || null == path) return;
                // end if
                AudioClip clip;
                if (false == clipCache.TryGetValue(name, out clip)) {
                    clip = Resources.Load<AudioClip>(path);
                    if (null == clip) return;
                    // end if
                    clipCache[name] = clip;
                } // end if
                if (null == clip) return;
                // end if
                audio.PlayOneShot(clip, valume);
            } // end PlaySoundCacheForPath

            public void PlaySoundCacheAtPoint(string name, Vector3 position) {
                AudioClip clip = GetClipAtCache(name);
                if (null == clip) return;
                // end if
                AudioSource.PlayClipAtPoint(clip, position, valume);
            } // end PlaySoundCacheAtPoint

            public void PlaySoundOnceAtPoint(string name, Vector3 position) {
                AudioClip clip = Resources.Load<AudioClip>(Configs.soundConfig.GetPath(name));
                if (null == clip) return;
                // end if
                AudioSource.PlayClipAtPoint(clip, position, valume);
            } // end PlaySoundOnceAtPoint

            public void Dispose() {
                if (null == clipCache || clipCache.Count == 0) return;
                // end if
                clipCache.Clear();
            } // end ClearSoundCache

            private AudioClip GetClipAtCache(string name) {
                if (clipCache.ContainsKey(name) == false) {
                    AudioClip clip = Resources.Load<AudioClip>(Configs.soundConfig.GetPath(name));
                    if (null == clip) return null;
                    // end if
                    clipCache[name] = clip;
                } // end if
                return clipCache[name];
            } // end GetClipAtCache
        } // end class CharacterAduio
    } // end namespace Character
} // end namespace Solider 

﻿/*******************************************************************
 * FileName: CharacterAduio.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using Solider.Character.Interface;
using System.Collections.Generic;
using UnityEngine;
using Framework.Tools;

namespace Solider {
    namespace Character {
        public class CharacterAduio : ICharacterAudio, IDisposable {
            private float valume;
            private AudioSource audio;
            private static Dictionary<string, AudioClip> clipCache;

            public CharacterAduio(AudioSource audio) {
                valume = 1;
                this.audio = audio;
                audio.spatialBlend = 1f;
                audio.minDistance = 10;
                if (null == clipCache) clipCache = new Dictionary<string, AudioClip>();
                // end if
            } // end CharacterAduio

            public void PlaySoundCache(string name) {

            } // end PlaySoundCache

            public void PlaySoundOnce(string name) {
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
                if (string.IsNullOrEmpty(name)) return;
                // end if
                AudioClip clip;
                if (false == clipCache.TryGetValue(name, out clip)) {
                    clip = ResourcesTool.LoadAudioClip(path);
                    if (null == clip) return;
                    // end if
                    clipCache[name] = clip;
                } // end if
                if (null == clip) return;
                // end if
                audio.PlayOneShot(clip, valume);
            } // end PlaySoundCacheForPath

            public void PlaySoundCacheAtPoint(string name, Vector3 position) {

            } // end PlaySoundCacheAtPoint

            public void PlaySoundOnceAtPoint(string name, Vector3 position) {
            } // end PlaySoundOnceAtPoint

            public void Dispose() {
                //if (null == clipCache) return;
                //// end if
                //clipCache.Clear();
                //clipCache = null;
            } // end ClearSoundCache
        } // end class CharacterAduio
    } // end namespace Character
} // end namespace Solider 

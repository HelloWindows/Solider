﻿/*******************************************************************
 * FileName: CharacterAduio.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Interface.Audio;
using Framework.Manager;
using System.Collections.Generic;
using UnityEngine;

namespace Solider {
    namespace Character {
        public class CharacterAduio : IAudioSound {
            private float valume;
            private AudioSource audio;
            private Transform characterTrans;
            private static Dictionary<string, AudioClip> clipCache;

            public CharacterAduio(AudioSource audio, Transform characterTrans) {
                valume = 1;
                this.audio = audio;
                this.characterTrans = characterTrans;
                if (null == clipCache) clipCache = new Dictionary<string, AudioClip>();
                // end if
            } // end CharacterAduio

            public void PlaySoundCache(string name) {
                audio.PlayOneShot(GetClipAtCache(name), valume);
            } // end PlaySoundCache

            public void PlaySoundOnce(string name) {
                AudioClip clip = Resources.Load<AudioClip>(ConfigMgr.aduioConfig.SoundPath[name]);
                audio.PlayOneShot(clip, valume);
            } // end PlaySoundOnce

            public void PlaySoundCacheAtPoint(string name) {
                AudioSource.PlayClipAtPoint(GetClipAtCache(name), characterTrans.position, valume);
            } // end PlaySoundCacheAtPoint

            public void PlaySoundOnceAtPoint(string name) {
                AudioClip clip = Resources.Load<AudioClip>(ConfigMgr.aduioConfig.SoundPath[name]);
                AudioSource.PlayClipAtPoint(clip, characterTrans.position, valume);
            } // end PlaySoundOnceAtPoint

            public void SetSoundValume(float valume) {
                if (valume < 0) valume = 0;
                // end if
                if (valume > 1) valume = 1;
                // end if
                this.valume = valume;
            } // end SetSoundValue

            private AudioClip GetClipAtCache(string name) {
                if (clipCache.ContainsKey(name) == false) {
                    clipCache[name] = Resources.Load<AudioClip>(ConfigMgr.aduioConfig.SoundPath[name]);
                } // end if
                return clipCache[name];
            } // end GetClipAtCache
        } // end class CharacterAduio
    } // end namespace Character
} // end namespace Solider 
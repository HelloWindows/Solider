/*******************************************************************
 * FileName: AudioManager.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine;
using Framework.Config;

namespace Framework {
    namespace Instance {
        public class AudioManager {
            private AudioSource audioSource0;
            private AudioSource audioSource1;

            public AudioManager() {
                GameObject Go = new GameObject("AudioManager");
                Go.AddComponent<AudioListener>();
                audioSource0 = Go.AddComponent<AudioSource>();
                audioSource1 = Go.AddComponent<AudioSource>();
                audioSource0.loop = true;
            } // end AudioManager

            public void PlayMusic(string key) {
                try {
                    audioSource0.clip = AudioConfig.MusicDict[key];
                    audioSource0.Play();
                }
                catch (Exception ex)
                {
                    Debug.LogError("PlayMusic error key is: " + key + " Reason: " + ex.Message);
                } // end try
            } // end PlayMusic

            public void PlayeSoundEffect(string key)
            {
                try
                {
                    audioSource1.PlayOneShot(AudioConfig.SoundEffectDict[key]);
                }
                catch (Exception ex)
                {
                    Debug.LogError("PlayeSoundEffect error key is: " + key + " Reason: " + ex.Message);
                } // end try
            } // end PlayeSoundEffect

            public void PlayeSoundEffect(AudioClip clip)
            {
                try
                {
                    audioSource1.PlayOneShot(clip);
                }
                catch (Exception ex)
                {
                    Debug.LogError("PlayeSoundEffect error!!" + " Reason: " + ex.Message);
                } // end try
            } // end PlayeSoundEffect
        } // end class AudioManager
    } // end namespace Instances
} // end namespace Framework 
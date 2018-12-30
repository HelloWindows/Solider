/*******************************************************************
 * FileName: MainAudio.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System;
using UnityEngine;
using Framework.Interface.Audio;
using Framework.Tools;

namespace Framework {
    namespace Custom {
        namespace Audio {
            public class MainAudio : IMainAudio, IDisposable {

                private AudioSource musicAudio;
                private AudioSource soundAduio;
                private GameObject gameObject;

                public MainAudio() {
                    gameObject = new GameObject("MainAudio");
                    musicAudio = gameObject.AddComponent<AudioSource>();
                    musicAudio.loop = true;
                    musicAudio.priority = 0;
                    soundAduio = gameObject.AddComponent<AudioSource>();
                } // end MainAudio

                public void PlaySound(string name) {
                    soundAduio.PlayOneShot(ResourcesTool.LoadAudioClip(name));
                } // end PlaySound

                public void PlaySound(AudioClip clip) {
                    soundAduio.PlayOneShot(clip);
                } // end PlaySound

                public void PlayBackgroundMusic(string name) {
                    musicAudio.clip = ResourcesTool.LoadAudioClip(name);
                    musicAudio.Play();
                } // end PlayBackgroundMusic

                public void PlayBackgroundMusic(AudioClip clip) {
                    musicAudio.PlayOneShot(clip);
                } // end PlayBackgroundMusic

                public void Dispose() {
                    if (null != gameObject) UnityEngine.Object.Destroy(gameObject);
                    // end if
                } // end Dispose
            } // end class MainAudio 
        } // end namespace Audio
    } // end namespaces Custom
} // end namespace Framework
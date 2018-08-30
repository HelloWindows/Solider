/*******************************************************************
 * FileName: IAudioSound.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Framework {
    namespace Interface {
        namespace Audio {
            public interface IAudioSound {
                void PlaySoundOnce(string name);
                void PlaySoundCache(string name);
                void PlaySoundOnceAtPoint(string name, Vector3 position);
                void PlaySoundCacheAtPoint(string name, Vector3 position);
                void SetSoundValume(float valume);
            } // end interface IAudioSound
        } // end namespace Audio
    } // end namespace Interface
} // end namespace Framework 

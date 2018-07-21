/*******************************************************************
 * FileName: IAudioSound.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace Framework {
    namespace Interface {
        namespace Audio {
            public interface IAudioSound {
                void PlaySoundOnce(string name);
                void PlaySoundCache(string name);
                void PlaySoundOnceAtPoint(string name);
                void PlaySoundCacheAtPoint(string name);
                void SetSoundValume(float valume);
            } // end interface IAudioSound
        } // end namespace Audio
    } // end namespace Interface
} // end namespace Framework 

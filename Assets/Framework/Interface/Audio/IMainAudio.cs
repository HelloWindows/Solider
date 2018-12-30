/*******************************************************************
 * FileName: IMainAudio.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Framework {
    namespace Interface {
        namespace Audio {
            public interface IMainAudio {
                void PlaySound(string name);
                void PlaySound(AudioClip clip);
                void PlayBackgroundMusic(string name);
                void PlayBackgroundMusic(AudioClip clip);
            } // end interface IMainAudio
        } // end namespace Audio
    } // end namespace Interface
} // end namespace Framework 

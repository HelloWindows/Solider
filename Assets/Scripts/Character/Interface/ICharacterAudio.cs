/*******************************************************************
 * FileName: ICharacterAudio.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterAudio {
                //void PlaySoundOnce(string name);
                //void PlaySoundCache(string name);
                //void PlaySoundOnceForPath(string path);
                void PlaySoundCacheForPath(string name, string path);
                //void PlaySoundOnceAtPoint(string name, Vector3 position);
                //void PlaySoundCacheAtPoint(string name, Vector3 position);
            } // end class ICharacterAudio
        } // end namespace Interface
    } // end namespace Character
} // end namespace Solider 

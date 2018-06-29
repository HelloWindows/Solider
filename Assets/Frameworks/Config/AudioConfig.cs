/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework {
    namespace Config {
        public class AudioConfig {
            private static Dictionary<string, AudioClip> musicDict;
            private static Dictionary<string, AudioClip> soundEffectDict;

            public static Dictionary<string, AudioClip> MusicDict {
                get {
                    if (null == musicDict) {
                        musicDict = new Dictionary<string, AudioClip>();

                        DebugTool.CheckNullDictionary(musicDict);
                    } // end if
                    return musicDict;
                } // end get
            } // end MusicDict

            public static Dictionary<string, AudioClip> SoundEffectDict {
                get {
                    if (null == soundEffectDict) {
                        soundEffectDict = new Dictionary<string, AudioClip>();

                        DebugTool.CheckNullDictionary(soundEffectDict);
                    } // end if
                    return soundEffectDict;
                } // end get
            } // end SoundEffectDict
        } // end class AudioConfig
    } // end namespace Config 
} // end namespace HiiGo
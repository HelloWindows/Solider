/*******************************************************************
 * FileName: Backstage.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections.Generic;

namespace Framework {
    namespace Config {
        namespace Audio {
            public class AudioConfig {
                private static AudioConfig config;
                public static AudioConfig instance {
                    get {
                        if (null == config) config = new AudioConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance
                public readonly Dictionary<string, string> MusicPath;
                public readonly Dictionary<string, string> SoundPath;

                private AudioConfig() {
                    MusicPath = new Dictionary<string, string>();
                    SoundPath = new Dictionary<string, string>();
                    string prefix = "Character/Hero/Sound/";
                    SoundPath["heroRun"] = prefix + "heroRun";
                } // end AudioConfig
            } // end class AudioConfig
        } // end namespace Audio
    } // end namespace Config 
} // end namespace HiiGo
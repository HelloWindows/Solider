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
            public class MusicConfig : PathConfig {
                private static MusicConfig config;
                public static MusicConfig instance {
                    get {
                        if (null == config) config = new MusicConfig();
                        // end if
                        return config;
                    } // end get
                } // end instance

                private MusicConfig() : base() {

                } // end AudioConfig
            } // end class SoundConfig
        } // end namespace Audio
    } // end namespace Config 
} // end namespace HiiGo
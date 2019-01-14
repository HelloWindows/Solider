/*******************************************************************
 * FileName: SortingLayerConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Framework {
    namespace Config {
        namespace Game {
            public static class SortingLayerConfig {
                public const string Default = "Default";
                public const string HUD = "HUD";
 
                public static int ID_Default = SortingLayer.NameToID(Default);
                public static int ID_HUD = SortingLayer.NameToID(HUD);
            } // end class SortingLayerConfig 
        } // end namespace Game
    } // end namespace Config 
} // end namespace Framework
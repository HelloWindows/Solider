/*******************************************************************
 * FileName: LayerConfig.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Framework {
    namespace Config {
        namespace Game {
            public static class LayerConfig {
                private const string m_Default = "Default";
                private const string m_TransparentFX = "TransparentFX";
                private const string m_IgnoreRaycast = "Ignore Raycast";
                private const string m_Water = "Water";
                private const string m_UI = "UI";
                private const string m_NPC = "NPC";
                private const string m_Main = "Main";

                public static int Default = LayerMask.NameToLayer(m_Default);
                public static int TransparentFX = LayerMask.NameToLayer(m_TransparentFX);
                public static int IgnoreRaycast = LayerMask.NameToLayer(m_IgnoreRaycast);
                public static int Water = LayerMask.NameToLayer(m_Water);
                public static int UI = LayerMask.NameToLayer(m_UI);
                public static int NPC = LayerMask.NameToLayer(m_NPC);
                public static int Main = LayerMask.NameToLayer(m_Main);

                public static int Mask_Default= LayerMask.GetMask(m_Default);
                public static int Mask_TransparentFX = LayerMask.GetMask(m_TransparentFX);
                public static int Mask_IgnoreRaycast = LayerMask.GetMask(m_IgnoreRaycast);
                public static int Mask_Water = LayerMask.GetMask(m_Water);
                public static int Mask_UI = LayerMask.GetMask(m_UI);
                public static int Mask_NPC = LayerMask.GetMask(m_NPC);
                public static int Mask_Main = LayerMask.GetMask(m_Main);
            } // end class LayerConfig 
        } // end namespace Game
    } // end namespace Config 
} // end namespace Framework
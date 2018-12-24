/*******************************************************************
 * FileName: EditorTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEditor;
namespace CustomEditor {
	public static class EditorTool {

        public static BuildTarget GetBuildTarget() {
            BuildTarget target = BuildTarget.WebGL;
#if UNITY_STANDALONE
            target = BuildTarget.StandaloneWindows;
#elif UNITY_IPHONE
			target = BuildTarget.iPhone;
#elif UNITY_ANDROID
            target = BuildTarget.Android;
#endif
            return target;
        } // end GetBuildTarget
    } // end class EditorTool 
} // end namespace CustomEditor
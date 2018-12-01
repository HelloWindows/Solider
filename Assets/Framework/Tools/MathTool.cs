/*******************************************************************
 * FileName: MathTool.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

namespace Framework {
    namespace Tools {
        public class MathTool {

            public static int Random(int min, int max) {
                return UnityEngine.Random.Range(min, max);
            } // end Random

            public static float Random(float min, float max) {
                return UnityEngine.Random.Range(min, max);
            } // end Random

            public static int Percent(int value, float ratio) {
                return (int)(value * ratio / 100f);
            } // end Percent

            public static float Percent(float value, float ratio) {
                return value * ratio / 100f;
            } // end Percent

            public static int LimitZero(int value) {
                if (value < 0) return 0;
                // end if
                return value;
            } // end LimitZero

            public static float LimitZero(float value) {
                if (value < 0) return 0;
                // end if
                return value;
            } // end LimitZero


            public static int LimitMin(int value, int min) {
                if (value < min) return min;
                // end if
                return value;
            } // end LimitMin

            public static float LimitMin(float value, float min) {
                if (value < min) return min;
                // end if
                return value;
            } // end LimitMin

            public static int Clamp(int value, int min, int max) {
                if (value < min) return min;
                // end if
                if (max < min) return value;
                // end if
                if (value > max) return max;
                // end if
                return value;
            } // end Clamp

            public static float Clamp(float value, float min, float max) {
                if (value < min) return min;
                // end if
                if (max < min) return value;
                // end if
                if (value > max) return max;
                // end if
                return value;
            } // end Clamp
        } // end class MathTool
    } // end namespace Tools
} // end namespace Framework 

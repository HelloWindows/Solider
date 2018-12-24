/*******************************************************************
 * FileName: CustomTightRotateEnabledPackerPolicy.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace CustomEditor {
    // TightPackerPolicy will tightly pack non-rectangle Sprites unless their packing tag contains "[RECT]".
    class CustomTightRotateEnabledPackerPolicy : CustomPackerPolicy {
        protected override string TagPrefix { get { return "[RECT]"; } }
        protected override bool AllowTightWhenTagged { get { return false; } }
        protected override bool AllowRotationFlipping { get { return true; } }
    } // end class CustomTightRotateEnabledPackerPolicy
} // end namespace CustomEditor 

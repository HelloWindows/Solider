/*******************************************************************
 * FileName: CustomTightPackerPolicy.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
namespace CustomEditor {
    // TightPackerPolicy will tightly pack non-rectangle Sprites unless their packing tag contains "[RECT]".
    class CustomTightPackerPolicy : CustomPackerPolicy {
        protected override string TagPrefix { get { return "[RECT]"; } }
        protected override bool AllowTightWhenTagged { get { return false; } }
        protected override bool AllowRotationFlipping { get { return false; } }
    } // end class CustomTightPackerPolicy
} // end namespace CustomEditor 

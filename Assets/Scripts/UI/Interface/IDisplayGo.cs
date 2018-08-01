/*******************************************************************
 * FileName: IDisplayGo.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/

using UnityEngine;

namespace Solider {
    namespace UI {
        namespace Interface {
            public interface IDisplayGo {
                bool isDispose { get; }
                void Reset(Transform parent);
                void Dispose();
                void Rotate(float offset);
            } // end class IDisplayGo
        } // end namespace Interface
    } // end namespace UI
} // end namespace Solider
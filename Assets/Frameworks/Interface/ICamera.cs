/*******************************************************************
 * FileName: ICamera.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;

namespace Framework {
    namespace Interface {
        public interface ICamera {
            Camera camera { get; }
            void Update(float deltaTime);
        } // end interface ICamera 
    } // end namespace Interface
} // end namespace Framework
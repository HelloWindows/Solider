/*******************************************************************
 * FileName: ICamera.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using UnityEngine;

namespace Framework {
    namespace Interface {
        namespace View {
            public interface ICamera {
                Camera camera { get; }
                void LateUpdate(float deltaTime);
                void SetTarget(ICharacter target);
            } // end interface ICamera 
        } // end namespace View
    } // end namespace Interface
} // end namespace Framework
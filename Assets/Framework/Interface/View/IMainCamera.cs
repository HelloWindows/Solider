/*******************************************************************
 * FileName: IMainCamera.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.Interface;
using UnityEngine;

namespace Framework {
    namespace Interface {
        namespace View {
            public interface IMainCamera {
                Camera camera { get; }
                void SetTarget(ICharacter target);
            } // end interface IMainCamera 
        } // end namespace View
    } // end namespace Interface
} // end namespace Framework
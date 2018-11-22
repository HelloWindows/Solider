/*******************************************************************
 * FileName: ICharacterSkill.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterSkill {
                List<string> skillIDList { get; }
                void Update(float deltaTime);
                void PushSkill(string id);
                bool CastSkill(string id);
                float GetSchedule(string id);
                float GetTimer(string id);
            } // end interface ICharacterSkill 
        } // end namespace Interface
    } // end namespace Character
} // end namespace Custom
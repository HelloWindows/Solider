/*******************************************************************
 * FileName: ICharacterSkill.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.ModelData.Interface;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterSkill {
                void Update(float deltaTime);
                void PushSkill(string id);
                bool CastSkill(string id, bool ignoreCD = false);
                ITimer GetTimer(string id);
                ITimer[] GetTimerArray(params string[] idArray);
            } // end interface ICharacterSkill 
        } // end namespace Interface
    } // end namespace Character
} // end namespace Custom
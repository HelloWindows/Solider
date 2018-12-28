﻿/*******************************************************************
 * FileName: ICharacterSkill.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Model.Interface;
using Solider.ModelData.Interface;

namespace Solider {
    namespace Character {
        namespace Interface {
            public interface ICharacterSkill {
                void PushSkill(string id);
                bool CastSkill(string id, bool ignoreCD = false);
                void Cooldown(string id, float coolTime);
                void CooldownAll(float coolTime);
                void InstantCooldown(string id);
                void InstantCooldownAll();
                void InstantCooldownAll(params string[] ignoreList);
                ISkillModle[] GetSkillModleArray();
            } // end interface ICharacterSkill 
        } // end namespace Interface
    } // end namespace Character
} // end namespace Custom
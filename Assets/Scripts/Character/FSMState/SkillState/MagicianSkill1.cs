﻿/*******************************************************************
 * FileName: MagicianSkill1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class MagicianSkill1 : ICharacterState {
                public string id { get { return "600101"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private ICharacter character;
                private ISkillInfo info;

                public MagicianSkill1(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end MagicianSkill1

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill1");
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if   
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class MagicianSkill1 
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider
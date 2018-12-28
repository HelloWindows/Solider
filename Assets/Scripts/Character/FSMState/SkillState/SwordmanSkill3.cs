/*******************************************************************
 * FileName: SwordmanSkill3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class SwordmanSkill3 : ICharacterState {
                public const string ID = "500003";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new SwordmanSkill3(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private ICharacter character;
                private ISkillInfo info;

                public SwordmanSkill3( ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end SwordmanSkill3

                public void DoBeforeEntering() {
                    character.avatar.Play("skill3");
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
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
            } // end class SwordmanSkill3
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

/*******************************************************************
 * FileName: SwordmanSkill1.cs
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
            public class SwordmanSkill1 : ICharacterState {
                public const string ID = "500001";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new SwordmanSkill1(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private float step;
                private ICharacter character;
                private ISkillInfo info;

                private SwordmanSkill1(ICharacter character, ISkillInfo info) {
                    step = 3f;
                    this.character = character;
                    this.info = info;
                } // end SwordmanSkill1

                public void DoBeforeEntering() {
                    character.avatar.Play("skill1");
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act() {
                    character.move.MoveForward(step);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill1
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

/*******************************************************************
 * FileName: SwordmanAttack1.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class SwordmanSkill1 : IFSMState {
                public string id { get { return "skill1"; } }
                private float step;
                private ICharacter character;

                public SwordmanSkill1(ICharacter character) {
                    step = 3f;
                    this.character = character;
                } // end SwordmanAttack1

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCache("swordman_skill_1");
                    character.avatar.Play("skill1");
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                    character.move.StepForward(step, deltaTime);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class SwordmanSkill1
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

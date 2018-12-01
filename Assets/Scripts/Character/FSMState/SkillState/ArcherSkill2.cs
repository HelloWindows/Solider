/*******************************************************************
 * FileName: ArcherSkill2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class ArcherSkill2 : IFSMState, ICharacterFSMState {
                public string id { get { return "600202"; } }
                private ICharacter character;
                private string soundPath { get { return "Character/Hero/Archer/Sound/archer_skill2"; } }

                public ArcherSkill2(ICharacter character) {
                    this.character = character;
                } // end ArcherSkill1

                public IFSMState CreateInstance(ICharacter character){
                    if (null == character) {
                        DebugTool.ThrowException("ArcherSkill2 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new ArcherSkill2(character);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                    character.avatar.PlayQueued(new string[] { "skill2_1", "skill2_2", "skill2_3" });
                } // end DoBeforeEntering

                public void Reason(float deltaTime) {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                    } // end if
                } // end Reason

                public void Act(float deltaTime) {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class ArcherSkill2
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

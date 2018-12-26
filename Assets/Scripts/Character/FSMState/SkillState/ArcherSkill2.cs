/*******************************************************************
 * FileName: ArcherSkill2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Config.Interface;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class ArcherSkill2 : IFSMState, ISkillFSMState {
                public string id { get { return "600202"; } }
                private ICharacter character;
                private ISkillInfo info;

                public ArcherSkill2(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end ArcherSkill1

                public IFSMState CreateInstance(ICharacter character, ISkillInfo info) {
                    if (null == character) {
                        DebugTool.ThrowException("ArcherSkill2 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    if (null == info) {
                        DebugTool.ThrowException("ArcherSkill2 CreateInstance SkillInfo is null!!!");
                        return null;
                    } // end if
                    return new ArcherSkill2(character, info);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.PlayQueued(new string[] { "skill2_1", "skill2_2", "skill2_3" });
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
            } // end class ArcherSkill2
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

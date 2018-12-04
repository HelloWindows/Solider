/*******************************************************************
 * FileName: ArcherSkill2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
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
                private static ICharacterFSMStateInfo info;

                public ArcherSkill2(ICharacter character) {
                    this.character = character;
                    if (null == info)
                        info = Configs.characterFSMStateConfig.GetCharacterFSMStateInfo(id);
                    // end if
                } // end ArcherSkill1

                public IFSMState CreateInstance(ICharacter character, ISkillInfo skillInfo) {
                    if (null == character) {
                        DebugTool.ThrowException("ArcherSkill2 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new ArcherSkill2(character);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
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

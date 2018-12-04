/*******************************************************************
 * FileName: MagicianSkill3.cs
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
            public class MagicianSkill3 : IFSMState, ISkillFSMState {
                public string id { get { return "600103"; } }
                private ICharacter character;
                private static ICharacterFSMStateInfo info;

                public MagicianSkill3(ICharacter character) {
                    this.character = character;
                    if (null == info)
                        info = Configs.characterFSMStateConfig.GetCharacterFSMStateInfo(id);
                    // end if
                } // end MagicianSkill3

                public IFSMState CreateInstance(ICharacter character, ISkillInfo skillInfo) {
                    if (null == character) {
                        DebugTool.ThrowException("MagicianSkill3 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new MagicianSkill3(character);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill3");
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
            } // end class MagicianSkill3 
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider
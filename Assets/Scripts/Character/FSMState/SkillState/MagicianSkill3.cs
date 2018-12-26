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
                private ISkillInfo info;

                public MagicianSkill3(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end MagicianSkill3

                public IFSMState CreateInstance(ICharacter character, ISkillInfo info) {
                    if (null == character) {
                        DebugTool.ThrowException("MagicianSkill3 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    if (null == info) {
                        DebugTool.ThrowException("MagicianSkill3 CreateInstance SkillInfo is null!!!");
                        return null;
                    } // end if
                    return new MagicianSkill3(character, info);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill3");
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
            } // end class MagicianSkill3 
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider
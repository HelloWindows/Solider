/*******************************************************************
 * FileName: MagicianSkill1.cs
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
            public class MagicianSkill1 : IFSMState, ISkillFSMState {
                public string id { get { return "600101"; } }
                private ICharacter character;
                private ISkillInfo info;

                public MagicianSkill1(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end MagicianSkill1

                public IFSMState CreateInstance(ICharacter character, ISkillInfo info) {
                    if (null == character) {
                        DebugTool.ThrowException("MagicianSkill1 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    if (null == info) {
                        DebugTool.ThrowException("MagicianSkill1 CreateInstance SkillInfo is null!!!");
                        return null;
                    } // end if
                    return new MagicianSkill1(character, info);
                } // end CreateInstance

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
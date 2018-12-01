/*******************************************************************
 * FileName: MagicianSkill2.cs
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
            public class MagicianSkill2 : IFSMState, ICharacterFSMState {
                public string id { get { return "600102"; } }
                private ICharacter character;
                private string soundPath { get { return "Character/Hero/Magician/Sound/magician_skill2"; } }

                public MagicianSkill2(ICharacter character) {
                    this.character = character;
                } // end MagicianSkill2

                public IFSMState CreateInstance(ICharacter character) {
                    if (null == character) {
                        DebugTool.ThrowException("MagicianSkill2 CreateInstance character is null!!!");
                        return null;
                    } // end if
                    return new MagicianSkill2(character);
                } // end CreateInstance

                public void DoBeforeEntering() {
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                    character.avatar.Play("skill2");
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
            } // end class MagicianSkill2 
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider
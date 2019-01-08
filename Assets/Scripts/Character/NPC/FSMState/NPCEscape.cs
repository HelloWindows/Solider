/*******************************************************************
 * FileName: NPCEscape.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Solider.Character.FSM;
using Solider.Character.Interface;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class NPCEscape : ICharacterState {
                public string id { get { return "escape"; } }
                public string anim { get { return "run"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }

                private float scope;
                private ICharacter character;

                public NPCEscape(ICharacter character) {
                    scope = 10f;
                    this.character = character;
                } // end NPCEscape

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition("die");
                        return;
                    } // end if
                    if (null == character.info.lockCharacter ||
                        Vector3.Distance(character.info.lockCharacter.position, character.position) > scope) {
                        character.fsm.PerformTransition("idle");
                        return;
                    } // end if
                } // end Reason

                public void Act() {
                    Vector3 dir = character.position - character.info.lockCharacter.position;
                    character.move.MoveForward(dir, character.info.characterData.MSP);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class NPCEscape
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider
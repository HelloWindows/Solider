/*******************************************************************
 * FileName: NPCEscape.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Common;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class NPCEscape : ICharacterState {
                public string id { get { return NPCStateID.Escape; } }
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
                        character.fsm.PerformTransition(NPCStateID.Die);
                        return;
                    } // end if
                    if (null == character.info.lockCharacter) {
                        character.fsm.PerformTransition(NPCStateID.Idle);
                        return;
                    } // end if
                    if (Vector3.Distance(character.info.lockCharacter.position, character.position) > scope) {
                        character.info.LockCharacter(null);
                        character.fsm.PerformTransition(NPCStateID.Idle);
                        return;
                    } // end if
                    Vector3 dir = character.position - character.info.lockCharacter.position;
                    character.move.MoveForward(new Vector2(dir.x, dir.z), character.info.characterData.MSP);
                } // end Reason

                public void Act() {

                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class NPCEscape
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider
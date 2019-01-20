/*******************************************************************
 * FileName: Close_NeutralNPCChase.cs
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
            public class Close_NeutralNPCChase : ICharacterState {
                public string id { get { return "chase"; } }
                public string anim { get { return "run"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }

                private float scope;
                private float reach;
                private ICharacter character;
                private Vector3 dir;
                private float distance;

                public Close_NeutralNPCChase(ICharacter character) {
                    reach = 1f;
                    scope = 10f;
                    this.character = character;
                } // end Close_NeutralNPCChase

                public void DoBeforeEntering() {
                    character.avatar.Play(anim);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition("die");
                        return;
                    } // end if
                    if (null == character.info.lockCharacter) {
                        character.fsm.PerformTransition("idle");
                        return;
                    } // end if
                    distance = Vector3.Distance(character.info.lockCharacter.position, character.position);
                    if (distance > scope) {
                        character.info.LockCharacter(null);
                        character.fsm.PerformTransition("idle");
                        return;
                    } // end if
                    if (distance < reach) {
                        character.fsm.PerformTransition("attack_1");
                    } // end if
                    dir = character.info.lockCharacter.position - character.position;
                    character.move.MoveForward(new Vector2(dir.x, dir.z), character.info.characterData.MSP);
                } // end Reason

                public void Act() {

                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class Close_NeutralNPCChase
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider

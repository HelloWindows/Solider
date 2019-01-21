/*******************************************************************
 * FileName: NPCChase.cs
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
            public class NPCChase : ICharacterState {
                public string id { get { return NPCStateID.Chase; } }
                public string anim { get { return "run"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }

                private float scope;
                private float reach;
                private ICharacter character;
                private Vector3 dir;
                private float distance;

                public NPCChase(ICharacter character) {
                    if (false == ParamConfig.TryGetNPCReach((NPCType)character.config.npc_type, out reach)) reach = 1;
                    // end if
                    scope = 10f;
                    this.character = character;
                } // end NPCChase

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
                    distance = Vector3.Distance(character.info.lockCharacter.position, character.position);
                    if (distance > scope) {
                        character.info.LockCharacter(null);
                        character.fsm.PerformTransition(NPCStateID.Idle);
                        return;
                    } // end if
                    if (distance < reach) {
                        character.fsm.PerformTransition(NPCStateID.Attack_1);
                        return;
                    } // end if
                    dir = character.info.lockCharacter.position - character.position;
                    character.move.MoveForward(new Vector2(dir.x, dir.z), character.info.characterData.MSP);
                } // end Reason

                public void Act() {

                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class NPCChase
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider

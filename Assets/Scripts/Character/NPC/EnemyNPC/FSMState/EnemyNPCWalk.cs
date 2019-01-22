/*******************************************************************
 * FileName: EnemyNPCWalk.cs
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
            public class EnemyNPCWalk : ICharacterState {
                public string id { get { return NPCStateID.Walk; } }
                private string anim { get { return "run"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }

                private ICharacter character;
                private float timer;
                private float scope;
                private Vector2 dir;

                public EnemyNPCWalk(ICharacter character) {
                    scope = 10f;
                    this.character = character;
                } // end EnemyNPCWalk

                public void DoBeforeEntering() {
                    timer = Random.Range(3f, 5f);
                    character.avatar.Play(anim);
                    dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                    if (dir == Vector2.zero) dir = new Vector2(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition(NPCStateID.Die);
                        return;
                    } // end if
                    if (null != character.info.lockCharacter &&
                        Vector3.Distance(character.info.lockCharacter.position, character.position) < scope) {
                        character.fsm.PerformTransition(NPCStateID.Chase);
                        return;
                    } // end if
                    if (timer > 0) {
                        timer -= Time.deltaTime;
                        return;
                    } // end if
                    character.fsm.PerformTransition(NPCStateID.Idle);
                } // end Reason

                public void Act() {
                    character.move.MoveForward(dir, character.info.characterData.MSP);
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class EnemyNPCWalk
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider
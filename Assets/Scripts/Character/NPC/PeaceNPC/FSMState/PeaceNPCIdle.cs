﻿/*******************************************************************
 * FileName: PeaceNPCIdle.cs
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
            public class PeaceNPCIdle : ICharacterState {
                public string id { get { return NPCStateID.Idle; } }
                public string anim { get { return "idle"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Default); } }

                private ICharacter character;
                private float timer;
                private float scope;

                public PeaceNPCIdle(ICharacter character) {
                    scope = 8f;
                    this.character = character;
                } // end PeaceNPCIdle

                public void DoBeforeEntering() {
                    timer = Random.Range(3f, 5f);
                    character.avatar.Play(anim);
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition(NPCStateID.Die);
                        return;
                    } // end if
                    if (null != character.info.lockCharacter &&
                        Vector3.Distance(character.info.lockCharacter.position, character.position) < scope) {
                        character.fsm.PerformTransition(NPCStateID.Escape);
                        return;
                    } // end if
                    if (timer > 0) {
                        timer -= Time.deltaTime;
                        return;
                    } // end if
                    character.fsm.PerformTransition(NPCStateID.Walk);
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class PeaceNPCIdle
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider
﻿/*******************************************************************
 * FileName: NPCDie.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Framework.Manager;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class NPCDie : ICharacterState {
                public string id { get { return "die"; } }
                public string anim { get { return "die"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Highest); } }

                private ICharacter character;
                private float timer;
                private bool isDispoed;

                public NPCDie(ICharacter character) {
                    this.character = character;
                    timer = 3f;
                } // end NPCDie

                public void DoBeforeEntering() {
                    isDispoed = false;
                    character.avatar.Play(anim);
                } // end DoBeforeEntering

                public void Reason() {
                    if (isDispoed) return;
                    // end if
                    if (timer > 0) {
                        timer -= Time.deltaTime;
                        return;
                    } // end if
                    isDispoed = true;
                    SceneManager.characterManager.factory.DisposeNPC(character.hashID);
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving
            } // end class NPCDie
        } // end namespace NPC
    } // end namespace Character 
} // end namespace Solider
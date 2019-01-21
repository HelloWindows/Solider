/*******************************************************************
 * FileName: NPCDie.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using UnityEngine;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Framework.Manager;
using Solider.Tools;
using Solider.Config.Common;

namespace Solider {
    namespace Character {
        namespace NPC {
            public class NPCDie : ICharacterState {
                public string id { get { return NPCStateID.Die; } }
                public string anim { get { return "die"; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Highest); } }

                private ICharacter character;
                private float timer;
                private bool isDispoed;
                private string soundPath;
                private string effectPath;

                public NPCDie(ICharacter character) {
                    this.character = character;
                    timer = 3f;
                    character.config.TryGetSoundPath(id, out soundPath);
                    character.config.TryGetEffectPath(id, out effectPath);
                } // end NPCDie

                public void DoBeforeEntering() {
                    isDispoed = false;
                    character.avatar.Play(anim);
                    character.audio.PlaySoundCacheForPath(id, soundPath);
                    EffectTool.ShowEffectFromPool(effectPath, 2f, character.position, character.rotation);
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
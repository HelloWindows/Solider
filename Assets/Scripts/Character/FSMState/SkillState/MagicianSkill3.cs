/*******************************************************************
 * FileName: MagicianSkill3.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Manager;
using Framework.Tools;
using Solider.Character.FSM;
using Solider.Character.Interface;
using Solider.Config.Interface;
using Solider.ModelData.Data;
using Solider.Widget;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Skill {
            public class MagicianSkill3 : ICharacterState {
                public const string ID = "500103";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new MagicianSkill3(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private ICharacter character;
                private ISkillInfo info;
                private bool isFlight;

                private MagicianSkill3(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end MagicianSkill3

                public void DoBeforeEntering() {
                    isFlight = false;
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill3");
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.avatar.isPlaying) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    Flight();
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                } // end DoBeforeLeaving

                private void Flight() {
                    if (isFlight) return;
                    // end if
                    AnimationState state = character.avatar.GetCurrentState("skill3");
                    if (null == state || state.normalizedTime < 0.5f) return;
                    // end if
                    isFlight = true;
                    DamageData damage = new DamageData(character);
                    Thunder thunder = Object.Instantiate(ResourcesTool.LoadPrefab("thunder")).AddComponent<Thunder>();
                    thunder.transform.position = character.position + Vector3.up * 0.8f + character.forward * 6.5f;
                    thunder.transform.rotation = character.rotation;
                    thunder.SetDamage(damage);
                } // end Flight
            } // end class MagicianSkill3 
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider
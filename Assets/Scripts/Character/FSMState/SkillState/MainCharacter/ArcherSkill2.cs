/*******************************************************************
 * FileName: ArcherSkill2.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.FSM.Interface;
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
            public class ArcherSkill2 : IFSMState, ICharacterState {
                public const string ID = "500202";
                public static ICharacterState CreateInstance(ICharacter character, ISkillInfo info) {
                    return new ArcherSkill2(character, info);
                } // end CreateInstance

                public string id { get { return ID; } }
                public int layer { get { return System.Convert.ToInt32(StateLayer.Skill); } }
                private ICharacter character;
                private ISkillInfo info;
                private bool isFlight;
                private bool isFinish;
                private GameObject arrow;

                private ArcherSkill2(ICharacter character, ISkillInfo info) {
                    this.character = character;
                    this.info = info;
                } // end ArcherSkill1

                public void DoBeforeEntering() {
                    isFlight = false;
                    isFinish = false;
                    character.audio.PlaySoundCacheForPath(id, info.soundPath);
                    character.avatar.Play("skill2_1");
                } // end DoBeforeEntering

                public void Reason() {
                    if (false == character.info.characterData.IsLive) {
                        character.fsm.PerformTransition("die");
                        return;
                    } // end if
                    if (character.avatar.isPlaying) return;
                    // end if
                    if (isFinish) {
                        character.fsm.PerformTransition("wait");
                        return;
                    } // end if
                    if (ShowArrow()) return;
                    // end if
                    FlightArrow();
                } // end Reason

                public void Act() {
                } // end Act

                public void DoBeforeLeaving() {
                    arrow = null;
                } // end DoBeforeLeaving

                private bool ShowArrow() {
                    if (isFlight) return false;
                    // end if
                    isFlight = true;
                    character.avatar.Play("skill2_2");
                    if (null != arrow) Object.Destroy(arrow.gameObject);
                    // end if
                    arrow = Object.Instantiate(ResourcesTool.LoadPrefab("explosive_arrow"));
                    arrow.transform.position = character.position + Vector3.up * 0.8f;
                    arrow.transform.rotation = character.rotation;
                    arrow.gameObject.SetActive(true);
                    return true;
                } // end ShowArrow

                private void FlightArrow() {
                    if (isFinish) return;
                    // end if
                    isFinish = true;
                    character.avatar.Play("skill2_3");
                    if (null == arrow) return;
                    // end if
                    DamageData damage = new DamageData(character);
                    ExplosiveArrow t_arrow = arrow.GetComponent<ExplosiveArrow>();
                    if (null == t_arrow) t_arrow = arrow.AddComponent<ExplosiveArrow>();
                    // end if
                    t_arrow.SetDamage(damage);
                } // end FlightArrow
            } // end class ArcherSkill2
        } // end namespace Skill
    } // end namespace Character
} // end namespace Solider 

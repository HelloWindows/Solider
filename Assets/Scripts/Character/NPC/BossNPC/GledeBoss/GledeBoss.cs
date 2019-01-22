/*******************************************************************
 * FileName: GledeBoss.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Game;
using Framework.Tools;
using Solider.Character.Interface;
using Solider.Character.NPC;
using Solider.Character.Skill;
using UnityEngine;
namespace Solider {
    namespace Character {
        namespace Boss {
            public class GledeBoss : Character, ISkillCharacter {

                public ICharacterSkill skill { get { return m_skill; } }
                private CharacterSkill m_skill;

                public static Character CreateInstance(string id, Vector3 position) {
                    return new GledeBoss(id, position);
                } // end CreateInstance

                private GledeBoss(string id, Vector3 position) : base(id, Object.Instantiate(ResourcesTool.LoadPrefab(id))) {
                    gameObject.layer = LayerConfig.NPC;
                    transform.position = position;
                    transform.rotation = Quaternion.identity;
                    m_info = new NPCharacterInfo(config.name, this);
                    m_avatar = new GledeBossAvatar(id, gameObject.AddComponent<Animation>());
                    m_surface = new CharacterSurface(transform.GetComponentInChildren<SkinnedMeshRenderer>());
                    m_skill = new CharacterSkill(this);
                    m_fsm = new GledeBossFSM(this);
                    m_skill.PushSkill(GledeSkill_1.ID);
                } // end GledeBoss

                public override void Update() {
                    base.Update();
                    m_info.Update();
                    m_fsm.Update();
                    m_skill.Update();
                } // end Update

                public override void Dispose() {
                    if (null != m_info) m_info.Dispose();
                    // end if
                    if (null != m_avatar) m_avatar.Dispose();
                    // end if
                    base.Dispose();
                } // end Dispose
            } // end class GledeBoss 
        } // end namespace Boss
    } // end namespace Character
} // end namespace Solider
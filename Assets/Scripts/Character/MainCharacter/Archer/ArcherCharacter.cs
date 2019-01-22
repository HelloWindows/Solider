/*******************************************************************
 * FileName: ArcherCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config.Const;
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class ArcherCharacter : MainCharacter {

                public static MainCharacter CreateInstance(string name, Vector3 pos) {
                    return new ArcherCharacter(name, pos);
                } // end CreateInstance

                private ArcherCharacter(string name, Vector3 pos) : base(ConstConfig.ARCHER, ConstConfig.ARCHER,
                    ObjectTool.InstantiateGo(name, ResourcesTool.LoadPrefab(ConstConfig.ARCHER), null, pos, Vector3.zero, Vector3.one)) {
                    m_info = new MainCharacterInfo(name, ConstConfig.ARCHER, this);
                    m_avatar = new ArcherAvatar(gameObject.AddComponent<Animation>());
                    SkinnedMeshRenderer meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
                    Transform wingTrans = null;
                    Transform liftTrans = null;
                    Transform furlTrans = null;
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == "wing_spine") {
                            wingTrans = child;
                            break;
                        } // end if
                    } // end foreach
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == "left_hand") {
                            liftTrans = child;
                            break;
                        } // end if
                    } // end foreach
                    foreach (Transform child in allChildren) {
                        if (child.gameObject.name == "weapon_spine") {
                            furlTrans = child;
                            break;
                        } // end if
                    } // end foreach
                    m_mainSurface = new MainCharacterSurface(this, wingTrans, liftTrans, furlTrans, meshRenderer);
                    m_surface = m_mainSurface;
                    m_fsm = new ArcherFSM(this);
                    skill.PushSkill("500201");
                    skill.PushSkill("500202");
                    skill.PushSkill("500203");
                } // end ArcherCharacter

                public override void Update() {
                    base.Update();
                    m_info.Update();
                    m_fsm.Update();
                } // end Update

                public override void Dispose() {
                    if (null != m_info) m_info.Dispose();
                    // end if
                    if (null != m_avatar) m_avatar.Dispose();
                    // end if
                    if (null != m_mainSurface) m_mainSurface.Dispose();
                    // end if
                    base.Dispose();
                } // end Dispose
            } // end class ArcherCharacter
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Custom 

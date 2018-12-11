/*******************************************************************
 * FileName: ArcherCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.Custom;
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Hero {
            public class ArcherCharacter : HeroCharacter {

                public ArcherCharacter(string id, Vector3 pos, string name) : base(id, ObjectTool.InstantiateGo(name,
                    Configs.prefabConfig.GetPath(ConstConfig.ARCHER), null, pos, Vector3.zero, Vector3.one)) {
                    input = new CrossInput();
                    m_info = new CharacterInfo(name, ConstConfig.ARCHER, config.initAttribute);
                    m_avatar = new ArcherAvatar(m_gameObject.AddComponent<Animation>());
                    SkinnedMeshRenderer meshRenderer = m_transform.GetComponentInChildren<SkinnedMeshRenderer>();
                    Transform[] allChildren = m_transform.GetComponentsInChildren<Transform>();
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
                    surface = new HeroCharacterSurface(wingTrans, liftTrans, furlTrans, meshRenderer);
                    surface.Freshen();
                    m_fsmSystem = new ArcherFSM(this);
                } // end ArcherCharacter

                public override void Dispose() {
                    base.Dispose();
                    if (null != m_avatar) {
                        m_avatar.Dispose();
                        m_avatar = null;
                    } // end if
                } // end Dispose
            } // end class ArcherCharacter
        } // end namespace Hero
    } // end namespace Character
} // end namespace Custom 

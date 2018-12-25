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
        namespace MainCharacter {
            public class ArcherCharacter : MainCharacter {

                public ArcherCharacter(string id, Vector3 pos, string name) : base(id, ConstConfig.ARCHER,
                    ObjectTool.InstantiateGo(name,Configs.prefabConfig.GetPath(ConstConfig.ARCHER),
                        null, pos, Vector3.zero, Vector3.one)) {
                    input = new CrossInput();
                    m_info = new MainCharacterInfo(name, ConstConfig.ARCHER, this);
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
                    surface = new MainCharacterSurface(this, wingTrans, liftTrans, furlTrans, meshRenderer);
                    m_fsmSystem = new ArcherFSM(this);
                } // end ArcherCharacter

                public override void Dispose() {
                    if (null != m_avatar) m_avatar.Dispose();
                    // end if
                    base.Dispose();
                } // end Dispose
            } // end class ArcherCharacter
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Custom 

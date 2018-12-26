/*******************************************************************
 * FileName: MagicianCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.Tools;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace MainCharacter {
            public class MagicianCharacter : MainCharacter {

                public MagicianCharacter(string id, Vector3 pos, string name) : base(id, ConstConfig.MAGICIAN,
                    ObjectTool.InstantiateGo(name, Configs.prefabConfig.GetPath(ConstConfig.MAGICIAN), 
                        null, pos, Vector3.zero, Vector3.one)) {
                    m_info = new MainCharacterInfo(name, ConstConfig.MAGICIAN, this);
                    m_avatar = new MagicianAvatar(m_gameObject.AddComponent<Animation>());
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
                        if (child.gameObject.name == "right_hand") {
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
                    m_surface = new MainCharacterSurface(this, wingTrans, liftTrans, furlTrans, meshRenderer);
                    m_fsmSystem = new MagicianFSM(this);
                } // end MagicianCharacter

                public override void Update() {
                    m_info.Update();
                    m_fsmSystem.Update();
                } // end Update

                public override void Dispose() {
                    if (null != m_info) m_info.Dispose();
                    // end if
                    if (null != m_avatar) m_avatar.Dispose();
                    // end if
                    if (null != m_surface) m_surface.Dispose();
                    // end if
                    base.Dispose();
                } // end Dispose
            } // end class MagicianCharacter 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
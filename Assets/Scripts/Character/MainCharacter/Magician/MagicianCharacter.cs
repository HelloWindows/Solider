/*******************************************************************
 * FileName: MagicianCharacter.cs
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
            public class MagicianCharacter : MainCharacter {
                            
                public static MainCharacter CreateInstance(string name, Vector3 pos) {
                    return new MagicianCharacter(name, pos);
                } // end CreateInstance

                private MagicianCharacter(string name, Vector3 pos) : base(ConstConfig.MAGICIAN, ConstConfig.MAGICIAN,
                    ObjectTool.InstantiateGo(name, ResourcesTool.LoadPrefab(ConstConfig.MAGICIAN), null, pos, Vector3.zero, Vector3.one)) {
                    m_info = new MainCharacterInfo(name, ConstConfig.MAGICIAN, this);
                    m_avatar = new MagicianAvatar(gameObject.AddComponent<Animation>());
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
                    m_mainSurface = new MainCharacterSurface(this, wingTrans, liftTrans, furlTrans, meshRenderer);
                    m_surface = m_mainSurface;
                    m_fsm = new MagicianFSM(this);
                } // end MagicianCharacter

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
            } // end class MagicianCharacter 
        } // end namespace MainCharacter
    } // end namespace Character
} // end namespace Solider
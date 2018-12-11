/*******************************************************************
 * FileName: MagicianCharacter.cs
 * Author: Yogi
 * Creat Date:
 * Copyright (c) 2018-xxxx 
 *******************************************************************/
using Framework.Config;
using Framework.Config.Const;
using Framework.Custom;
using Framework.FSM.Interface;
using Framework.Tools;
using Solider.Character.Hero;
using UnityEngine;

namespace Solider {
    namespace Character {
        namespace Hero {
            public class MagicianCharacter : HeroCharacter {

                public MagicianCharacter(string id, Vector3 pos, string name) : base(id, ObjectTool.InstantiateGo(name,
                    Configs.prefabConfig.GetPath(ConstConfig.MAGICIAN), null, pos, Vector3.zero, Vector3.one)) {
                    input = new CrossInput();              
                    m_info = new CharacterInfo(name, ConstConfig.MAGICIAN, config.initAttribute);
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
                    surface = new HeroCharacterSurface(wingTrans, liftTrans, furlTrans, meshRenderer);
                    surface.Freshen();
                    m_fsmSystem = new MagicianFSM(this);
                } // end MagicianCharacter
            } // end class MagicianCharacter 
        } // end namespace Hero
    } // end namespace Character
} // end namespace Solider
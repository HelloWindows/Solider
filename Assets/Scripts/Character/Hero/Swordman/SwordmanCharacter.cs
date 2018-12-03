/*******************************************************************
 * FileName: Swordsman.cs
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
            public class SwordmanCharacter : HeroCharacter {

                public SwordmanCharacter(string id, Vector3 pos, string name) : base(id, ObjectTool.InstantiateGo(name, 
                    Configs.prefabConfig.GetPath(ConstConfig.SWORDMAN), null, pos, Vector3.zero, Vector3.one)) {
                    input = new CrossInput();
                    buff = new CharacterBuff();
                    move = new CharacterMove(transform);
                    avatar = new SwordmanAvatar(gameObject.AddComponent<Animation>());
                    audio = new CharacterAduio(gameObject.AddComponent<AudioSource>());
                    info = new CharacterInfo(name, ConstConfig.SWORDMAN, config.initAttribute);
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
                    surface = new HeroCharacterSurface(wingTrans, liftTrans, furlTrans, meshRenderer);
                    surface.Freshen();
                    fsmSystem = new SwordmanFSM(this);
                    fsm = fsmSystem as IFSM;
                } // end SwordmanCharacter
            } // end class SwordmanCharacter
        } // end namespace Hero
    } // end namespace Character
} // end namespace Custom 

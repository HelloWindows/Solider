/*******************************************************************
 * FileName: ArcherCharacter.cs
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
        namespace Archer {
            public class ArcherCharacter : Character {

                public ArcherCharacter(Vector3 pos, string name) : base(ObjectTool.InstantiateGo(name,
                    Configs.prefabConfig.GetPath(ConstConfig.ARCHER), null, pos, Vector3.zero, Vector3.one)) {
                    input = new CrossInput();
                    buff = new CharacterBuff();
                    move = new HeroMove(gameObject.GetComponent<Rigidbody>());
                    avatar = new ArcherAvatar(gameObject.AddComponent<Animation>());
                    audio = new CharacterAduio(gameObject.AddComponent<AudioSource>());
                    info = new Model.CharacterInfo(id, name, ConstConfig.ARCHER);
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
                    surface = new CharacterSurface(wingTrans, liftTrans, furlTrans, meshRenderer);
                    surface.Freshen();
                    fsmSystem = new ArcherFSM(this);
                    fsm = fsmSystem as IFSM;
                } // end ArcherCharacter
            } // end class ArcherCharacter
        } // end namespace Archer
    } // end namespace Character
} // end namespace Custom 
